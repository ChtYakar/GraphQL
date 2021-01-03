using GraphQL.Types;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Type
{
    public class PlayerGType : ObjectGraphType<Player>
    {
        public PlayerGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Position, type: typeof(IntGraphType));

            Field<ListGraphType<StastisticsGType>>("Player Statistics", resolve: context =>
            {
                IGenericRepository<Statistics> statsRepo = (IGenericRepository<Statistics>)provider.GetService(typeof(IGenericRepository<Statistics>));
                return statsRepo.GetAll().Where(s => s.PlayerId == context.Source.Id);
            });
        }
    }
}
