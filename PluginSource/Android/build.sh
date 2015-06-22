#!/bin/bash
set -x
ant jar
cp release/PlayFabUnityAndroid.jar ../../PlayFabClientSample/Assets/Plugins/Android
