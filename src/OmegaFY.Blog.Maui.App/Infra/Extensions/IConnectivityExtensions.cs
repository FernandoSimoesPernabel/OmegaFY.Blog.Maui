namespace OmegaFY.Blog.Maui.App.Infra.Extensions;

public static class IConnectivityExtensions
{
    public static bool HasStrongConnection(this IConnectivity connectivity)
    {
        return connectivity.HasInternet() 
            && (connectivity.ConnectionProfiles.Contains(ConnectionProfile.WiFi) || connectivity.ConnectionProfiles.Contains(ConnectionProfile.Ethernet));
    }

    public static bool HasInternet(this IConnectivity connectivity) => connectivity.NetworkAccess == NetworkAccess.Internet;
}