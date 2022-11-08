using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumidorapi
{
    public class Item
    {
        public long Id { get; set; }
        public string? Nome { get; set; }

        public bool Feito { get; set; }
    }
}
