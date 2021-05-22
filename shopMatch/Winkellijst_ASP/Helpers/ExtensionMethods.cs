using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Helpers
{
    public static class ExtensionMethods
    {
        // http://www.schwammysays.net/extension-method-for-datetime-timeago/
        public static string TimeAgo(this DateTime date)
        {
            TimeSpan timeSince = DateTime.Now.Subtract(date);
            if (timeSince.TotalMilliseconds < 1) return "";
            if (timeSince.TotalMinutes < 1) return "zojuist";
            if (timeSince.TotalMinutes < 2) return "1 minuut geleden";
            if (timeSince.TotalMinutes < 60) return string.Format("{0} minuten geleden", timeSince.Minutes);
            if (timeSince.TotalMinutes < 120) return "1 uur geleden";
            if (timeSince.TotalHours < 24) return string.Format("{0} uur geleden", timeSince.Hours);
            if (timeSince.TotalDays < 2) return "gisteren";
            if (timeSince.TotalDays < 7) return string.Format("{0} dagen geleden", timeSince.Days);
            if (timeSince.TotalDays < 14) return "vorige week";
            if (timeSince.TotalDays < 21) return "2 weken geleden";
            if (timeSince.TotalDays < 28) return "3 weken geleden";
            if (timeSince.TotalDays < 60) return "vorige maand";
            if (timeSince.TotalDays < 365) return string.Format("{0} maanden geleden", Math.Round(timeSince.TotalDays / 30));
            if (timeSince.TotalDays < 730) return "vorig jaar"; //last but not least...
            return string.Format("{0} jaar geleden", Math.Round(timeSince.TotalDays / 365));
        }
    }
}
