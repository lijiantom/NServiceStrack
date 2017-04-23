using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Host.ServiceHost
{
    public class HumanResourceHost : ServiceStack.AppHostBase
    {
        public HumanResourceHost() : base("HumanResource Service", typeof(Domain.Implement.HumanResourceServiceImp).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            // Register any dependencies your services use here.
        }
    }
}