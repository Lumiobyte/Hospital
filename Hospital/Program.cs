using Hospital.Repositories;
using Hospital.Services;
using Hospital.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital
{
    public class Program
    {



        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<HospitalDbContext>()
                .AddScoped<DoctorRepository>()
                .AddScoped<PatientRepository>()
                .AddScoped<AdminRepository>()
                .AddScoped<AppointmentRepository>()
                .AddTransient<DoctorMenu>()
                .AddTransient<PatientMenu>()
                .AddTransient<AdminMenu>()
                .AddTransient<HospitalService>()
                .AddSingleton<MenuFactory>()
                .AddSingleton<ServiceFactory>()
                .BuildServiceProvider();

            MenuState.Instance.Push(new LoginMenu(serviceProvider.GetRequiredService<MenuFactory>(), serviceProvider.GetRequiredService<HospitalService>()));

            while (true)
            {
                MenuState.Instance.Show();
            }
        }
    }
}
