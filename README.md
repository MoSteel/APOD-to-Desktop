------------------------------------------
APOD TO DESKTOP APPLICATION
------------------------------------------

Requires Microsoft .NET 4.5 Framework available at:
	http://www.microsoft.com/en-us/download/details.aspx?id=30653
	
This application must be run once to initialize and setup the scheduled tasks
and program settings for the installation location where the executable is
first run.  After the first-time settings are configured, the executable
does not need to be manually run unless you want to change the settings
or manually retrieve the APOD image for the day.

APOD to Desktop runs on a scheduled task at user logon and attempts to retrieve
the Astronomy Picture of the Day, then sets the current Windows Wallpaper to the
newly retrieved APOD.  Previously applied images are saved locally and the
amount of space used can be configured by running the executable manually.

Note: APOD to Desktop has a delay built in of one minute after user logon before 
attempting to download the APOD. This delay is to allow time for establishing any 
network connections needed to reach the Internet.

------------------------------------------
INSTALLING APOD TO DESKTOP
------------------------------------------

Unzip the 'APOD_to_Desktop' directory and all contained files to your desktop or a 
Program Files folder, then open the folder and run 'APOD to Desktop.exe' in order 
to initialize the program for the first time.  Adjust the settings if desired and 
close the application.

------------------------------------------
UNINSTALLING APOD TO DESKTOP
------------------------------------------

In APOD to Desktop Settings, uncheck the following checkboxes if selected:
	"Automatically check for new APOD image at logon" 
	"Add 'Visit APOD Website' to the Desktop Context Menu"

Then remove any APOD to Desktop files left on your 
computer.

------------------------------------------
ABOUT APOD TO DESKTOP
------------------------------------------

**Source Code is available here:
	https://github.com/MoSteel/APOD-to-Desktop

**Utilizes the Task Scheduler Managed Wrapper for C#, available here: 
	https://taskscheduler.codeplex.com/
