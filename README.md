# EFCoreMigrateMultiDatabase
EFCoreMigrateMultiDatabase
## step0
delete directory Migrations if exists
## step1
```shell
Add-Migration InitialCreate -Context MyDbContext -OutputDir Migrations\SqlServer -Args "--provider SqlServer"
```
## step2
```shell
Add-Migration InitialCreate -Context MyDbContext -OutputDir Migrations\MySql -Args "--provider MySql"
```
## step3
```shell
update-database -Args "--provider SqlServer"
```
## step4
```shell
update-database -Args "--provider MySql"
```