using GraphQL_Nsn.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Models
{
    [Serializable]
    [BsonIgnoreExtraElements]
    public class BaseEntity : IEntity
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
