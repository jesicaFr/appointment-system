using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentSystem.Api.DTOs;
using AppointmentSystem.Api.Models;
using AppointmentSystem.Api.Repositories;

namespace AppointmentSystem.Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppointmentResponseDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(ToResponse).ToList();
        }

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : ToResponse(item);
        }

        public async Task<AppointmentResponseDto> CreateAsync(CreateAppointmentDto dto)
        {
            ValidateDto(dto.PatientName, dto.AppointmentDate, dto.Reason);

            var entity = new Appointment
            {
                PatientName = dto.PatientName,
                AppointmentDate = dto.AppointmentDate,
                Reason = dto.Reason,
                IsCancelled = false
            };

            var created = await _repository.AddAsync(entity);
            return ToResponse(created);
        }

        public async Task<bool> UpdateAsync(int id, UpdateAppointmentDto dto)
        {

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.IsCancelled = dto.IsCancelled;

            await _repository.UpdateAsync(existing);
            return true;
        }


        private void ValidateDto(string patientName, DateTime appointmentDate, string reason)
        {
            if (string.IsNullOrWhiteSpace(patientName))
                throw new ArgumentException("PatientName is required.");

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason is required.");

            if (appointmentDate < DateTime.UtcNow)
                throw new ArgumentException("AppointmentDate cannot be in the past.");
        }

        private static AppointmentResponseDto ToResponse(Appointment a) => new AppointmentResponseDto
        {
            Id = a.Id,
            PatientName = a.PatientName,
            AppointmentDate = a.AppointmentDate,
            Reason = a.Reason,
            IsCancelled = a.IsCancelled
        };
    }
}
