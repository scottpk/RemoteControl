Scott's Remote Control

WHAT IS IT:
Remote Control sets up a simple HTTP service which can be used to launch applications.
For example one might want to do this on a Media Center PC to launch VLC, or open
a browser window to Hulu.

HOW CAN I SET UP MY APP LIST:
The file "apps.xml" is used to read in the list of applications.
You can use this as an example:
<apps>
  <app appName="Steam" appPath = "C:\Program Files (x86)\Steam\Steam.exe" />
  <app appName="Hulu" appPath = "http://www.hulu.com/" />
</apps>

CAN I CHANGE THE LAYOUT:
You can change the layout by modifying the file "template.html". The text 
[!AppTable!]
will be replaced with an HTML <table> containing the apps and their icons.
Please note this is NOT a full web server, at the moment it won't serve files.
The main ramification is that any images or CSS styling must be embedded.  

CAN I USE WEB APPS:
Yes, putting the URL in the "appPath" property will cause Remote Control to open
a browser window with the site's URL. Unfortunately at this time Remote Control
cannot use the site's favicon, you will not see an icon for web apps.

CAN I CHANGE THE ICONS:
Not at this time. The icons displayed are embedded in the .exe file. Any application
without an icon embedded will not show an icon at all, neither will any web apps.

HOW DO I USE IT:
Just run RemoteControl.exe - this will open port 8080. You can launch apps from a
browser window by navigating to
http://[MACHINE NAME]:8080/
If you are running under an unprivileged account (good for you) you may need to
run "allow-listening.bat" as a privileged user the first time you run the program
in order to allow your user to listen to port 8080. You can do that by right-clicking
the file and choosing "Run as administrator"