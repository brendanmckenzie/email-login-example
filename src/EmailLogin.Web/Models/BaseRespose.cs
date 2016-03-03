using System.Collections.Generic;

namespace EmailLogin.Web.Models
{
    public abstract class BaseRespose
    {
        public bool Success { get { return Errors == null; } }

        public IEnumerable<string> Errors { get; set; }
    }
}