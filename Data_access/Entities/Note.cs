using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Entities
{
    internal class Note
    {
        public int ID { get; set; }
        public string MessageNote { get; set; }
        public DateTime Date { get; set; }
    }
}
