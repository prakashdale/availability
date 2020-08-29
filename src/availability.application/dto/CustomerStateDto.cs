using System;

namespace availability.application.dto
{
    public class CustomerStateDto
    {
        public string State { get; set; }
        public bool IsValid => State.Equals("valid", StringComparison.InvariantCultureIgnoreCase);
    }
}