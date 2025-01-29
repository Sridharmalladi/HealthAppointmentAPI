using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AppointmentAPI.Models;
using AppointmentAPI.Data;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Logging;

namespace AppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HL7Controller : ControllerBase
    {
        private readonly AppointmentDbContext _dbContext;
        private readonly ILogger<HL7Controller> _logger;

        public HL7Controller(AppointmentDbContext dbContext, ILogger<HL7Controller> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("parse")]
        public async Task<IActionResult> ParseHL7Message([FromBody] string hl7Message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hl7Message))
                    return BadRequest("HL7 message is required.");

                _logger.LogInformation("Received HL7 Message: {hl7Message}", hl7Message);

                var parsedJson = JsonConvert.SerializeObject(new
                {
                    MessageId = "12345",
                    PatientId = "P123",
                    AppointmentDate = DateTime.UtcNow
                });

                var appointment = new AppointmentRecord
                {
                    HL7Message = hl7Message,
                    ParsedJson = parsedJson,
                    MessageId = "12345",
                    PatientId = "P123",
                    AppointmentDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.AppointmentRecords.AddAsync(appointment);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Record saved with ID: {Id}", appointment.Id);

                PublishToRabbitMQ(appointment);

                return Ok(new { success = true, id = appointment.Id, parsedJson });
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError($"Database Error: {dbEx.Message}");
                return StatusCode(500, "Database operation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        private void PublishToRabbitMQ(AppointmentRecord appointment)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "hl7_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var message = JsonConvert.SerializeObject(appointment);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object>
                {
                    { "MessageId", appointment.MessageId }
                };

                channel.BasicPublish(exchange: "", routingKey: "hl7_queue", basicProperties: properties, body: body);

                _logger.LogInformation("Message published to RabbitMQ: {message}", message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RabbitMQ Error: {ex.Message}");
            }
        }
    }
}
