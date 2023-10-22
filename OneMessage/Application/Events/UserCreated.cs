using Coravel.Events.Interfaces;
using OneMessage.Application.Models;

namespace OneMessage.Application.Events;
public class UserCreated : IEvent
{
    public User User { get; set; }

    public UserCreated(User user)
    {
        this.User = user;
    }
}
