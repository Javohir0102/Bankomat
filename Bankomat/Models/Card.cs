using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Card
    {
        public decimal Balance { get; set; }

        public bool IsSmsOn { get; set; }

        public string Phone { get; set; }

        public string CardNumber { get; set; }

        public string Password { get; set; }
    }
}
