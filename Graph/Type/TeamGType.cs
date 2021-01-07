using GraphQL.Types;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Type
{
    public class TeamGType : ObjectGraphType<Team>
    {
        public TeamGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.LogoId, type: typeof(IntGraphType));
            Field<ListGraphType<PlayerGType>>("players", resolve: context =>
            {
                IGenericRepository<Player> playerRepo = (IGenericRepository<Player>)provider.GetService(typeof(IGenericRepository<Player>));
                return playerRepo.GetAll().Where(x => x.TeamId == context.Source.Id);
            });
        }
    }
}
