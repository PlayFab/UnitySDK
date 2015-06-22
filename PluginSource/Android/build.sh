#!/bin/bash
set -x
ant jar
cp release/PlayFabUnityAndroid.jar ../../PlayFabClientSDK/Playfab/Plugins/Android
