using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
         DateTime InsertTime { get; set; } 
         DateTime? UpdateTime { get; set; }
         bool IsDeleted { get; set; } 
         DateTime? DeleteTime { get; set; }
    }
}
