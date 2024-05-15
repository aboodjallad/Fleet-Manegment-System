using Microsoft.AspNetCore.SignalR;


namespace Fleet_Manegment_System
{
    public class VehicleHub : Hub
    {
        public async Task SendVehicleUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveRouteHistoryUpdate", message);
        }
    }
}
