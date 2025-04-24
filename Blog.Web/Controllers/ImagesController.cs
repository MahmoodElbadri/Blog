using Blog.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Blog.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        this._imageRepository = imageRepository;
    }

    [HttpPost]
    public async Task<IActionResult> UploadAsync(IFormFile image)
    {
        var imageUrl = await _imageRepository.UploadImageAsync(image);
        if (imageUrl == null)
        {
            return Problem("Something went wrong", null, StatusCodes.Status500InternalServerError);
        }
        //return Ok(imageUrl);
        return new JsonResult(new { link = imageUrl });
    }
}
