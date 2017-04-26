namespace Contracts.Abstract
{
    public interface IApplicationSettings
    {
        string GetValue(string setting);
    }
}