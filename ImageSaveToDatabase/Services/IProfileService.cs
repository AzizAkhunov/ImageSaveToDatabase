namespace ImageSaveToDatabase.Services
{
    public interface IProfileService
    {
        ValueTask<string> CreateAvatarAsync(IFormFile formFile);
    }
}
