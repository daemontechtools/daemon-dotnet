#!/bin/bash


appStylesPathIn="./Styles/styles.css"
appStylesPathOut="./wwwroot/css/razor-ui.css"


if [[ $1 == "--watch" ]]; then
  echo "Building Tailwind CSS in watch mode..."
  tailwindcss -i $appStylesPathIn -o $appStylesPathOut --watch
else
  echo "Building Tailwind CSS..."
  tailwindcss -i $appStylesPathIn -o $appStylesPathOut
fi