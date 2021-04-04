using MonkeySharp.Api.Models;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}