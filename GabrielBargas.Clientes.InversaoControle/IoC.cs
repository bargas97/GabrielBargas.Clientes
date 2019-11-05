using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.InversaoControle
{
    public class IoC
    {
        private static StandardKernel kernel;

        public static void Init()
        {
            kernel = new StandardKernel(new IoCModule());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }

        public static object Get(Type type)
        {
            return kernel.TryGet(type);
        }

        public static IEnumerable<object> GetAll(Type type)
        {
            return kernel.GetAll(type);
        }
    }
}
