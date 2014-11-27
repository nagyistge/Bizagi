using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Domain.Model
{
    public class Response
    {
        public string Message { get; set; }
        public Guid ElementId { get; set; }
        public string ElementName { get; set; }
        public string ElementXpath { get; set; }
    }
}
