# signalR
ASP .NET Core 2.1 SignalR POC Web API, MVC App, Console App

This application is a SignalR POC. 
The SignalR.Api is the SignalR Server Hub.

The SignalR Hubs API enables you to make remote procedure calls (RPCs) from a server to connected clients and from clients to the server. 
In server code, you define methods that can be called by clients, and you call methods that run on the client. 
In client code, you define methods that can be called from the server, and you call methods that run on the server. 
SignalR takes care of all of the client-to-server plumbing for you.

SignaR.ClientApp is a Console Application that connects to the Hub using optionally Bearer Authentication and include the most basic functions
in order to register at specific hub methods.

SignalR.WebClient is a Web Application that connects a the same hub as the Console Application and provides a basic signalR fuctionality.
