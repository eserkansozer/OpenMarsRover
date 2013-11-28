using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using MarsRover.Services;
using MarsRover.ORM;

namespace MarsRover.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            //container.Register(Classes.FromThisAssembly()
            //          .Where(type => type.Namespace.Equals("MarsRover.Services"))                       
            //          .WithService.DefaultInterfaces()
            //          .LifestyleTransient());

            container.Register(
            Component.For<IRoverManager>().ImplementedBy<RoverManager>(),
            Component.For<IRoverCommander>().ImplementedBy<RoverCommander>(),
            Component.For<IInputParser>().ImplementedBy<InputParser>(),
            Component.For<IMarsRoverDbContext>().ImplementedBy<MarsRoverDbContext>(),
            Component.For<IMarsRoverDbAccessor>().ImplementedBy<MarsRoverDbAccessor>()
            );
        }
    }
}