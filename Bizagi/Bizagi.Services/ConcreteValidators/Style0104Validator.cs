using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Bizagi.Util;

namespace Bizagi.Services.ConcreteValidators
{
    public class Style0104Validator : IRuleValidator
    {
        public List<Response> Validate(XElement doc)
        {
            var responses = new List<Response>();
            XNamespace ns = "http://www.wfmc.org/2008/XPDL2.1";
            var processes = (from proccess in doc.Descendants(ns + "WorkflowProcess")
                                      select proccess);

            foreach (var activities in processes.Select(process => (from activity in process.Descendants(ns + "Activity") 
                select activity)))
            {
                responses.AddRange(
                    from activity in activities
                    let activityName = activity.Attribute("Name").Value
                    where !string.IsNullOrEmpty(activityName)
                    let count = activities.Count(a => a.Attribute("Name").Value == activityName)
                    where count > 1
                    select
                        new Response
                        {
                            ElementId = Guid.Parse(activity.Attribute("Id").Value),
                            ElementName = activity.Attribute("Name").Value,
                            ElementXpath = activity.GetAbsoluteXPath(),
                            Message = "El elemento viola la regla Style 0104. Actividad con nombre repetido"
                        });
            }

            return responses;
        }
    }
}
