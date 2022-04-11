using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSample.Domain.Infrasructure.Contracts
{
    public interface IIndexManager
    {
        public void SendIndexInfo(string[] indexes) { }
    }
}
