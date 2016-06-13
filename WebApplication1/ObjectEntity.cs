using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication1
{
    public class ObjectEntity
    {
        public ObjectEntity()
        {
            properties = new Dictionary<string, string>();
        }

        public int objectId { get; set; }
        public string objectType { get; set; }
        public Dictionary<string, string> properties { get; set; }
    }
}
