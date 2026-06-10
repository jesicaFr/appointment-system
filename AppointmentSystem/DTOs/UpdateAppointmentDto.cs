using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Api.DTOs
{
    public class UpdateAppointmentDto
    {

        public string PatientName { get; set; } = string.Empty;


        public DateTime AppointmentDate { get; set; }


        public string Reason { get; set; } = string.Empty;

        public bool IsCancelled { get; set; }
    }
}
