using Coravel;
using Coravel.Events.Interfaces;
using OneMessage.Application.Events;
using OneMessage.Application.Events.Listeners;

namespace OneMessage.Application.Startup;
public static class Events
{
    public static IServiceProvider RegisterEvents(this IServiceProvider services)
    {
        IEventRegistration registration = services.ConfigureEvents();

        // add events and listeners here
        registration
            .Register<UserCreated>()
            .Subscribe<EmailNewUser>();

        return services;
    }
}
