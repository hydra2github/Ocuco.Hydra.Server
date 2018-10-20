Reference : https://www.learnentityframeworkcore.com/walkthroughs/existing-database

Hydra specifics
---------------

open a CMD, "Run as Administrator" :

> cd C:\OCUCO\OCUCOHUB\Ocuco.Hydra\Support\EFCoreScaffoldCatalogDb

and run : 

> dotnet ef dbcontext scaffold "Server=tcp:hydrahubdb.database.windows.net,1433;Initial Catalog=hydradbcatalog;Persist Security Info=False;User ID=ocuco;Password=dept_star!azure1;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "hydradbcatalogContext"

and 

> dotnet ef dbcontext scaffold "Server=tcp:hydrahubdb.database.windows.net,1433;Initial Catalog=hydradbcatalog;Persist Security Info=False;User ID=ocuco;Password=dept_star!azure1;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -d -o ModelWithDataAnnotations -c "hydradbcatalogContext"
