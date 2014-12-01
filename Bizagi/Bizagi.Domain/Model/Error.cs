using System;

namespace Bizagi.Domain.Model
{
    public class Error
    {
        public string Message { get; set; }
        public Guid ElementId { get; set; }
        public string ElementName { get; set; }
        public string ElementXpath { get; set; }
    }
}
