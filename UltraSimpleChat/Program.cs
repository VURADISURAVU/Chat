Console.WriteLine("Вы подключились к чату...");
while (true)
{
    Console.WriteLine("Вы: ");
    string userMessage = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userMessage))
    {
        Console.WriteLine("Бот: Пожалуйста, введите сообщение.");
        continue;
    }

    string botResponse = GenerateBotResponse(userMessage);
    Console.WriteLine($"Бот: {botResponse}");
}

static string GenerateBotResponse(string userMessage)
{
    return userMessage;
}