using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    public class Matches : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime StartDate { get; set; }
        public string Score { get; set; }
        public string Stadium { get; set; }
    }
}
