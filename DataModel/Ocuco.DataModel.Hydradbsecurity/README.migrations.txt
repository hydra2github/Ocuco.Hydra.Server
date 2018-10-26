- open a CMD

#################################################################################

- move to the main project directory : 
cd C:\OCUCO\Ocuco.Hydra.Server\Ocuco.Hydra\WebApps\Ocuco.Hydra.WebMVC21.V2

- Lists available migrations :
dotnet ef migrations list --context HydraContext
dotnet ef migrations list --context HydraSecurityContext

or 

- move to the specific db directory project : 
cd C:\OCUCO\Ocuco.Hydra.Server\Ocuco.Hydra\DataModel\Ocuco.DataModel.Hydradbsecurity

- Lists available migrations :
dotnet ef --startup-project ../../WebApps/Ocuco.Hydra.WebMVC21.V2 migrations list --context HydraContext
dotnet ef --startup-project ../../WebApps/Ocuco.Hydra.WebMVC21.V2 migrations list --context HydraSecurityContext

#################################################################################

- move to the specific db directory project : 
cd C:\OCUCO\Ocuco.Hydra.Server\Ocuco.Hydra\DataModel\Ocuco.DataModel.Hydradbsecurity

- initialize db
dotnet ef --startup-project ../../WebApps/Ocuco.Hydra.WebMVC21.V2 migrations add InitHydraSecurityContext --context HydraSecurityContext
dotnet ef --startup-project ../../WebApps/Ocuco.Hydra.WebMVC21.V2 database update --context HydraSecurityContext