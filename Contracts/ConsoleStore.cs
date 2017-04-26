using System;
using Contracts.Abstract;

namespace Contracts
{
    public class ConsoleStore : IStoreWriter
    {
        private readonly string _someSetting;

        public ConsoleStore(IApplicationSettings appSettings)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            _someSetting = appSettings.GetValue("restfulServiceUri");
        }

        public void Write(string value)
        {
            // Handle writing to screen
            Console.WriteLine(value);
        }
    }
}