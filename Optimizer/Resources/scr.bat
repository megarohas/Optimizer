@echo off
sc config WerSvc start= disabled
net stop WerSvc
sc config WbioSrvc start= disabled 
net stop WbioSrvc
sc config TabletInputService start= disabled
net stop TabletInputService
sc config TrkWks start= disabled
net stop TrkWks
sc config PcaSvc start= disabled
net stop PcaSvc
sc config RemoteRegistry start= disabled
net stop RemoteRegistry
sc config dmwappushservice start= disabled 
net stop dmwappushservice
net stop SysMain
sc config SysMain start= disabled
if errorlevel 1 goto first
if errorlevel 0 goto second
:first
exit
:second
cd /d "%~dp0" 
echo true>>file.txt
exit
 


