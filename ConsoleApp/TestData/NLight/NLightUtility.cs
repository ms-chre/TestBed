using System.Net.Http;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Azure.EventGrid.Models;
using System.Threading.Tasks;

namespace ConsoleApp.TestData.NLight
{
    public class NLightUtility
    {
        private readonly HttpClient httpClient;

        public NLightUtility()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:7071/api/v1/nlight")
            };

        }

        public async Task SendHeartBeat()
        {

            var heartbeat = File.ReadAllText(@"TestData\NLight\heartbeat.json");
            var requestData = new StringContent(GetRequest(heartbeat));

            while (true)
            {
                var response = await httpClient.PostAsync("", requestData).ConfigureAwait(false);
                System.Console.WriteLine(response.StatusCode);
                await Task.Delay(2000);
            }


        }

        private string GetRequest(string data)
        {
            var dataEvent = JsonConvert.DeserializeObject<IotHubDeviceTelemetryEventData>(data);

            EventGridEvent eventGridEvent = new EventGridEvent()
            {
                Id = Guid.NewGuid().ToString(),
                Topic = "/SUBSCRIPTIONS/00F87579-7323-499B-BC72-C1FEDD43993D/RESOURCEGROUPS/CAMPUS-REFRESH/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/DIP-IOT-HUB",
                Subject = "devices/device-68",
                EventTime = DateTime.UtcNow,
                EventType = "Microsoft.Devices.DeviceTelemetry",
                Data = dataEvent
            };
            var eventGridEvents = new List<EventGridEvent>();
            eventGridEvents.Add(eventGridEvent);
            return JsonConvert.SerializeObject(eventGridEvents.ToArray());
        }


    }
}