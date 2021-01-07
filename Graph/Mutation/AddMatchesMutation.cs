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
    public class AddMatchesMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<MatchesGType>("addMatch",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Id" },
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "HomeTeamId" },
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "AwayTeamId" },
               new QueryArgument<StringGraphType> { Name = "Score" },
               new QueryArgument<StringGraphType> { Name = "Stadium" }
            ),
            resolve: context =>
            {
                var Id = context.GetArgument<int>("id");
                var homeTeamId = context.GetArgument<int>("homeTeamId");
                var awayTeamId = context.GetArgument<int>("awayTeamId");
                var score = context.GetArgument<string>("score");
                var stadium = context.GetArgument<string>("stadium");

                var mRepository = (IGenericRepository<Matches>)sp.GetService(typeof(IGenericRepository<Matches>));

                var foundCountry = mRepository.GetById(Id);

                var newMatch = new Matches
                {
                    Id = Id,
                    AwayTeamId = awayTeamId,
                    HomeTeamId = homeTeamId,
                    Score = score,
                    Stadium = stadium
                };

                var addedM = mRepository.Insert(newMatch);
                return addedM;

            });
        }
    }
}
