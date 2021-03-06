# Catalogs.API

## Runtime
- Microsoft.AspNetCore.App 3.1.6
- Microsoft.NETCore.App 3.1.6

## SQL Server
### First run
```bash
  docker pull mcr.microsoft.com/mssql/server:2017-latest;

  docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<SomeP4ssw0rd>' \
   -p 1433:1433 \
   --name sql-server17 \
   -v sqlvolume:/var/opt/mssql \
   -d mcr.microsoft.com/mssql/server:2017-latest
```
### Connect to instance
```bash
  docker exec -it sql-server17 "bash";

  /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<SomeP4ssw0rd>';

  1> CREATE LOGIN catalog_srv WITH PASSWORD = 'P@ssw0rd';
  2> CREATE DATABASE Store;
  3> GO
  1> USE Store;
  2> CREATE USER catalog_srv;
  3> GO
  1> EXEC sp_addrolemember N'db_owner', N'catalog_srv';
  2> GO
```
### Run/Stop container
```bash
  docker stop sql-server17;
  docker start sql-server17;
```
## EF/EF Tools
```bash
  # Install EF Tools
  dotnet tool install --global dotnet-ef;
  # If there are no migrations
  dotnet ef migrations add InitMigration;
  # Update DB
  dotnet ef database update
```
