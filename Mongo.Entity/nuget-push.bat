@echo off
cls
echo *** Pushing all packages in this folder to NuGet.org ***
echo.
set cmd="dir /b *.nupkg | findstr /vi "symbols.nupkg""
FOR /F %%F IN (' %packages% ') DO CALL :INVOKE %%F
GOTO :EOF

:INVOKE
echo Processing file %1 ...
echo.
NuGet.exe push %1"
echo.
echo done!
GOTO :EOF
echo.
echo.
pause