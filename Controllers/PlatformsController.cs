using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Model;

namespace PlatformService.Controllers

{
  [Route("api/[controller]")]
  [ApiController]
  
   public class PlatformController : Controller
   {
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepository repository , IMapper mapper)
      {
      _repository = repository;
      _mapper = mapper; 
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
      System.Console.WriteLine("--> Getting Platforms...");
      
      var platformItem = _repository.GetAllPlatforms();

      return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }


    [HttpGet("{id}" , Name = "GetPlatformById")]

    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {

      var platformItem = _repository.GetPlatformById(id);

      if(platformItem != null)
      {
        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
      }

      return NotFound();
      
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {

      var platformModel = _mapper.Map<Platform>(
        platformCreateDto
      );
      _repository.CreatePlatForm(platformModel);
      _repository.SaveChanges();

      var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

      return CreatedAtRoute(nameof(GetPlatformById) , new { Id = platformReadDto.Id} , platformReadDto );

    }

   }
}