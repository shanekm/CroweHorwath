using System.Configuration;
using Contracts.Abstract;

namespace Contracts
{
    public class ConfigAppSettings : IApplicationSettings
    {
        public string GetValue(string setting)
        {
            return ConfigurationManager.AppSettings[setting];
        }
    }
}