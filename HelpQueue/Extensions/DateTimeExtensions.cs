using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpQueue.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetTimeSince(this DateTimeOffset dateTime)
        {
            string GetS(double m)
            {
                return m > 1 ? "s" : "";
            }

            var timeSince = DateTimeOffset.Now - dateTime;
            var minutes = Math.Round(timeSince.TotalMinutes, 2);

            var hRemainder = Math.Round((timeSince.TotalHours - timeSince.Hours), 2);
            double hours = timeSince.Hours;
            for(; hRemainder > .25; hours += .25)
            {
                hRemainder -= .25;
            }

            var str = $"~{(minutes > 59 ? hours + $" hour{GetS(hours)}" : $"{timeSince.Minutes} minute{GetS(minutes)}")} ago";

            return str;
        }
    }
}