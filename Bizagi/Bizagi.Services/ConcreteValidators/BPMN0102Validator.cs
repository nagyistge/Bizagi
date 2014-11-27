using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bizagi.Services.ConcreteValidators
{
    public class BPMN0102Validator : IRuleValidator
    {
        public List<Response> Validate(XElement doc)
        {
            return new List<Response>();
        }
    }
}
