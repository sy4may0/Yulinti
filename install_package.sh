#!/bin/bash
PACKAGE=$1

/home/sy4may0/Unity/Hub/Editor/6000.2.6f2/Editor/Unity \
  -batchmode \
  -nographics \
  -silent-caches \
  -logFile /home/sy4may0/Unity/unity_compile.log \
  -projectPath /home/sy4may0/Unity/FukaRebuild \
  -executeMethod UnityEditor.PackageManager.Client.Add "$1" \
  -quit

cat /home/sy4may0/Unity/unity_compile.log
