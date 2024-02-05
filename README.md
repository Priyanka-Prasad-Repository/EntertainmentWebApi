Created a movie enteratinment restful api.
Had a docker running with sql server running in a container.All the connection strings are mentioned in the configuration.

Commands to create sql server 
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Admin@123" `
   -p 1433:1433 --name sql1 --hostname sql1 `
   -d `
   mcr.microsoft.com/mssql/server:2022-latest
