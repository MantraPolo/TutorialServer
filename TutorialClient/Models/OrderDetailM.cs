using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialServer.Models
{
    public class OrderDetailM
    {
        public long Id { get; set; }
        public long OrderDetailId { get; set; }
        public string SKU { get; set; }        
        public int Quantity { get; set; }

    }
}
