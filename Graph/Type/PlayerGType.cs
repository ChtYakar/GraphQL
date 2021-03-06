﻿using GraphQL.Types;
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
            Field(x => x.Age, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Nationality,type: typeof(StringGraphType));
            Field(x => x.Position, type: typeof(IntGraphType));
            Field(x => x.TeamId, type: typeof(IntGraphType));
            Field<TeamGType>("Team", resolve: context =>
            {
                IGenericRepository<Team> teamRepo = (IGenericRepository<Team>)provider.GetService(typeof(IGenericRepository<Team>));
                return teamRepo.GetById(context.Source.TeamId);
            });
        }
    }
}
