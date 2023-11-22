using ImageSaveToDatabase.Data;
using ImageSaveToDatabase.Entities;
using ImageSaveToDatabase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageSaveToDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProfileService _profileService;

        public TeachersController(ApplicationDbContext context, IProfileService profileService)
        {
            _context = context;
            _profileService = profileService;
        }
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromForm]ProfileTeacher profileTeacher)
        {
            ProfileTeacher teacher = new ProfileTeacher()
            {
                Name = profileTeacher.Name,
                ImageUrl = await _profileService.CreateAvatarAsync(profileTeacher.Image)
            };

            await _context.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);
        }
    }
}
