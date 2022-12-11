using System;
namespace T03.Telephony
{
    public class StationaryPhone : ICalling
    {
        public string Calling(string number)
        {
            return $"Dialing... {number}";
        }
    }
}

