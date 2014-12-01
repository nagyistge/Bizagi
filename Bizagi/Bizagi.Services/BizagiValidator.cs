using Bizagi.Domain.Model;
using Bizagi.Services.ConcreteValidators;
using Bizagi.Services.Definition;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bizagi.Services
{
    using System.Linq;

    public class BizagiValidator : IBizagiValidator
    {
        private readonly List<IRuleValidator> _validators;
        public BizagiValidator()
        {
            _validators = new List<IRuleValidator>() 
            {
                new Bpmn0102Validator(),
                new Style0104Validator(),
                new Style0115Validator(),
                new Style0122Validator(),
                new Style0123Validator()
            };
        }
        public Response Validate(XElement doc) 
        {            
            var errors = new List<Error>();
            foreach (var response in _validators.Select(item => item.Validate(doc)))
            {
                errors.AddRange(response);
            }

            return new Response
            {
                Errors =  errors
            };
        }
    }   
}
