using System;
using System.Collections.ObjectModel;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.TimeZones;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            var timeSpan = TimeSpan.Parse("0030");

            Console.WriteLine(timeSpan);

            
            // var losAngeles = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
            // var vancouver = DateTimeZoneProviders.Tzdb["America/Vancouver"];
            //
            // var instant = SystemClock.Instance.GetCurrentInstant();
            // ZonedDateTime losAngelesDateTime = instant.InZone(losAngeles);
            // ZonedDateTime vancouverDateTime = instant.InZone(vancouver);
            //
            //
            // TzdbDateTimeZoneSource.Default.WindowsMapping.PrimaryMapping.TryGetValue("Dateline Standard Time", out var buba);
            //
            // TimeZoneInfo findSystemTimeZoneById = TimeZoneInfo.FindSystemTimeZoneById("Mid-Atlantic Standard Time");
            
            

            // for (int i = 0; i < 365; i++)
            // {
            //     if (losAngelesDateTime.IsDaylightSavingTime() != vancouverDateTime.IsDaylightSavingTime())
            //     {
            //         Console.WriteLine(losAngelesDateTime);
            //         Console.WriteLine(vancouverDateTime);
            //         
            //         Console.WriteLine("Buuba");
            //     }
            //     losAngelesDateTime = losAngelesDateTime.Plus(Duration.FromDays(1));
            //     vancouverDateTime = vancouverDateTime.Plus(Duration.FromDays(1));
            // }

            Console.WriteLine("Ok");

            // ReadOnlyCollection<TimeZoneInfo> readOnlyCollection = TimeZoneInfo.GetSystemTimeZones();
            // foreach (var timeZoneInfo in readOnlyCollection)
            // {
            //     Console.WriteLine(timeZoneInfo.StandardName);
            // }
            //
            // Console.WriteLine(readOnlyCollection.Count);
            //
            // Console.WriteLine("Hello World!");
        }
    }
}