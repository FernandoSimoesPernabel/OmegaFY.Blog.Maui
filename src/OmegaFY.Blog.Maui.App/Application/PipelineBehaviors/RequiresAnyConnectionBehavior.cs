using MediatR;
using OmegaFY.Blog.Maui.App.Application.Base;
using OmegaFY.Blog.Maui.App.Infra.Dialog;

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

    public Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}