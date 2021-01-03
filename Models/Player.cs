using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraphQL_Nsn.Enums.Enums;

namespace GraphQL_Nsn.Models
{
    public class Player : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
    }
}
