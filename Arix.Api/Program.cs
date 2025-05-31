using Arix.Api;
using Arix.Domain.TelegramHandler;
using Telegram.Bot;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TelegramBotWorker>();

var config = builder.Configuration;

var botToken = "";
builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(botToken));

builder.Services.AddSingleton<ITelegramHandler, TelegramHandler>();

var host = builder.Build();
host.Run();