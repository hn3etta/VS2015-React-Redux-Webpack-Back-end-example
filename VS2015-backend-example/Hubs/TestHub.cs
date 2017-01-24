// using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace BackendStarter.Hubs
{
	public class TestHub : Hub
	{
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public async Task Send(string message)
		{
			// await Clients.All.InvokeAsync("Send", $"{Context.User.Identity.Name}: {message}");
			await Clients.All.InvokeAsync("Send", $"[person]: {message}");
		}

		// public string Echo(string message)
		// {
		//   return message;
		// }

		// public void ThrowException(string message)
		// {
		//   throw new InvalidOperationException(message);
		// }

		// public Task InvokeWithString(string message)
		// {
		//   return Clients.Client(Context.Connection.ConnectionId).InvokeAsync("Message", message);
		// }
	}
}
