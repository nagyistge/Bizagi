using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Linq;
using Bizagi.Services;
using Bizagi.Services.Definition;

namespace Bizagi.WebApi.Controllers
{
    public class BizagiValidatorController : ApiController
    {
        private readonly IBizagiValidator _validator;

        public BizagiValidatorController()
        {
            _validator = new BizagiValidator();
        }

        public async Task<HttpResponseMessage> PostFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new Exception();

            var provider = new MultipartMemoryStreamProvider();
            var result = new { files = new List<object>() };

            provider = await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.Contents.FirstOrDefault();
            if (file == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var reading = await file.ReadAsByteArrayAsync();
            var stream = new MemoryStream(reading);
            var response = _validator.Validate(XElement.Load(stream));

            return !response.Successful
                ? Request.CreateResponse(HttpStatusCode.BadRequest, response.Errors)
                : Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
