using UnityEngine;
using System.Text;
using PlayFab.SharedModels;
using UnityEngine.Rendering;
#if NETFX_CORE
using System.Reflection;
#endif

namespace PlayFab
{
    public class PlayFabDataGatherer
    {
#if UNITY_5 || UNITY_5_3_OR_NEWER
        // UNITY_5 Application info
        public string ProductName;
        public string ProductBundle;
        public string Version;
        public string Company;
        public RuntimePlatform Platform;
        // UNITY_5 Graphics Abilities
        public bool GraphicsMultiThreaded;
#else
        public enum GraphicsDeviceType
        {
            OpenGL2 = 0, Direct3D9 = 1, Direct3D11 = 2, PlayStation3 = 3, Null = 4, Xbox360 = 6, OpenGLES2 = 8, OpenGLES3 = 11, PlayStationVita = 12,
            PlayStation4 = 13, XboxOne = 14, PlayStationMobile = 15, Metal = 16, OpenGLCore = 17, Direct3D12 = 18, Nintendo3DS = 19
        }

        // RuntimePlatform Enum info:
        // OSXEditor = 0, OSXPlayer = 1, WindowsPlayer = 2, OSXWebPlayer = 3, OSXDashboardPlayer = 4, WindowsWebPlayer = 5, WindowsEditor = 7,
        // IPhonePlayer = 8, PS3 = 9, XBOX360 = 10, Android = 11, LinuxPlayer = 13, FlashPlayer = 15, WebGLPlayer = 17, MetroPlayerX86 = 18,
        // WSAPlayerX86 = 18, MetroPlayerX64 = 19,WSAPlayerX64 = 19, MetroPlayerARM = 20, WSAPlayerARM = 20, WP8Player = 21,
        // EditorBrowsable(EditorBrowsableState.Never)] BB10Player = 22, BlackBerryPlayer = 22, TizenPlayer = 23, PSP2 = 24, PS4 = 25,
        // PSM = 26, XboxOne = 27, SamsungTVPlayer = 28, WiiU = 30, tvOS = 31
#endif
#if !UNITY_5_0 && (UNITY_5 || UNITY_5_3_OR_NEWER)
        public GraphicsDeviceType GraphicsType;
#endif

        // Application info
        public string DataPath;
        public string PersistentDataPath;
        public string StreamingAssetsPath;
        public int TargetFrameRate;
        public string UnityVersion;
        public bool RunInBackground;

        //DEVICE & OS
        public string DeviceModel;
        //public enum DeviceType { Unknown, Handheld, Console, Desktop }
        public DeviceType DeviceType;
        public string DeviceUniqueId;
        public string OperatingSystem;

        //GRAPHICS ABILITIES
        public int GraphicsDeviceId;
        public string GraphicsDeviceName;
        public int GraphicsMemorySize;
        public int GraphicsShaderLevel;

        //SYSTEM INFO
        public int SystemMemorySize;
        public int ProcessorCount;
        public int ProcessorFrequency;
        public string ProcessorType;
        public bool SupportsAccelerometer;
        public bool SupportsGyroscope;
        public bool SupportsLocationService;

        public PlayFabDataGatherer()
        {
#if UNITY_5 || UNITY_5_3_OR_NEWER
            // UNITY_5 Application info
            ProductName = Application.productName;
            Version = Application.version;
            Company = Application.companyName;
            Platform = Application.platform;
            // UNITY_5 Graphics Abilities
            GraphicsMultiThreaded = SystemInfo.graphicsMultiThreaded;
#endif
#if !UNITY_5_0 && (UNITY_5 || UNITY_5_3_OR_NEWER)
            GraphicsType = SystemInfo.graphicsDeviceType;
#endif

            //Only Used on iOS & Android
#if UNITY_5_6_OR_NEWER && UNITY_ANDROID && (UNITY_IOS || UNITY_IPHONE)
            ProductBundle = Application.identifier;
#elif UNITY_ANDROID && (UNITY_IOS || UNITY_IPHONE)
            ProductBundle = Application.bundleIdentifier;
#endif

            // Application info
            DataPath = Application.dataPath;
#if !UNITY_SWITCH
            PersistentDataPath = Application.persistentDataPath;
#endif
            StreamingAssetsPath = Application.streamingAssetsPath;
            TargetFrameRate = Application.targetFrameRate;
            UnityVersion = Application.unityVersion;
            RunInBackground = Application.runInBackground;

            //DEVICE & OS
            DeviceModel = SystemInfo.deviceModel;
            DeviceType = SystemInfo.deviceType;

            DeviceUniqueId = PlayFabSettings.DeviceUniqueIdentifier;
            OperatingSystem = SystemInfo.operatingSystem;

            //GRAPHICS ABILITIES
            GraphicsDeviceId = SystemInfo.graphicsDeviceID;
            GraphicsDeviceName = SystemInfo.graphicsDeviceName;
            GraphicsMemorySize = SystemInfo.graphicsMemorySize;
            GraphicsShaderLevel = SystemInfo.graphicsShaderLevel;

            //SYSTEM INFO
            SystemMemorySize = SystemInfo.systemMemorySize;
            ProcessorCount = SystemInfo.processorCount;
#if UNITY_5_3_OR_NEWER
            ProcessorFrequency = SystemInfo.processorFrequency; // Not Supported in PRE Unity 5_2
#endif
            ProcessorType = SystemInfo.processorType;
            SupportsAccelerometer = SystemInfo.supportsAccelerometer;
            SupportsGyroscope = SystemInfo.supportsGyroscope;
            SupportsLocationService = SystemInfo.supportsLocationService;
        }

        public string GenerateReport()
        {
            var sb = new StringBuilder();
            sb.Append("Logging System Info: ========================================\n");
            foreach (var field in GetType().GetTypeInfo().GetFields())
            {
                var fld = field.GetValue(this).ToString();
                sb.AppendFormat("System Info - {0}: {1}\n", field.Name, fld);
            }
            return sb.ToString();
        }
    }
}
