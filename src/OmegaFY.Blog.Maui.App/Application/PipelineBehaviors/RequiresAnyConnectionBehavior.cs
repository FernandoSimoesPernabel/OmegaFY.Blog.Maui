using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.Dialogs;
using OmegaFY.Blog.Maui.App.Infra.Extensions;

namespace OmegaFY.Blog.Maui.App.Application.PipelineBehaviors;

public class RequiresAnyConnectionBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult>, IRequiresAnyConnection
{
    private readonly IConnectivity _connectivity;

    private readonly IDialogProvider _dialogProvider;

    public RequiresAnyConnectionBehavior(IConnectivity connectivity, IDialogProvider dialogProvider)
    {
        _connectivity = connectivity;
        _dialogProvider = dialogProvider;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        bool hasInternet = await _dialogProvider.DisplayAlertAsync(new("T", "M"), () => !_connectivity.HasInternet());

        if (!hasInternet) return default; // Sem internet result e user desistiu de tentar novamente

        return await next();
    }
}