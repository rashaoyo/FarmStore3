using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3
{
    public class FarmStore3Configuration
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string ConnectionSTring { get; set; }
    }
}
