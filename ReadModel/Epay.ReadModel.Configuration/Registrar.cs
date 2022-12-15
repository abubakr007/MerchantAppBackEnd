﻿using Framework.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Epay.ReadModel.Configuration
{
    public class Registrar : RegistrarBase<Registrar>, IRegistrar
    {
        public override void Register(IServiceCollection services, string connectionString)
        {
            base.Register(services, connectionString);
        }
    }
}