rem This script relies on Unity.exe being in your system-path
rem This is usually "C:\Program Files\Unity\Editor"
Unity -quit -batchmode -executeMethod PlayFabPackager.MakeAndroidBuild -logFile ../testBuilds/androidOutput.txt