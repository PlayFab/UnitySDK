#!/bin/bash
set -xe
if [ ! -e "libs/UnityPlayerClasses.jar" ];
then
  cp /Applications/Unity/Unity.app/Contents/PlaybackEngines/AndroidPlayer/release/bin/classes.jar libs/UnityPlayerClasses.jar
fi
ant jar
cp release/PlayFabUnityAndroid.jar ../../PlayFabClientSample/Assets/Plugins/Android
