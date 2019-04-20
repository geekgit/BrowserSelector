#!/bin/bash
cd ~/.local/share/applications
wget --secure-protocol=TLSv1_2 --https-only "https://raw.githubusercontent.com/geekgit/BrowserSelector/master/BrowserSelector/integration/BrowserSelector.desktop" -O BrowserSelector.desktop
chmod a+rwx BrowserSelector.desktop
