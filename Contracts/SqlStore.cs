using System;
using Contracts.Abstract;

namespace Contracts
{
    // TODO - implement 
    public class SqlStore : IStoreReader, IStoreWriter
    {
        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string value)
        {
            // Get connection string from appsettings etc.
            // Implement reading from sql
            throw new NotImplementedException();
        }
    }
}