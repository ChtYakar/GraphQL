using GraphQL.Types;
using GraphQL_Nsn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Type
{
    public class MatchesGType : ObjectGraphType<Matches>
    {
        public MatchesGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType)).Description("Maç Id'si");
            Field(x => x.HomeTeamId, type: typeof(IntGraphType)).Description("Ev Sahibi Takım Id");
            Field(x => x.AwayTeamId, type: typeof(IntGraphType));
            Field(x => x.Score, type: typeof(StringGraphType));
            //Field<TeamGType>
        }
    }
}
