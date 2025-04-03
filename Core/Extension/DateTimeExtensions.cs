using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class DateTimeExtensions
    {
        public static string ToPersianDateString(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month=persianCalendar.GetMonth(dateTime);
            int day=persianCalendar.GetDayOfMonth(dateTime);
            int hour=persianCalendar.GetHour(dateTime);
            int min=persianCalendar.GetMinute(dateTime);
            return $"({hour:00}:{min:00}){year:0000}/{month:00}/{day:00}";
        }
    }
}
