set VSTEST=C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe
set DLL=%~dp0\UnitTestProject1\bin\Debug\UnitTestProject1.dll

"%VSTEST%"^
  /ListTests:"%DLL%"^
  /UseVsixExtensions:true

pause
