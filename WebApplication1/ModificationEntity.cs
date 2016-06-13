using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication1
{
    public class ModificationEntity
    {
        public ModificationEntity()
        {
            changes = new Dictionary<string, string>();
        }

        public int objectId { get; set; }
        public string objectType { get; set; }
        public DateTime timeStamp { get; set; }
        public Dictionary<string, string> changes { get; set; }
    }
}