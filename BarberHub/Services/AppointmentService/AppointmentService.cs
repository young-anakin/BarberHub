using BarberHub.Context;
using BarberHub.DTOs.AppointmentDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DataContext _context;

        public AppointmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Appointment> ScheduleAppointments(ScheduleAppointmentDTO DTO)
        {
            var setter = await _context.Users.Where(u => u.UserId == DTO.UserId).FirstOrDefaultAsync();
            if (setter == null)
            {
                throw new Exception("User not found");
            }
            var prof = await _context.Portfolios.Where(p => p.PortfolioId == DTO.PortfolioId).FirstOrDefaultAsync();
            if (prof == null)
            {
                throw new Exception("Professional not found");
            }
            Appointment appointment = new Appointment();
            appointment.AppointmentDate = DTO.AppointmentDate;
            appointment.StartTime = DTO.StartTime;
            appointment.EndTime = DTO.EndTime;
            appointment.Notes = DTO.Notes;
            appointment.Status = DTO.Status;
            appointment.User = setter;
            appointment.Portfolio = prof;
            appointment.UserId = DTO.UserId;
            appointment.PortfolioId = DTO.PortfolioId;

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;

        }

        public async Task<Appointment> UpdateAppointment(UpdateAppointmentDTO DTO)
        {
            var setter = await _context.Users.Where(u => u.UserId == DTO.UserId).FirstOrDefaultAsync();
            if (setter == null)
            {
                throw new Exception("User not found");
            }
            var prof = await _context.Portfolios.Where(p => p.PortfolioId == DTO.PortfolioId).FirstOrDefaultAsync();
            if (prof == null)
            {
                throw new Exception("Professional not found");
            }
            var appointment = await _context.Appointments.Where(a => a.AppointmentId == DTO.AppointmentID).FirstOrDefaultAsync();
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }
            appointment.AppointmentDate = DTO.AppointmentDate;
            appointment.StartTime = DTO.StartTime;
            appointment.EndTime = DTO.EndTime;
            appointment.Notes = DTO.Notes;
            appointment.Status = DTO.Status;
            appointment.User = setter;
            appointment.Portfolio = prof;
            appointment.UserId = DTO.UserId;
            appointment.PortfolioId = DTO.PortfolioId;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> RemoveAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefaultAsync();
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<List<Appointment>> BarberAppointments(int portfolioId)
        {
            var appointments = await _context.Appointments.Where(a => a.PortfolioId == portfolioId).ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>> UserAppointments(int userId)
        {
            var appointments = await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();
            return appointments;
        }
    }
}
