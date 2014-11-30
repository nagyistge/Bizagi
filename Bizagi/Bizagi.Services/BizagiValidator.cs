using Bizagi.Domain.Model;
using Bizagi.Services.ConcreteValidators;
using Bizagi.Services.Definition;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bizagi.Services
{
    using System.Linq;

    public class BizagiValidator
    {
        private readonly List<IRuleValidator> validators;
        public BizagiValidator()
        {
            validators = new List<IRuleValidator>() 
            {
                new Bpmn0102Validator(),
                new Style0104Validator(),
                new Style0115Validator(),
                new Style0122Validator(),
                new Style0123Validator()
            };
        }
        public List<Response> Validate(XElement doc) 
        {            
            var responses = new List<Response>();
            foreach (var response in this.validators.Select(item => item.Validate(doc)))
            {
                responses.AddRange(response);
            }

            return responses;
        }
    }   
}
