using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading;

namespace TemperatureMqttPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("start publishing");
            // Create Client instance
            MqttClient myClient = new MqttClient("192.168.28.128");

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);

            for (int i = 0; i < 100; i++)
            {
                double temperature = 25 + 5 * Math.Sin(i / 10.0);
                string strValue = Convert.ToString(temperature);

                myClient.Publish("measurements/temperature", Encoding.UTF8.GetBytes(strValue));
                Thread.Sleep(1000);
            }

        }
    }
}
