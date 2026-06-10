using System;

namespace AppointmentSystem.Api.DTOs
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public bool IsCancelled { get; set; }
    }
}
