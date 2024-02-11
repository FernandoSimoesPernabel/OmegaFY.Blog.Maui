using MediatR;
using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public sealed class MyDashboardViewModel : BaseViewModel
{
    public MyDashboardViewModel(IMediator mediator) : base(mediator, "Meu Dashboard") { }
}