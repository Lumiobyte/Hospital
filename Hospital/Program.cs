using Hospital.Repositories;
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
                .AddTransient<DoctorMenu>()
                .AddTransient<PatientMenu>()
                .AddTransient<AdminMenu>()
                .AddSingleton<MenuFactory>()
                .BuildServiceProvider();

            MenuState.Instance.Push(new LoginMenu)
        }
    }
}
