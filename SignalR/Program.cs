using SignalR.Hubs;
using SignalR.WorkerServices;

namespace SignalR
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddSignalR(hubOptions =>
			{
				hubOptions.EnableDetailedErrors = true;
			});

			builder.Services.AddHostedService<MessageBrokerPubSubBroker>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<MessageBrokerHub>("/messageBroker");
			});

			app.Run();
		}
	}
}