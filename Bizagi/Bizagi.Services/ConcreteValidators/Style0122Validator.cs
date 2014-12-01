using System;
using System.Linq;
using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System.Collections.Generic;
using System.Xml.Linq;
using Bizagi.Util;

namespace Bizagi.Services.ConcreteValidators
{
    public class Style0122Validator : IRuleValidator
    {
        public List<Error> Validate(XElement doc)
        {
            XNamespace ns = "http://www.wfmc.org/2008/XPDL2.1";
            var activities = from intermediateEvent in doc.Descendants(ns + "IntermediateEvent")
                             let triggerResultMessageElement = intermediateEvent.Element(ns + "TriggerResultMessage")
                             let triggerAttribute = intermediateEvent.Attribute("Trigger")
                             let catchThrowAttribute = triggerResultMessageElement.Attribute("CatchThrow")
                             let eventElement = intermediateEvent.Parent
                             where
                                 triggerResultMessageElement != null &&
                                 triggerAttribute != null &&
                                 (catchThrowAttribute == null || catchThrowAttribute.Value == "CATCH") &&
                                 triggerAttribute.Value == "Message" &&
                                 eventElement != null
                             select eventElement.Parent;

            return (from activity in activities
                    let activityId = activity.Attribute("Id").Value
                    let messageFlows = (from messageFlow in doc.Descendants(ns + "MessageFlow")
                                        where messageFlow.Attribute("Target").Value == activityId
                                        select messageFlow)
                    where !messageFlows.Any()
                    select new Error
                    {
                        ElementId = Guid.Parse(activityId),
                        ElementName = activity.Attribute("Name").Value,
                        ElementXpath = activity.GetAbsoluteXPath(),
                        Message = "El elemento viola la regla Style 0122"
                    }).ToList();
        }
    }
}
