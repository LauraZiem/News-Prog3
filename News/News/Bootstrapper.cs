using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using News.ViewModels;

namespace News
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var containerBuider = new ContainerBuilder();

            containerBuider.RegisterType<MainShell>();

            containerBuider.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(x => x.IsSubclassOf(typeof(ViewModel)));
            var container = containerBuider.Build();
            Resolver.Initialize(container);
        }
    }
}
