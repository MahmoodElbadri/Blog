namespace Blog.Web.Repositories;

public interface IImageRepository
{
    Task<string> UploadImageAsync(IFormFile image);
}
