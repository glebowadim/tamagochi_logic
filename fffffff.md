# Integration Hub
## Trackor Tree
Integration -> Integration Run -> Log
 
## Integration Trackor
This Trackor contains information about the integration.
Fields: Integration ID, Integration Name, Control Process, Directionality, Enabled, Last Run, External System, Last Modified Date, Description.
* Integration ID – Unique identifier. (2)
* Integration Name – User-friendly integration name. (1)
* Control Process – Grouping of several integrations with common logic. (2)
* Directionality – Data flow direction (Outward, Inward, or Bi-Directional). (1)
* Enabled – Allows to suspend integration. (2)
* Last Run – Date and time of the last run. (1)
* External System – System that the Integration is connecting to. (1)
* Last Modified Date – Last modification date of the Trackor. (1)
* Description – Description of integration. (1)
* Read From STDOUT - Checkbox that indicates that stdout is added to Log Trackor. (2)

1 – information fields.
2 – fields that affect integration.

## Integration Run Trackor
This Trackor contains information about run of the integration.
Fields: Integration Runs ID, Status, Start, Finish, File. 
* Status – This field is used to display the ran state (Running, Executed without Warnings, Executed with Warnings).
* Start – This is the start date and time.
* Finish – This is the finish date and time.
* File – File is involved in the integration.


## Log Trackor
This Trackor contains information about integration actions, errors and files. Filled by integration process in real time during execution
Fields: Log ID, Date Time, Warning Type, Message, Description, File 
* Date Time – Log record date and time.
* Message Type – Message type (Info, Warning, Error)
* Message – Short message from the executable file.
* Description – Full message from the executable file.
* File – File is involved in the integration.

## Scripts wrapper
Integration Wrapper is a python script for starting, controlling and saving status and logs of the integration execution. 
The output from stdout and stderr are written to Log Trackor. The path to upload file is taken from stdout. If executable script returned a code other than zero, then Integration Run status is "Executed with Warnings".
Wrapper actions and internal errors are written to a file in “log” folder. “log” folder should be located in the script directory.

### Example:
    python IntegrationWrapper.py -p Passwords.json -i Integration.json
Passwords.json contains accesses from OneVision Platform.
### Example:
    {
	    "installation": {
		    "UserName": "vglebov",
		    "Password": "*************",
		    "URL":"inside.onevizion.com"
	    }
    }

Integration.json contains the names of the integration and the path to the executable file.
### Example:
    [
	    {
		    "IntegrationName": "FCC Daily",
		    "ExecutablePath":"./daily-import-run.sh fcc-daily-import ******",
		    "ExecutableWorkingDir": "/home/ec2-user/fccdb-import/"
	    },
        	    {
		    "IntegrationName": "FCC Full",
		    "ExecutablePath": "/home/ec2-user/fccdb-import/full-import-run.sh fcc-daily-import *****"
	    }
    ]

For periodic runs IntegrationWrapper.py should be scheduled with cron:

### Example:
    # m h dom mon dow command
    0 3 * * * python IntegrationWrapper.py -p Passwords.json -i Integration.json

## Adding logs from outside
IntegrationWrapperAddingLog.py – python script for adding logs to running integration.
### Example:
    python IntegrationWrapperAddingLog.py -p Passwords.json -i IntegrationID -w MessageType -m Message -f PathToFile
* Passwords.json – JSON file that contains accesses from OneVision Platform
* IntegrationID – ID of Integration Trackor.
* MessageType – Message Type of Log (0 – Info, 1 – Warning, 2 – Error).
* Message – Message of Log.
* PathToFile – Path to upload file.

## Start and stop Integration Run from outside 
IntegrationWrapperRunController.py – Integration Run can be started and stopped from outside.
### Example:
    python IntegrationWrapperRunController.py -p Passwords.json -i IntegrationID -t ActionType -e Error
* Passwords.json – JSON file that contains accesses from OneVision Platform
* IntegrationID – ID of Integration Trackor
* ActionType –  creation or stopping Integration Run (start – Creation of new Integration Run with status “Running”, stop – Updation of status on “Executed with Warnings” or “Executed without Warnings”)
* Error – Integration Run status (1 – “Executed with Warnings”, 0 - “Executed without Warnings”)
