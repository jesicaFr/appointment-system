using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Api.DTOs
{
    public class UpdateAppointmentDto
    {

        public bool IsCancelled { get; set; }
    }
}
