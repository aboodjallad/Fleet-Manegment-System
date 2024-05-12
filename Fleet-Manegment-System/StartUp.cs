using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;


namespace Fleet_Manegment_System
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200") 
                                       .AllowAnyMethod()
                                       .AllowAnyHeader());
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                };
            });
            services.AddWebSockets(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(120); 
            });

            //services.AddRazorPages();
           // services.AddServerSideBlazor();
            //services.AddAuthorization();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseWebSockets();

           /* app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await WebSocketManager.HandleWebSocketCommunication(webSocket, context);
                }
                else
                {
                    await next.Invoke();
                }
            });*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapBlazorHub();
               // endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}


