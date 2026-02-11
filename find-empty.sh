#!/bin/bash
find . -type d -exec sh -c '
  for dir do
    count=$(find "$dir" -mindepth 1 -maxdepth 1 ! -name "*.meta" | wc -l)
    if [ "$count" -eq 0 ]; then
      # .meta以外が無い
      meta_count=$(find "$dir" -mindepth 1 -maxdepth 1 -name "*.meta" | wc -l)
      if [ "$meta_count" -gt 0 ]; then
        echo "$dir"
      fi
    fi
  done
' sh {} +
