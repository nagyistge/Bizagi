using Bizagi.Domain.Model;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bizagi.Services.Definition
{
    public interface IRuleValidator
    {
        List<Response> Validate(XElement doc);
    }
}
