namespace PlayFab
{
    /// <summary>
    /// Interface of a PlayFab-specific transport SDK plugin.
    /// This interface includes assumptions specific to current PlayFab implementations.
    /// While our ultimate goal is to have users implement ITransportPlugin interface it will require some refactoring in PlayFabHTTP. As a temporary solution
    /// users can implement IPlayFabTransportPlugin if they want to use their own custom transport.
    /// </summary>
    public interface IPlayFabTransportPlugin: ITransportPlugin
    {
        string AuthKey { get; set; }
        string EntityToken { get; set; }
    }
}