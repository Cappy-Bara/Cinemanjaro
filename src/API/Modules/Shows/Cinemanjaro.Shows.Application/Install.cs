﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application
{
    public static class Install
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            return services;
        }
    }
}
