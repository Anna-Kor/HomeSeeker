# How to add migration and update database?

You must specify the startup project to add a migration e.g.<br>
`dotnet ef --startup-project ../HomeSeeker_API/ migrations add InitialCreate`<br> - adding new migration
`dotnet ef --startup-project ../HomeSeeker_API/ database update` - updating database

* Startup project - HomeSeeker_API
* Target project - Data
