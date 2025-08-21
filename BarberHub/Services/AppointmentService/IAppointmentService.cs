using BarberHub.DTOs.AppointmentDTO;
using BarberHub.Models;

namespace BarberHub.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> BarberAppointments(int portfolioId);
        Task<Appointment> RemoveAppointment(int appointmentId);
        Task<Appointment> ScheduleAppointments(ScheduleAppointmentDTO DTO);
        Task<Appointment> UpdateAppointment(UpdateAppointmentDTO DTO);
        Task<List<Appointment>> UserAppointments(int userId);
    }
}