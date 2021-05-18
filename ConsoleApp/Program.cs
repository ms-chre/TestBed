using ConsoleApp.FinalData;
using ConsoleApp.TestData.NLight;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
                NLightUtility nLightUtility = new NLightUtility();
               await nLightUtility.SendHeartBeat();
        }

        public static void SendNLightDeviceHeartBeat()
        {

        }

        public static void ConsolidateDeviceData()
        {
            var mgmtApiData = File.ReadAllText(@"TestData\ManagementApi\onlydevice.json");
            List<ManagemetApiData> managemetApiData = JsonConvert.DeserializeObject<List<ManagemetApiData>>(mgmtApiData);
            List<ParsedData> managementApiParsedData = new List<ParsedData>();
            foreach (var item in managemetApiData)
            {
                if (!item.subtype.Equals("VergeSenseApiActor"))
                {
                    var temp = new ParsedData()
                    {
                        Name = item.name,
                        HardwareId = item.hardwareId,
                        BrandName = item.subtype

                    };
                    managementApiParsedData.Add(temp);
                }

            }

            using (TextWriter writer = new StreamWriter(@"C:\Users\CHRE\OneDrive - Microsoft\Development\TestData\mgmt.csv", false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(managementApiParsedData);
            }



            List<ParsedData> adtParsedData = new List<ParsedData>();
            foreach (string file in Directory.EnumerateFiles(@"TestData\Adt", "*.json"))
            {
                string buildingData = File.ReadAllText(file);
                var adtData = JsonConvert.DeserializeObject<ADTData>(buildingData);
                foreach (var item in adtData.digitalTwinsGraph.digitalTwins)
                {
                    var temp = new ParsedData()
                    {
                        Name = item.name,
                        HardwareId = item.hardwareId,
                        BrandName = item.brandName
                    };
                    adtParsedData.Add(temp);
                }

            }

            using (TextWriter writer = new StreamWriter(@"C:\Users\CHRE\OneDrive - Microsoft\Development\TestData\adt.csv", false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(adtParsedData);
            }

            using (TextWriter writer = new StreamWriter(@"C:\Users\CHRE\OneDrive - Microsoft\Development\TestData\mgmtApiOnly.csv", false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                var temp1 = managementApiParsedData;
                var temp2 = adtParsedData;
                csv.WriteRecords(temp1.Except(temp2, new DataItemComparator()).ToList()); // where values implements IEnumerable
            }

            using (TextWriter writer = new StreamWriter(@"C:\Users\CHRE\OneDrive - Microsoft\Development\TestData\adtOnly.csv", false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                var temp1 = managementApiParsedData;
                var temp2 = adtParsedData;
                csv.WriteRecords(temp2.Except(temp1, new DataItemComparator()).ToList()); // where values implements IEnumerable
            }

            using (TextWriter writer = new StreamWriter(@"C:\Users\CHRE\OneDrive - Microsoft\Development\TestData\common.csv", false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                var temp1 = managementApiParsedData;
                var temp2 = adtParsedData;
                csv.WriteRecords(temp2.Intersect(temp1, new DataItemComparator()).ToList()); // where values implements IEnumerable
            }
        }
    }
}
