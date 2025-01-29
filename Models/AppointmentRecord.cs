using System;

namespace AppointmentAPI.Models
{
    public class AppointmentRecord
    {
        public int Id { get; set; }
        public string HL7Message { get; set; }
        public string ParsedJson { get; set; }
        public string MessageId { get; set; }
        public string PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
