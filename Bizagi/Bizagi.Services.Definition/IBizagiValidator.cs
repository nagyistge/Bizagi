using System.Collections.Generic;
using System.Xml.Linq;
using Bizagi.Domain.Model;

namespace Bizagi.Services.Definition
{
    public interface IBizagiValidator
    {
        Response Validate(XElement doc);
    }
}
