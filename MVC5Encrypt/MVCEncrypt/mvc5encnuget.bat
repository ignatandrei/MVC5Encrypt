choice /M "did you build on release?" /D N /T 60
SET VAL=%ERRORLEVEL%
IF %VAL% EQU 1 nuget pack MVCEncrypt.nuspec