using Microsoft.AspNetCore.Components;
using OneMessage.Application.Models;
using OneMessage.Pages.Shared;

namespace OneMessage.Pages;
public partial class Dashboard
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout.User;
}
