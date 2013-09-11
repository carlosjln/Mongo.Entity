@echo off
call git add -A

echo What did you do?
set /p msg=I 

echo.
call git commit --verbose -m "%msg%"

echo.
set /p push=Do you want to push your changes? [y/n] 

echo.
IF "%push%"=="y" (
	echo Pushing changes...
	echo.
	call git push
)

echo.
echo My job here is done :)
echo.
pause