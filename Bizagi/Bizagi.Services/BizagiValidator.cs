using Bizagi.Domain.Model;
using Bizagi.Services.ConcreteValidators;
using Bizagi.Services.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bizagi.Services
{
    public class BizagiValidator
    {
        private readonly List<IRuleValidator> validators;
        public BizagiValidator()
        {
            validators = new List<IRuleValidator>() 
            {
                new BPMN0102Validator(),
                new Style0104Validator(),
                new Style0115Validator(),
                new Style0122Validator(),
                new Style0123Validator()
            };
        }
        public List<Response> Validate(XElement doc) 
        {            
            var responses = new List<Response>();
            foreach (var item in validators)
            {
                var response = item.Validate(doc);
                responses.AddRange(response);
            }

            return responses;
        }
    }   
}
