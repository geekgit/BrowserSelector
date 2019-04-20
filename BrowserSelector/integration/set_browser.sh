#!/bin/bash
SelectorPath="/home/bionic/git/BrowserSelector/BrowserSelector/bin/Release/BrowserSelector.exe"
sudo chmod a+rwx "${SelectorPath}"
echo "${SelectorPath}"
xdg-settings set default-web-browser BrowserSelector.desktop
sudo update-alternatives --install /usr/bin/gnome-www-browser gnome-www-browser "${SelectorPath}" 9001
sudo update-alternatives --install /usr/bin/x-www-browser x-www-browser "${SelectorPath}" 9001
sudo update-alternatives --install /usr/bin/www-browser www-browser "${SelectorPath}" 9001
sudo update-alternatives --config gnome-www-browser
sudo update-alternatives --config x-www-browser
sudo update-alternatives --config www-browser
