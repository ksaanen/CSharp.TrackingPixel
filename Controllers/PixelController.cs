using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pixel.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PixelController : ControllerBase
  {
    readonly FileContentResult pixelResponse;

    private string RemoteIpAddress
    {
      get
      {
        return HttpContext.Connection.RemoteIpAddress.ToString();
      }
    }

    private DateTime TimeStamp
    {
      get
      {
        return DateTime.Now;
      }
    }
    private string Path
    {
      get
      {
        return Request.Path;
      }
    }

    private string QueryParameters
    {
      get
      {
        return Request.QueryString.ToString();
      }
    }

    public PixelController(FileContentResult pixelResponse)
    {
      this.pixelResponse = pixelResponse;
    }

    public IActionResult get()
    {
        using (System.IO.StreamWriter writer = System.IO.File.AppendText("pixel.log"))
        {
          string line = $"TimeStamp: {TimeStamp}, ";
          line += $"RemoteIpAddress: {RemoteIpAddress}, ";
          line += $"Path: {Path}, ";
          line += $"QueryParameters: {QueryParameters}";
          writer.WriteLine(line);
        }

      //return pixel
      return pixelResponse;
    }

  }
}
