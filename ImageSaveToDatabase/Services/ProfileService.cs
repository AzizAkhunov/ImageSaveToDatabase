using ImageSaveToDatabase.Data;
using Microsoft.AspNetCore.Http;

namespace ImageSaveToDatabase.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProfileService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async ValueTask<string> CreateAvatarAsync(IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName);

            var path = "/Images/" + Guid.NewGuid() + "." + extension;

            string fullPath = _environment.WebRootPath + path;

            using (FileStream file = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(file);
            }

            return path;
        }
    }
}
