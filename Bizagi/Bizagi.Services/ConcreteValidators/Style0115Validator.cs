﻿using Bizagi.Domain.Model;
using Bizagi.Services.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bizagi.Util;

namespace Bizagi.Services.ConcreteValidators
{
    public class Style0115Validator : IRuleValidator
    {
        public List<Response> Validate(XElement doc)
        {
            var responses = new List<Response>();
            XNamespace ns = "http://www.wfmc.org/2008/XPDL2.1";
            var intermediateEvents = (from intermediateEvent in doc.Descendants(ns + "IntermediateEvent") 
                                       select intermediateEvent);

            foreach (var item in intermediateEvents)
            {
                var activityElement = item.Parent.Parent;
                var label = activityElement.Attribute("Name").Value;
                if (string.IsNullOrEmpty(label))
                { 
                    var response = new Response
                    {
                        ElementId = Guid.Parse(activityElement.Attribute("Id").Value),
                        ElementName = label,
                        ElementXpath = activityElement.GetAbsoluteXPath(),
                        Message = "El elemento viola la regla Style 0105"
                    };

                    responses.Add(response);
                }
            }

            return responses;
        }
    }
}