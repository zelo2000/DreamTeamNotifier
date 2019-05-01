using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace DTN.WebCalendarAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            try
            {
                new Program().Run().Wait();
            }
            catch (AggregateException exception)
            {
                foreach (var innerException in exception.InnerExceptions)
                {
                    Console.WriteLine($"ERROR: {innerException}");
                }
            }
            Console.WriteLine("The end🥕");
        }
        
        private async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("oauth_credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new [] { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents },
                    "user", CancellationToken.None, new FileDataStore("MyCalendar")
                );
            }
            
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "calendar api sample"
            });

            var events = await service.Events.List(credential.UserId).ExecuteAsync();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventsItem in events.Items)
                {
                    string when = eventsItem.Start.DateTime?.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventsItem.Start.Date;
                    }
                    
                    Console.WriteLine($"{eventsItem.Summary} ({when})");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}