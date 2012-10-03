@echo off

call C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\msbuild Report.msbuild /t:StyleCopSimple

exit /b 0

