namespace Codeholics.Api
{
    using Codeholics.Data;
    using Codeholics.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeholicsDbContext, Configuration>());
            //CodeholicsDbContext.Create().Database.Initialize(true);
        }
    }
}