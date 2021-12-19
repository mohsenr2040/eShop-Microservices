using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Database
{
    public interface IMongoOrderContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
