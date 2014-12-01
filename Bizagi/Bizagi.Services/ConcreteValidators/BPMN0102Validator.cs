using System;
using System.Linq;
using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System.Collections.Generic;
using System.Xml.Linq;
using Bizagi.Util;

namespace Bizagi.Services.ConcreteValidators
{
    public class Bpmn0102Validator : IRuleValidator
    {
        public List<Error> Validate(XElement doc)
        {
            var responses = new List<Error>();
            XNamespace ns = "http://www.wfmc.org/2008/XPDL2.1";
            foreach (var workFlowProcess in doc.Descendants(ns + "WorkflowProcess"))
            {
                var activities = from activity in workFlowProcess.Descendants(ns + "Activity")
                                 let childEvent = activity.Element(ns + "Event")
                                 where childEvent == null || (childEvent != null && childEvent.Element(ns + "EndEvent") == null)
                                 select activity;

                if (!activities.Any()) continue;


                responses.AddRange(from activity in activities
                    let transitions =
                        (from transition in workFlowProcess.Descendants(ns + "Transition") select transition)
                    let activityId = activity.Attribute("Id").Value
                    let correspondingTransition =
                        transitions.FirstOrDefault(t => t.Attribute("From").Value == activityId)
                    where correspondingTransition == null
                    select new Error
                    {
                        ElementId = Guid.Parse(activityId),
                        ElementName = activity.Attribute("Name").Value,
                        ElementXpath = activity.GetAbsoluteXPath(),
                        Message = "El elemento viola la regla BPMN 0102"
                    });
            }

            return responses;

        }
    }
}
