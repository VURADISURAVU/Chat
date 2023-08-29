using System.Net.Sockets;
using System.Text;

string serverIp = "127.0.0.1";
int serverPort = 8888;

var client = new TcpClient(serverIp, serverPort);
NetworkStream stream = client.GetStream();

Console.WriteLine("Подключено к серверу.");

while (true)
{
    Console.WriteLine("Вы: ");
    string userMessage = Console.ReadLine();

    byte[] messageBuffer = Encoding.UTF8.GetBytes(userMessage);
    stream.Write(messageBuffer, 0, messageBuffer.Length);

    byte[] responseBuffer = new byte[1024];
    int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
    string serverResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
    Console.WriteLine($"Сервер: {serverResponse}");
}