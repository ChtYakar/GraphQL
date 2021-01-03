using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public object Variables { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            if (!string.IsNullOrWhiteSpace(OperationName))
            {
                builder.AppendLine($"OperationName = {OperationName}");
            }
            if (!string.IsNullOrWhiteSpace(NamedQuery))
            {
                builder.AppendLine($"NamedQuery = {NamedQuery}");
            }
            if (!string.IsNullOrWhiteSpace(Query))
            {
                builder.AppendLine($"Query = {Query}");
            }
            if (Variables != null)
            {
                builder.AppendLine($"Variables = {Variables.ToString()}");
            }
            return builder.ToString();
        }
    }
}
