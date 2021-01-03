using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Interfaces
{
    public interface IEntity
    {
        //ObjectId _id { get; set; }
        int Id { get; set; }
        DateTime CreateDate { get; set; }
    }
}
