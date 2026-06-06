using Azure.Messaging.ServiceBus;
using eCommerce.CatalogService.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace eCommerce.CatalogService.Application.Listeners
{
    public class ProductListener : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly ILogger<ProductListener> _logger;
        private readonly ServiceBusClient _client;
        private readonly IServiceProvider _provider;

        public ProductListener(ILogger<ProductListener> logger, ServiceBusClient client, IServiceProvider provider)
        {
            _logger = logger;
            _client = client;
            _provider = provider;

            _processor = _client.CreateProcessor("products-queue", "products-subscription", new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = 5,
                AutoCompleteMessages = false
            });
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _processor.ProcessMessageAsync += HandleMessage;
            _processor.ProcessErrorAsync += HandleError;

            await _processor.StartProcessingAsync(stoppingToken);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Product Listener running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }

        private async Task HandleMessage(ProcessMessageEventArgs args)
        {
            using var scope = _provider.CreateScope();
            var appService = scope.ServiceProvider.GetRequiredService<IProductApplication>();

            var json = args.Message.Body.ToString();
            var evt = JsonSerializer.Deserialize<ProductAddedEvent>(json);

            if (evt is null)
            {
                _logger.LogWarning("Failed to deserialize ProductAddedEvent for message {MessageId}", args.Message.MessageId);
                await args.DeadLetterMessageAsync(args.Message, "DeserializationFailed", "Could not deserialize ProductAddedEvent");
                return;
            }
            await appService.InsertAsync(evt);

            await args.CompleteMessageAsync(args.Message);
        }

        private async Task HandleError(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception);
            await Task.CompletedTask;
        }
    }
}