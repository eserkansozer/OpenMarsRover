using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using System.Web.Mvc;

namespace MarsRoverUI.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .LifestyleTransient());
        }
    }
}