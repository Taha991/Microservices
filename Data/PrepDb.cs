using PlatformService.Model;

namespace PlatformService.Data

{

  public static class PrepDb
  {
      public static void PrepPopulation(IApplicationBuilder app)
      {
        using(var serviceScope = app.ApplicationServices.CreateScope())
        {
          SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
      }

      private static void SeedData(AppDbContext context)
      {
        if(!context.platforms.Any())
        {
          System.Console.WriteLine("--> Seeding data...");

          context.platforms.AddRange(
            new Platform(){
              Name = "DotNet" , 
              Publisher = "Microsoft",
              Cost= "Free"
            },
           new Platform(){
              Name = "Sql" , 
              Publisher = "Microsoft",
              Cost= "Free"
            },
              new Platform(){
              Name = "Kubernetes" , 
              Publisher = "Cloud Native",
              Cost= "Free"
            }
          );

          context.SaveChanges();
        }
        else
        {
            System.Console.WriteLine("--> We already have data");
        }
      }
  }
}