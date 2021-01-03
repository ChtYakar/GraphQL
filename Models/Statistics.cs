using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    public class Statistics : BaseEntity
    {
        public int PlayerId { get; set; }
        public int Goal { get; set; }
        public int RedCard { get; set; }
        public int YellowCard { get; set; }
        public int SavedGoal { get; set; }
    }
}
