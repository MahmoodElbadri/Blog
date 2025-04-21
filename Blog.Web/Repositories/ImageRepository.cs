
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace Blog.Web.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly IConfiguration _configuration;
    private readonly Account _account;

    public ImageRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
        _account = new Account(_configuration.GetSection("Cloudinary")["CloudName"],
            _configuration.GetSection("Cloudinary")["ApiKey"],
            _configuration.GetSection("Cloudinary")["ApiSecret"]);
    }
    public async Task<string> UploadImageAsync(IFormFile image)
    {
        var client = new Cloudinary(_account);
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(image.FileName, image.OpenReadStream()),
            //UseFilename = true,
            //UniqueFilename = false,
            //Overwrite = true
            DisplayName = image.FileName
        };
        var uploadResult = await client.UploadAsync(uploadParams);
        if (uploadResult != null && uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return uploadResult.SecureUrl.ToString();
        }
        return null;
    }
}
