using Microsoft.AspNetCore.Components;
using OneMessage.Application.Models;

namespace OneMessage.Pages.Shared;
public partial class NavMenu
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout?.User;
}
