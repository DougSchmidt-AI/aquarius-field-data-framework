@echo off

setlocal

rem Assume 64-bit system
set Wow6432Node=Wow6432Node\
if not "%PROCESSOR_ARCHITECTURE%" == "x86" goto :skip32
rem 32-bit fallback
set ProgramFiles(x86)=%ProgramFiles%
set CommonProgramFiles(x86)=%CommonProgramFiles%
set Wow6432Node=
:skip32
rem The rest of the script runs as if it was on a 64-bit system

rem Detect admin mode
reg query "HKU\S-1-5-19" 1>nul 2>&1
if errorlevel 1 goto :mustRunAsAdmin


rem Change directory to the same folder as the script.
rem This corrects for "Launch as admin", which always starts in C:\Windows\system32
CD /D %~dp0

rem Uninstall the service
set ServiceName=FieldVisitHotFolderService
set ServiceDisplayName=AQUARIUS Field Visit Hot Folder

echo Uninstalling '%ServiceDisplayName%' as a Windows service ...
echo.

:uninstallService
NET STOP "%ServiceName%"
SC DELETE "%ServiceName%"
IF ERRORLEVEL 1 GOTO :error

echo.
echo '%ServiceDisplayName%' has been successfully uninstalled.
echo.
goto :end

:error
echo.
echo ===============
echo ERROR detected.
echo ===============
echo.
goto :end

:mustRunAsAdmin
echo.
echo ERROR: This script must be run with Administrator privileges.
echo.
echo Try the following:
echo 1) Open a new Windows Explorer window
echo 2) Browse to this folder: %~dp0
echo 3) Right-click this script file: %~nx0
echo 4) Select the "Run as Administrator" menu item
echo.

goto :end

:end
endlocal
pause
