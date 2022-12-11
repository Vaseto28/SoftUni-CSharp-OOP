namespace T03.Telephony
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string number in phoneNumbers)
            {
                if (!IsPhoneNumberValid(number))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    ICalling smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Calling(number));
                }
                else if (number.Length == 7)
                {
                    ICalling stationaryPhone = new StationaryPhone();
                    Console.WriteLine(stationaryPhone.Calling(number));
                }
            }

            foreach (string url in urls)
            {
                if (!IsURLValid(url))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    IBrowsing smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Browsing(url));
                }
            }
        }

        static bool IsPhoneNumberValid(string phoneNumber)
        {
            foreach (char ch in phoneNumber)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsURLValid(string url)
        {
            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

