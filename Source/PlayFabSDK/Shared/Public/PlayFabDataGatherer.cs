using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
#if NETFX_CORE
using System.Reflection;
#endif

namespace PlayFab
{

    public class PlayFabDataGatherer
    {
        //Application
        public string ProductName;
        public string ProductBundle;
        public string Version;
        public string Company;

        //OSXEditor = 0, OSXPlayer = 1, WindowsPlayer = 2, OSXWebPlayer = 3, OSXDashboardPlayer = 4, WindowsWebPlayer = 5, WindowsEditor = 7,
        //IPhonePlayer = 8, PS3 = 9, XBOX360 = 10, Android = 11, LinuxPlayer = 13, FlashPlayer = 15, WebGLPlayer = 17, MetroPlayerX86 = 18, 
        //WSAPlayerX86 = 18, MetroPlayerX64 = 19,WSAPlayerX64 = 19, MetroPlayerARM = 20, WSAPlayerARM = 20, WP8Player = 21,
        //EditorBrowsable(EditorBrowsableState.Never)] BB10Player = 22, BlackBerryPlayer = 22, TizenPlayer = 23, PSP2 = 24, PS4 = 25,
        //PSM = 26, XboxOne = 27, SamsungTVPlayer = 28, WiiU = 30, tvOS = 31
        public RuntimePlatform Platform;

        public string DataPath;
        public string PersistentDataPath;
        public string StreamingAssetsPath;
        public int TargetFrameRate;
        public string UnityVersion;
        public bool RunInBackground;

        //DEVICE & OS
        public string DeviceModel;
        public string DeviceName;
        //public enum DeviceType { Unknown, Handheld, Console, Desktop }
        public DeviceType DeviceType;
        public string DeviceUniqueId;
        public string OperatingSystem;

        //GRAPHICS ABILITIES
        public int GraphicsDeviceId;
        public string GraphicsDeviceName;
        //public enum GraphicsDeviceType { OpenGL2 = 0, Direct3D9 = 1, Direct3D11 = 2, PlayStation3 = 3, Null = 4, Xbox360 = 6, OpenGLES2 = 8, OpenGLES3 = 11, PlayStationVita = 12,
        //PlayStation4 = 13, XboxOne = 14, PlayStationMobile = 15, Metal = 16, OpenGLCore = 17, Direct3D12 = 18, Nintendo3DS = 19 }
        public GraphicsDeviceType GraphicsDeviceType;
        public int GraphicsMemorySize;
        public bool GraphicsMultiThreaded;
        public int GraphicsShaderLevel;

        //SYSTEM INFO
        public int SystemMemorySize;
        public int ProcessorCount;
        public int ProcessorFrequency;
        public string ProcessorType;
        public bool SupportsAccelerometer;
        public bool SupportsGyroscope;
        public bool SupportsLocationService;

        public void GatherData()
        {
            //Application
            ProductName = Application.productName;
            ProductBundle = Application.bundleIdentifier; //Only Used on iOS & Android
            Version = Application.version;
            Company = Application.companyName;
            Platform = Application.platform;

            DataPath = Application.dataPath;
            PersistentDataPath = Application.persistentDataPath;
            StreamingAssetsPath = Application.streamingAssetsPath;
            TargetFrameRate = Application.targetFrameRate;
            UnityVersion = Application.unityVersion;
            RunInBackground = Application.runInBackground;

            //DEVICE & OS
            DeviceModel = SystemInfo.deviceModel;
            DeviceName = SystemInfo.deviceName;
            DeviceType = SystemInfo.deviceType;

            DeviceUniqueId = SystemInfo.deviceUniqueIdentifier;
            OperatingSystem = SystemInfo.operatingSystem;

            //GRAPHICS ABILITIES
            GraphicsDeviceId = SystemInfo.graphicsDeviceID;
            GraphicsDeviceName = SystemInfo.graphicsDeviceName;
            GraphicsDeviceType = SystemInfo.graphicsDeviceType;
            GraphicsMemorySize = SystemInfo.graphicsMemorySize;
            GraphicsMultiThreaded = SystemInfo.graphicsMultiThreaded;
            GraphicsShaderLevel = SystemInfo.graphicsShaderLevel;

            //SYSTEM INFO
            SystemMemorySize = SystemInfo.systemMemorySize;
            ProcessorCount = SystemInfo.processorCount;
            //ProcessorFrequency = SystemInfo.processorFrequency; //Not Supported in PRE Unity 5_2
            ProcessorType = SystemInfo.processorType;
            SupportsAccelerometer = SystemInfo.supportsAccelerometer;
            SupportsGyroscope = SystemInfo.supportsGyroscope;
            SupportsLocationService = SystemInfo.supportsLocationService;
        }

        public void EnqueueToLogger(Queue<string> logMessageQueue)
        {
            logMessageQueue.Enqueue("Logging System Info: ========================================");
#if !NETFX_CORE
            foreach (var field in this.GetType().GetFields())
#else
            foreach (var field in this.GetType().GetTypeInfo().DeclaredFields)
#endif
            {
                var fld = field.GetValue(this).ToString();
                logMessageQueue.Enqueue(string.Format("System Info - {0}: {1}", field.Name, fld));
            }
        }

    }
}
