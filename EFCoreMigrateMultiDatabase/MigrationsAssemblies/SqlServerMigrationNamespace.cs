namespace EFCoreMigrateMultiDatabase.MigrationsAssemblies
{
    public class SqlServerMigrationNamespace:IMigrationNamespace
    {
        public string GetNamespace()
        {
            return "EFCoreMigrateMultiDatabase.Migrations.SqlServer";
        }
    }
}
