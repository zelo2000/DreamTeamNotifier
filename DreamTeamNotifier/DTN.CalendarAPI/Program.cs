using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace DTN.CalendarAPI
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*string jsonFile = "credentials.json";
            string calendarId = @"dreamteamnotifier@dreamteamnotifier.iam.gserviceaccount.com";
            string[] scopes = {CalendarService.Scope.Calendar};
            ServiceAccountCredential credential;

            using (var stream = new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var config =
                    Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(config.ClientEmail)
                    {
                        Scopes = scopes
                    }.FromPrivateKey(config.PrivateKey));
            }
            
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DreamTeamNotifier"
            });

            var calendar = service.Calendars.Get(calendarId).Execute();
            
            Console.WriteLine($"Calendar name:\n{calendar.Summary}");

            var listRequest = service.Events.List(calendarId);
            listRequest.TimeMin = DateTime.Today;
            //listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = listRequest.Execute();
            Console.WriteLine(events.Items.Count);
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
            }*/

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
    }
}