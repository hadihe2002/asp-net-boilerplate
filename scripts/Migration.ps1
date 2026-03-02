dotnet ef migrations add User --project .\HadiDinner.Infrastructure\ --startup-project .\HadiDinner.Api\   

dotnet ef migrations remove -p .\HadiDinner.Infrastructure\ -s .\HadiDinner.Api\ 

dotnet ef database update First -p .\HadiDinner.Infrastructure\ -s .\HadiDinner.Api\