using AtessToDoAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace AtessToDoAPI.Hubs
{
    public class TodoHub : Hub
    {
        public async Task  NotifyNewTodoItem()
        {
            await Clients.All.SendAsync("ReceiveNewTodoItem");
        }

    }
}
