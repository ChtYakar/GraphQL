using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using GraphQL_Nsn.Graph.Mutation;
using GraphQL_Nsn.Graph.Query;
using GraphQL_Nsn.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Schema
{
    public class LiveScoreSchema : GraphQL.Types.Schema, ISchema
    {
        public LiveScoreSchema(IDependencyResolver resolver):base(resolver)
        {            
            Mutation = resolver.Resolve<AddMatchesMutation>();
            Query = resolver.Resolve<MatchesQuery>();
            //Subscription = resolver.Resolve<MainSubscription>();
        }
    }
}
