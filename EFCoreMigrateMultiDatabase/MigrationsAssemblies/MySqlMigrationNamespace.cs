namespace EFCoreMigrateMultiDatabase.MigrationsAssemblies
{
    public class MySqlMigrationNamespace:IMigrationNamespace
    {
        public string GetNamespace()
        {
            return "EFCoreMigrateMultiDatabase.Migrations.MySql";
        }
    }
}
