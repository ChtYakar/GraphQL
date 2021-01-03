using GraphQL.Types;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Type
{
    public class StastisticsGType: ObjectGraphType<Statistics>
    {
        public StastisticsGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.PlayerId, type: typeof(IntGraphType));
            Field(x => x.RedCard,type: typeof(IntGraphType));
            Field(x => x.YellowCard, type: typeof(IntGraphType));
            Field(x => x.SavedGoal, type: typeof(IntGraphType));

            //resolver
            Field<PlayerGType>("player", resolve: context =>
            {
                IGenericRepository<Player> playerRepo = (IGenericRepository<Player>)provider.GetService(typeof(IGenericRepository<Player>));
                return playerRepo.GetById(context.Source.PlayerId);
            });
        }
    }
}
