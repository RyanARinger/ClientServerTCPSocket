using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Console.Write("Enter your name: ");
            person.Name = Console.ReadLine();

            // Send the message  
            string jsonPerson = System.Text.Json.JsonSerializer.Serialize(person);
            byte[] bytes = sendMessage(System.Text.Encoding.Unicode.GetBytes(jsonPerson));
        }
        private static byte[] sendMessage(byte[] messageBytes)
        {
            byte[] responseBytes;
            const long bytesize = 1024 * 1024;
            try // Try connecting and send the message bytes  
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("192.168.1.220", 1234); // Create a new connection  
                NetworkStream stream = client.GetStream();

                stream.Write(messageBytes, 0, messageBytes.Length); // Write the bytes  
                Console.WriteLine("================================");
                Console.WriteLine("=   Connected to the server    =");
                Console.WriteLine("================================");
                Console.WriteLine("Waiting for response...");

                responseBytes = new byte[bytesize]; // Clear the message   

                // Receive the stream of bytes  
                stream.Read(responseBytes, 0, responseBytes.Length);
                //Console.WriteLine(Encoding.Default.GetString(messageBytes));
                Console.WriteLine(Encoding.Default.GetString(responseBytes));
                Console.WriteLine(responseBytes.LongLength);

                // Clean up  
                stream.Dispose();
                client.Close();
            }
            catch (Exception e) // Catch exceptions  
            {
                Console.WriteLine(e.Message);
            }

            return messageBytes; // Return response  
        }
    }
}
