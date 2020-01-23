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
    DateTime TimeStamp
    {
      get
      {
        return DateTime.Now;
      }
    }

    public PixelController(FileContentResult pixelResponse)
    {
      this.pixelResponse = pixelResponse;
    }

    public IActionResult get()
    {
      var parameters = Request.Query.Keys.ToDictionary(k => k, k => Request.Query[k]);
      string parametersString = Request.QueryString.ToString();

      var headers = Request.Headers.Keys.ToDictionary(k => k, k => Request.Query[k]);
      var bla = Request.Headers.ToList();

      Task.Factory.StartNew((data) =>
      {
        // var dataDictionary = data as IDictionary<string, StringValues>;
        using (System.IO.StreamWriter writer = System.IO.File.AppendText("pixel.log"))
        {
          string line = "";
          line += TimeStamp;
          line += parametersString;
          foreach (var l in bla)
          {
            line += l.ToString();
          }
          writer.WriteLine(line);
        }

      }, parameters.Union(headers).ToDictionary(k => k.Key, v => v.Value)).ConfigureAwait(false);

      //return pixel
      return pixelResponse;
    }

  }
}
