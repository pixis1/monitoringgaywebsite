

using System;
using System.Net.NetworkInformation;
using System.Threading;

class MainProg
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine(args.Length);
        if(args.Length == 0)
        {
            Console.WriteLine("Нет аргументов, введите в аргумент сайт.");
            return;
        }
        if (args.Length > 1)
        {
            Console.WriteLine("Слишком много аргументов, должен быть один");
            return;
        }

        Ping pingSender = new Ping();
        PingOptions options = new PingOptions();
        options.DontFragment = true;
        PingReply reply = pingSender.Send(args[0]);
        if (reply.Status == IPStatus.Success)
        {
            Console.WriteLine("Address: {0}", reply.Address.ToString());
            Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
            Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
            Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            Console.WriteLine("Соединение прошло удачно :)");
                }
        else
        {
            Console.WriteLine("Соединение прошло отрицательно :(");
        }
    }
}