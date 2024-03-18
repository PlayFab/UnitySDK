using PlayFab;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using UnityEngine.Networking;

public class GzipDownloadHandler : DownloadHandlerScript
{
    private byte[] _data;
    public byte[] Data { get { return _data; } }

    public GzipDownloadHandler() : base()
    {
    }

    protected override byte[] GetData() { return _data; }

    protected override bool ReceiveData(byte[] data, int dataLength)
    {
        if (_data == null)
            _data = data;
        else
        {
            byte[] newData = new byte[_data.Length + dataLength];
            _data.CopyTo(newData, 0);
            data.CopyTo(newData, _data.Length);
            _data = newData;
        }
        return true;
    }

    protected override void CompleteContent()
    {
        try
        {
            using MemoryStream stream = new MemoryStream(_data);
            using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, true);

            byte[] buffer = new byte[4096];
            using MemoryStream resultStream = new MemoryStream();

            int read;
            while ((read = gZipStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                resultStream.Write(buffer, 0, read);
            }

            _data = resultStream.ToArray();
        }
        catch (IOException)
        {
            // If we fail to decompress, it should be because Unity silently decompressed already, so we should disable this custom handler.
            // There is no info on which platforms Unity decompresses on, so we have to assume this is needed until we reach this.
            PlayFabSettings.staticSettings.DecompressWithDownloadHandler = false;
        }
    }
}
