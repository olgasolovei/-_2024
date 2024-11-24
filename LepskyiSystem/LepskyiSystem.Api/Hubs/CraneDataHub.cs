using LepskyiSystem.Api.Services;
using LepskyiSystem.Dto.AnalyzeCraneDto;
using Microsoft.AspNetCore.SignalR;

namespace LepskyiSystem.Api.Hubs
{
    public sealed class CraneDataHub : Hub
    {

        public CraneDataHub()
        {

        }

        public void OnDataAdded(AnalyzedCraneDataDto craneData)
        {
            Clients.All.SendAsync("CraneDataMessage", craneData);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected New User");
            return base.OnConnectedAsync();
        }
    }
}
