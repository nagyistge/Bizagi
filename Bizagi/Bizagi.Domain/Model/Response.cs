using System.Collections.Generic;
using System.Linq;

namespace Bizagi.Domain.Model
{
    public class Response
    {
        public List<Error> Errors { get; set; }
        public bool Successful {
            get { return !Errors.Any(); }
        }
    }
}
