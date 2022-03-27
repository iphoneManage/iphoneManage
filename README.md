### iManager
UI Program that can help to manage your jailbroken iDevices.

All you need to do is install openssh on your device and connect it to the computer and launch iManager

iManager will than connect using ssh and can now execute code and commands as root.

## Features

 -SBReload device
 
 -Install Tweaks
 
 -Shutdown device
 
 -Install Application
 
 -Install Shell scripts as Command to the System
 
 -UICache || THIS WILL REMOVE THE CHECKRA1N LOADER UNTIL THE NEXT REJAILBREAK (checkra1n loader app will not disappear from Homescreen on odysseyra1n)
 
 -Respring Device || SBReload and Respring is almost the same, you should use sbreload instead
 
 -List installed Packages (Installed Tweaks)
 
 -Run commands that you want from a text filed and see the output
 
 -Program will show an iPhone with your iDevice Wallpaper
 
 -iManager shows some basic information about the connected iDevice
 
 -You can send files/folders to your iDevice || They can be found at /var/mobile/iManagerkira/macFiles/ or /var/mobile/iManagerkira/windowsFiles/
 
  For now this is not that much, but im planning to add more soon. You can anyways feel free to add features yourself as iManager is fully open sourced.
  Since it has root access, it can in theory even set nonce, restore rootFS or something.
  
  ## Compatibility
  
     You could say its 3uTools for Jailbroken devices as it can only work completley with jailbroken devices (OpenSSH and Tweak Innjection required)
     OpenSSH is required for most functions but to use all features you also need a tweak system
     A Tweak system will be automaticly installed when you install a tweak like SnowBoard (Cydia Substrate, Libhooker or Substitute are Tweak Systems)
     Any iOS version from iOS 5 to 14.x should be 100% supported and ios 1.0-4.x will not completley work.
    
     IOS 15
     Im worried a bit about iOS 15 as it looks like we only get rootless jailbreak, so idk if OpenSSH can even be installed? 
     (Its usually installed in /etc/ssh/ but thats not possible to access on rootless jailbreak).
     As long as Appsync Unified will not be updated for iOS 15 but OpenSSH is, you could use any feature execept installing Applications
     
     iManager works on Windows and MacOS
     
     iManager is Open Sourced for Windows and MacOS
     
## Compiling
   
   Select your Apple ID to sign the App in Xcode and than just build it. It should Build/Compile without issues
   
   Open iManager.sln and click the build button in Visual Studio
   
## Instaling Windows
  
  Download the latest iManager version for Windows from releases
  
  Unzip the zip file and double click iManager.exe
  
  In case iManager will not start, install iTunes (install iTunes from internet, not microsoft Store) Only do that when iManager.exe won´t start otherwise you don´t need to install iTunes
  
  Now iManager.exe should open up
  
  Plug your Jailbroken iDevice to your computer or laptop via Cable and make sure OpenSSH and tweak injection System (Libhooker, Cydia Substrate or Substitute) is installed
  
  Click install dependencies Button and wait for iManager to tell you it installed all dependencies.
  You need to click install dependencies each time you connect a new Jailbroken iDevice that wasn´t
  Click install dependencies Button and wait for iManager to tell you it installed all dependencies. connected with iManager before or only with older versions.
  
  
  
## Installing MacOS
   
   ////Requirment////
   
   Make sure you installed Homebrew. You can get it from here: https://brew.sh
   
   
   //////DOWNLOADING/////
   
   Download the latest release from here: 
   Double click the .DMG and drag the iphoneManage.app in the Applications folder.
   
   
   /////App Cannot be opened because .. //////
   
   Open iphoneManage.app using Finder, not using Launchpad
   It will say that Apple cannot check it for Malware. Just click open anyways button and iManager should start. 
   In case it say it cannnot check for malware but you don´t see an open button, open settings, navigate to Security and now there should be a message
   about iphoneManage.app where you can click open anyways. 
   
   VIDEO TUTORIAL FOR THIS: https://www.youtube.com/watch?v=_gQA3RhcJuU
   
   
   //////// Type in your root passsword //////
   
   iManager can only connected when it knows the root password of your idevice!! Don´t forogt to type your iDevice root password in the left bottom corner
   text field. You only need to enter your root Password when you use the standart root which is alpine
   
   
   /////NETWORK ///////
   Even when iManager is connecting localy by the cable its still ssh. I think the network doesn´t really matter as it the idevice is connected
   with the cable and as localhost but when you have connecting issues you should still ensure your idevice and computer are in the same Network :)
   
   
   ///// INSTALLING DEPENDENCIES /////
   
   After you moved iphoneManage.app to your /Applications folder and allowed it to be opened, click install dependencies in iManager.
   After its done, quit it from the taskbar, relaunch iManager and click install dependencies again. Now you should see some Alerts poping up on your connected idevice
   
   
## Using this source code
   You are not allowed to change iManagers source code and upload it to a new repository (When you want that, contact me on GitHub)
   You can of course uploaded your changed iManager source code by forking this repo. You can use the code as help for your own tools when you credit me
   
   
   
