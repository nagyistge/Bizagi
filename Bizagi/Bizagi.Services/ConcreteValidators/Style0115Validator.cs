using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Bizagi.Util;

namespace Bizagi.Services.ConcreteValidators
{
    public class Style0115Validator : IRuleValidator
    {
        public List<Response> Validate(XElement doc)
        {
            XNamespace ns = "http://www.wfmc.org/2008/XPDL2.1";
            var intermediateEvents = (from intermediateEvent in doc.Descendants(ns + "IntermediateEvent") 
                                       select intermediateEvent);

            return (from item in intermediateEvents
                select item.Parent.Parent
                into activityElement
                let label = activityElement.Attribute("Name").Value
                where string.IsNullOrEmpty(label)
                select
                    new Response
                    {
                        ElementId = Guid.Parse(activityElement.Attribute("Id").Value),
                        ElementName = label,
                        ElementXpath = activityElement.GetAbsoluteXPath(),
                        Message = "El elemento viola la regla Style 0105"
                    }).ToList();
        }
    }
}
