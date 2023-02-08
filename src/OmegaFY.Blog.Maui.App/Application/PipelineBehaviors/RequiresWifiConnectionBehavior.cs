using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.Dialog;

namespace OmegaFY.Blog.Maui.App.Application.PipelineBehaviors;

public class RequiresWifiConnectionBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult>, IRequiresWifiConnection
{
    private readonly IConnectivity _connectivity;

    private readonly IDialogProvider _dialogProvider;

    public RequiresWifiConnectionBehavior(IConnectivity connectivity, IDialogProvider dialogProvider)
    {
        _connectivity = connectivity;
        _dialogProvider = dialogProvider;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        NetworkAccess currentNetworkAccess = _connectivity.NetworkAccess;
        IEnumerable<ConnectionProfile> connectionProfiles = _connectivity.ConnectionProfiles;

        if (currentNetworkAccess != NetworkAccess.Internet)
        {
            
        }


        if (request is IRequiresWifiConnection)
        {

        }

        if (connectionProfiles.Contains(ConnectionProfile.WiFi))
        {

        }

        if (currentNetworkAccess == NetworkAccess.Internet)
        {

        }

        if (request is IRequiresWifiConnection)
        {

        }

        return await next();
    }
}