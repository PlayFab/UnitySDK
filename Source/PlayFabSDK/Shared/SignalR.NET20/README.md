
# SignalR Client for .NET 2.0

[![Build status](https://ci.appveyor.com/api/projects/status/8k5ldu0s82ln76ah/branch/master?svg=true)](https://ci.appveyor.com/project/jenyayel/signalr-client-20/branch/master)
[![Issue Stats](http://www.issuestats.com/github/jenyayel/SignalR.Client.20/badge/issue)](http://www.issuestats.com/github/jenyayel/SignalR.Client.20)

Client for SignalR which supports protocol 1.2 targeting .NET 2.0. The library can be easily compiled into Unity3D projects. 

Client and server samples located under [demo folder](https://github.com/jenyayel/SignalR.Client.20/tree/master/source/Demo). Client's API is the same as for the standard/original SignalR client library:

```csharp
// setup proxy
HubConnection connection = new HubConnection("http://localhost:58438/");
IHubProxy proxy = connection.CreateProxy("TestHub");

// subscribe to event
proxy.Subscribe("ClientPing").Data += data =>
{
  JToken data = data[0] as JToken;
  Console.WriteLine("Received push from server: [{0}]}", data["message"].ToString());
};

// start connection
connection.Start();
```


