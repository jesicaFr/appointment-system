using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentSystem.Api.DTOs;

namespace AppointmentSystem.Api.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto?> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(CreateAppointmentDto dto);
        Task<bool> UpdateAsync(int id, UpdateAppointmentDto dto);
    }
}
