@echo off
cls
echo ***
echo *** Packaging all csproj in this folder
echo ***
echo.

FOR /F %%F IN ('dir /b *.csproj') DO (
	echo Processing file %%F
	call nuget pack "%%F" -Build -Symbols -Prop Configuration=Release
	echo.
)

set /p yn=Do you want to push your packages? [y/n] 
echo.

IF "%yn%"=="y" (
	set cmd="dir /b *.nupkg | findstr /vi "symbols.nupkg""
	
	FOR /F %%F IN (' %cmd% ') DO (
		echo Pushing file %%F
		call nuget push "%%F"
		echo.
	)
	
	echo.
)

echo My job here is done :)
echo.
pause