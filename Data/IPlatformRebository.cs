using PlatformService.Model;

namespace PlatformService.Data
{

  public interface IPlatformRepository
  {
     bool SaveChanges(); 

     IEnumerable<Platform> GetAllPlatforms();

    Platform GetPlatformById(int id);

    void CreatePlatForm(Platform plat);
     
  }
     
} 