using System;
using System.Collections.Generic;
using System.Text;

namespace DTN.Core.DTO
{
    public class Event
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public Event() { }

        public Event(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;
        }
    }
}
