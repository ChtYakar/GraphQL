using GraphQL.Types;
using GraphQL_Nsn.Graph.Type;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Query
{
    public class TeamsQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<TeamGType>>("teams",
               arguments: new QueryArguments(
                 new QueryArgument<IntGraphType> { Name = "id" }
               ),
               resolve: context =>
               {
                   var teamRepo = (IGenericRepository<Team>)sp.GetService(typeof(IGenericRepository<Team>));
                   var _id = context.GetArgument<int>("id");
                   if (_id > 0)
                   {
                       var team = teamRepo.GetById(_id);
                       List<Team> singleMatch = new List<Team>() { team };
                       return singleMatch;
                   }
                   var baseQuery = teamRepo.GetAll();
                   return baseQuery.ToList();
               });
        }
    }
}
