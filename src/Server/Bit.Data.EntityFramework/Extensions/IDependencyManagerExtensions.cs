﻿using System;
using Bit.Data.Contracts;
using Bit.Data.EntityFramework.Implementations;
using System.Data.Entity;
using Bit.Data.Implementations;

namespace Bit.Core.Contracts
{
    public static class IDependencyManagerExtensions
    {
        public static IDependencyManager RegisterEfDbContext<TDbContext>(this IDependencyManager dependencyManager)
            where TDbContext : DbContext
        {
            if (dependencyManager == null)
                throw new ArgumentNullException(nameof(dependencyManager));

            dependencyManager.Register<TDbContext, TDbContext>(overwriteExciting: false);
            dependencyManager.Register<IDataProviderSpecificMethodsProvider, EfDataProviderSpecificMethodsProvider>(lifeCycle: DependencyLifeCycle.SingleInstance, overwriteExciting: false);
            dependencyManager.Register<EfDataProviderSpecificMethodsProvider, EfDataProviderSpecificMethodsProvider>(lifeCycle: DependencyLifeCycle.SingleInstance, overwriteExciting: false);
            dependencyManager.Register<IUnitOfWork, DefaultUnitOfWork>(lifeCycle: DependencyLifeCycle.InstancePerLifetimeScope, overwriteExciting: false);

            return dependencyManager;
        }
    }
}
