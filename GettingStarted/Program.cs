using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using GettingStartedLib;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8733/GettingStartedLib/");

            var selfHost = new ServiceHost(typeof(CalcService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICalc), new WSHttpBinding(), "CalcService");

                var smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine($"Service opened at {selfHost.BaseAddresses.FirstOrDefault()}");
                Console.ReadKey();

                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"Exception: {ce.Message}");
                selfHost.Abort();
                Console.ReadKey();
            }
        }
    }
}
