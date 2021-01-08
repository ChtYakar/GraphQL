using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int LogoId { get; set; }
    }
}
