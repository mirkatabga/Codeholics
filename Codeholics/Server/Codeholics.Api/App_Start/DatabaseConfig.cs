﻿namespace Codeholics.Api
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeholicsDbContext, Configuration>());
            
            /*CodeholicsDbContext.Create().Database.Initialize(true);*/
        }
    }
}