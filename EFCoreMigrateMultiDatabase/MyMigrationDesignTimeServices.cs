﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;

namespace EFCoreMigrateMultiDatabase
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/ef/core/cli/services
    /// </summary>
    public class MyMigrationDesignTimeServices: IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMigrationsScaffolder, MyMigrationsScaffolder>();
        }
    }
}
