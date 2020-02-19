Call nuget.exe restore ..\src\Our.Umbraco.Tables.sln
Call "%programfiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" package.build.xml /bl /p:Configuration=Release