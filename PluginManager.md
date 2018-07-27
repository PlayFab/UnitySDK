# PluginManager API
## 1. Overview:
The SDK provides a set of plugin interfaces and uses PluginManager class to support custom implementation of some SDK components. Currently the following plugin interfaces are supported:

```csharp
PlayFab.ISerializerPlugin // - allows to provide a custom JSON serializer
PlayFab.IPlayFabTransportPlugin // - allows to provide a custom network HTTP client specific to PlayFab backend
```

## 2. Prerequisites:
The SDK is downloaded and set up (see [README.md](README.md) and [UnityGettingStarted.md](UnityGettingStarted.md)). Some initialization code is added that sets PlayFab Title ID (e.g. PlayFabLogin.cs as in the Getting Started guide).

## 3. Usage sample:
User can optionally add one or more plugins (custom implementations of interfaces listed above):
```csharp
public class MyJsonSerializer : ISerializerPlugin
{
    public T DeserializeObject<T>(string serialized)
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public T DeserializeObject<T>(string serialized, object serializerStrategy)
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public object DeserializeObject(string serialized)
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public string SerializeObject(object obj)
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public string SerializeObject(object obj, object serializerStrategy)
    {
        // custom implementation
        throw new NotImplementedException();
    }
}

public class MyNetworkTransportClient : IPlayFabTransportPlugin
{
    public string AuthKey
    {
        get
        {
            // custom implementation
            throw new NotImplementedException();
        }

        set
        {
            // custom implementation
            throw new NotImplementedException();
        }
    }

    // custom implementation
    public string EntityToken { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

    // custom implementation
    public bool IsInitialized { get { return true; } }

    public int GetPendingMessages()
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public void Initialize()
    {
        // custom implementation
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method is called to make API calls.
    /// </summary>
    /// <param name="reqContainer">The request container object.</param>
    public void MakeApiCall(object reqContainer)
    {
        // custom implementation
        // (in this example it just prints HTTP request details to console)
        CallRequestContainer req = (CallRequestContainer)reqContainer;
        Debug.Log("Make API is called");
        Debug.Log("Full URL: " + req.FullUrl);
        Debug.Log("Headers: " + string.Join(", ", req.RequestHeaders.Select(header => header.Key + ": " + header.Value).ToArray()));
        Debug.Log("Payload JSON: " + Encoding.UTF8.GetString(req.Payload));

        // determine success or error of your custom transport operation
        bool success = true;

        if (success)
        {
            // success
            req.InvokeSuccessCallback();
        }
        else
        {
            // error
            req.ErrorCallback(new PlayFabError
            {
                ApiEndpoint = req.ApiEndpoint,
                CustomData = "some custom error data",
                ErrorMessage = "some custom error message",
                Error = PlayFabErrorCode.InternalServerError,
                HttpCode = 500,
                HttpStatus = "Failure"
            });
        }
    }

    public void OnDestroy()
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
    {
        // custom implementation
        throw new NotImplementedException();
    }
    public void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback)
    {
        // custom implementation
        throw new NotImplementedException();
    }

    public void Update()
    {
        // custom implementation
        throw new NotImplementedException();
    }
}
```
Then use PluginManager class to set custom plugins before using any other PlayFab API, for example, in the initialization portion of the code, e.g. where PlayFab Title ID is set:
```csharp
    public void Start()
    {
        // Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        // PlayFabSettings.TitleId = "144"; // Please change this value to your own titleId from PlayFab Game Manager

        // Optionally set your own custom JSON serializer
        PluginManager.SetPlugin(new MyJsonSerializer(), PluginContract.PlayFab_Serializer);

        // Optionally set your own custom HTTP network client
        PluginManager.SetPlugin(new MyNetworkTransportClient(), PluginContract.PlayFab_Transport);

        // ...
    }
```
The SDK will be using these custom plugins instead of the built-in ones. A currently set plugin for any "contract" supported by PlayFab SDK can be obtained from PluginManager class, for example:

```csharp
var currentTransportClient = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
```
