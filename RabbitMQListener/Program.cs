using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQListener.DTOs;
using System.Text;

var factory = new ConnectionFactory { HostName = "rabbitmq" };

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("queue", exclusive: false);

const string baseUri = "http://order:80/api/product";

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);
    var message = JsonConvert.DeserializeObject<ProductDTO>(json);

    Console.WriteLine(json);

    using (var client = new HttpClient())
    {
        var jsonPayload = JsonConvert.SerializeObject(message);

        var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        await client.PostAsync(baseUri, httpContent);
    }
};

channel.BasicConsume(queue: "queue", autoAck: false, consumer: consumer);

Console.Read();