using Bizagi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bizagi.Services.Definition
{
    public interface IRuleValidator
    {
        List<Response> Validate(XElement doc);
    }
}
