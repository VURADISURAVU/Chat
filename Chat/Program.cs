using System.Net.Sockets;
using System.Net;
using System.Text;

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
int port = 8888;

TcpListener server = new TcpListener(ipAddress, port);
server.Start();
Console.WriteLine("Сервер запущен...");

TcpClient client = server.AcceptTcpClient();
Console.WriteLine("Подключен клиент.");

NetworkStream stream = client.GetStream();
byte[] buffer = new byte[1024];
int bytesRead;

while (true)
{
    bytesRead = stream.Read(buffer, 0, buffer.Length);
    string clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine($"Клиент: {clientMessage}");

    string response = GenerateServerResponse(clientMessage);
    byte[] responseBuffer = Encoding.UTF8.GetBytes(response);
    stream.Write(responseBuffer, 0, responseBuffer.Length);
}

static string GenerateServerResponse(string clientMessage)
{
    return clientMessage;
}