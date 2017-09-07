using SaafiMobile.Core.Contracts.Services;
using Plugin.Connectivity;

namespace SaafiMobile.Core.Services.General
{
    public class ConnectionService : IConnectionService
    {
        public bool CheckOnline()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
