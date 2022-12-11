# Backend 

Project containing all RestAPI controllers and Services with business logic.


## References

- DataRepository3
- Dtos

Everything is already configurated and should work as is.

## Extra configuration

### Adding another frontend app using backend

In order to allow another frontend app using this backend service, the host has to be added to
``AllowedCrossOrigin`` section in ``appsettings.json`` 

### Changing database server

<b> Important! </b>

DataRepository3 accepts only Mysql connection strings

1. Prepare connection string to new mysql instance
2. Change MainDb connection string in `appsettings.json`
3. Prepare and seed data using `dotnet ef migrations add Initialmigration`
4. Update database using `dotnet ef database update`