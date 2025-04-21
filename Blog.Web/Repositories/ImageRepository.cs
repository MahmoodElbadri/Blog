
using CloudinaryDotNet;

namespace Blog.Web.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly IConfiguration _configuration;
    private readonly Account _account;

    public ImageRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
        _account = new Account(_configuration.GetSection("CloudName")["CloudName"],
            _configuration.GetSection("CloudName")["ApiKey"],
            _configuration.GetSection("CloudName")["ApiSecret"]);
    }
    public Task<string> UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }
}
