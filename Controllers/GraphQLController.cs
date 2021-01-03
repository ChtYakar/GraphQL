using GraphQL;
using GraphQL.Types;
using GraphQL_Nsn.Graph.Schema;
using GraphQL_Nsn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private IDocumentExecuter _documentExecuter;
        private LiveScoreSchema _schema;
        private readonly IServiceProvider _provider;
        public GraphQLController(IDocumentExecuter documentExecuter, LiveScoreSchema schema, IServiceProvider provider)
        {
            _provider = provider;
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var inputs = query.Variables == null ? default(Inputs) : query.Variables.ToString().ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                OperationName = query.OperationName,
                Inputs = inputs
            };

            var result =  _documentExecuter.ExecuteAsync(executionOptions).Result;

            if (result.Errors?.Count > 0)
            {
                var graphQLErrors = new List<string>();
                var errors = result.Errors.GetEnumerator();
                while (errors.MoveNext())
                {
                    graphQLErrors.Add(errors.Current.InnerException != null ? errors.Current.InnerException.Message : errors.Current.Message);
                }

                return BadRequest(new { result, graphQLErrors });
            }
            return Ok(result);
        }
    }
}
