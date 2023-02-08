using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.Dialog;
using OmegaFY.Blog.Maui.App.Infra.Extensions;

namespace OmegaFY.Blog.Maui.App.Application.PipelineBehaviors;

public class RequiresStrongConnectionBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult>, IRequiresStrongConnection
{
    private readonly IConnectivity _connectivity;

    private readonly IDialogProvider _dialogProvider;

    public RequiresStrongConnectionBehavior(IConnectivity connectivity, IDialogProvider dialogProvider)
    {
        _connectivity = connectivity;
        _dialogProvider = dialogProvider;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        bool isStrongConnection = await _dialogProvider.DisplayAlertAsync(new("T", "M"), () => !_connectivity.IsStrongConnection());

        if (!isStrongConnection) return default; // Sem wifi result e user desistiu de tentar novamente

        return await next();
    }
}