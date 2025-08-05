using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ServiceFactory
    {

        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IService CreateHospitalService()
        {
            return ActivatorUtilities.CreateInstance<HospitalService>(_serviceProvider);
        }
    }
}
