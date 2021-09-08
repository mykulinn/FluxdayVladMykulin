using System;

namespace Fluxday.Automation.Tests.Scenarios.Utils
{
    public static class StringDateTime
    {
        public static string GenerateDateTimeString()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }

        public static string PrependDateTimeString(string text)
        {
            return GenerateDateTimeString() + text;
        }

        public static string AppendDateTimeString(string text)
        {
            return text + GenerateDateTimeString();
        }
    }
}