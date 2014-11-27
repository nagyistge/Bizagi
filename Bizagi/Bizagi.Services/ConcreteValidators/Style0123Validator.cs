using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bizagi.Services.ConcreteValidators
{
    public class Style0123Validator : IRuleValidator
    {
        public List<Response> Validate(XElement doc)
        {
            return new List<Response>();
        }
    }
}
