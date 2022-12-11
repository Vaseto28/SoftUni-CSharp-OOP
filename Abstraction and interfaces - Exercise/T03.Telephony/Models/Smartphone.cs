using System;
namespace T03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Browsing(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Calling(string number)
        {
            return $"Calling... {number}";
        }
    }
}

