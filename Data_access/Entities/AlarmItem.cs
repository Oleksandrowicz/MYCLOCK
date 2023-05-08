using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Entities
{
    public class AlarmItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public override string ToString()
        {
            return $"{Time.ToString(@"HH:mm")}\n{Title}";
        }
    }
}
