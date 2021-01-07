using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public int TeamId { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
    }
}
