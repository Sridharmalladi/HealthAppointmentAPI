using System.Text.Json;

namespace AppointmentAPI.Services
{
    public class HL7Parser
    {
        public string ParseHL7ToJson(string hl7Message)
        {
            // Simulate parsing the HL7 message into a JSON object
            // (For real-world use, integrate an HL7 parser library like NHapi)

            var eJson = new
            {
                MessageId = "12345",           // Extracted from HL7
                PatientId = "P123",            // Extracted from HL7
                PatientName = "John Doe",      // Example
                AppointmentDate = "2024-11-20T14:00:00" // Example
            };

            return JsonSerializer.Serialize(eJson);
        }
    }
}
