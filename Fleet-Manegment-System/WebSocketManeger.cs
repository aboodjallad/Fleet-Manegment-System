using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System
{
    public class WebSocketManager
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public static  async Task HandleWebSocketCommunication(WebSocket webSocket, HttpContext context)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                await BroadcastMessage(buffer, result.MessageType);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public static async Task BroadcastMessage(byte[] data, WebSocketMessageType messageType)
        {
            foreach (var pair in _sockets)
            {
                WebSocket socket = pair.Value;
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), messageType, true, CancellationToken.None);
                }
            }
        }
    }
}
