@echo off
call git add -A
echo "%1"

echo What did you do?
set /p msg=I 

call git commit --verbose -m "%msg%"
pause