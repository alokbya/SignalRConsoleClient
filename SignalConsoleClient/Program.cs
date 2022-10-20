// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;
using SignalConsoleClient.Models.cs;

Console.WriteLine("Hello, World!");

Chatroom cr = new Chatroom(null);
await cr.Run();