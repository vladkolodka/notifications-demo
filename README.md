# notifications-demo

To add migration, use the following command (powershell):

```
cd ./Infrastructure
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet ef migrations add MigrationName --startup-project ../ApiServer
```