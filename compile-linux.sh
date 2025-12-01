#!/bin/bash

/home/sy4may0/Unity/Hub/Editor/6000.2.6f2/Editor/Unity \
  -batchmode \
  -nographics \
  -silent-caches \
  -logFile /home/sy4may0/Unity/unity_compile.log \
  -projectPath /home/sy4may0/Unity/FukaRebuild \
  -quit

cat /home/sy4may0/Unity/unity_compile.log
