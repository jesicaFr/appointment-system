using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Api.DTOs
{
    public class CreateAppointmentDto
    {
        [Required]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Reason { get; set; } = string.Empty;
    }
}
