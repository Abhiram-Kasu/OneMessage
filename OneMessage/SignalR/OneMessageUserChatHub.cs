using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using OneMessage.Application.Database;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

namespace OneMessage.SignalR;

public class OneMessageUserChatHub : Hub
{
    private readonly DatabaseContext db;
    private static readonly ConcurrentDictionary<string, int> NumUserMappings = new();

    public OneMessageUserChatHub(DatabaseContext db)
    {
        this.db = db;
    }
    public async Task SubscribeToUser(string groupId)
    {
        
        await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        NumUserMappings.AddOrUpdate(groupId, 1, 
            (_, num) => num + 1);
        
        await Clients.Group(groupId).SendAsync("UpdateNumSubscribers", NumUserMappings[groupId]);
    }
    public async Task UnsubscribeFromUser(string groupId)
    {
        
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        NumUserMappings[groupId]--;
        await Clients.Group(groupId).SendAsync("UpdateNumSubscribers", NumUserMappings[groupId]);
        if(NumUserMappings[groupId] <= 0)
            NumUserMappings.Remove(groupId, out _);
    }

    public async Task SendMessage(string groupId, string message)
    {
        await Clients.OthersInGroup(groupId).SendAsync("RecieveMessage", message);
    }
    
}
