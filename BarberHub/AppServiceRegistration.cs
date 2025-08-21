using BarberHub.Services.AppointmentService;
using BarberHub.Services.CompanyProvidedService;
using BarberHub.Services.CompanyService;
using BarberHub.Services.CompanyTypeService;
using BarberHub.Services.PaymentService;
using BarberHub.Services.PortfolioService;
using BarberHub.Services.ReviewService;
using BarberHub.Services.SpecialtyService;
using BarberHub.Services.UserProfileService;
using BarberHub.Services.UserRoleService;
using BarberHub.Services.UserService;

namespace BarberHub
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<ICompanyTypeService, CompanyTypeService>();

            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddScoped<ICompanyProvidedService, CompanyProvidedService>();

            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPortfolioService, PortfolioService>();

            services.AddScoped<ISpecialtyService, SpecialtyService>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IPaymentService, PaymentService>();
        }

    }
}
