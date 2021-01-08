using GraphQL.Types;
using GraphQL_Nsn.Graph.Type;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Mutation
{
    public class TeamMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<TeamGType>("addTeam",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<IntGraphType> { Name = "logoId" }
                    )
                , resolve: context =>
                      {
                          var _id = context.GetArgument<int>("id");
                          var _name = context.GetArgument<string>("name");
                          var _logoId = context.GetArgument<int>("logoId");
                          var teamRepo = (IGenericRepository<Team>)sp.GetService(typeof(IGenericRepository<Team>));

                          Team team = new Team()
                          {
                              Id = _id,
                              Name = _name,
                              LogoId = _logoId
                          };
                          teamRepo.Insert(team);
                          return team;
                      });
        }
    }
}
