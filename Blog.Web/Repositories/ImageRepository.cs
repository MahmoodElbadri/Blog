using Blog.Web.Models.SettingsModel;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using System.Net;

namespace Blog.Web.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly Cloudinary _cloudinary;

    public ImageRepository(IOptions<CloudinarySettings> cloudinaryOptions)
    {
        var settings = cloudinaryOptions.Value;
        var account = new Account(cloud: settings.CloudName, apiKey: settings.ApiKey, apiSecret: settings.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(image.FileName, image.OpenReadStream()),
            DisplayName = image.FileName
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        return uploadResult?.SecureUrl?.ToString();
    }
}
