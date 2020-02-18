xcopy ..\src\Our.Umbraco.TableGenerator\App_Plugins\Our.Umbraco.TableGenerator  ..\samples\Our.Umbraco.TableGenerator.Demo\App_Plugins /e /i /h /s /y

Call nuget.exe restore ..\src\Our.Umbraco.TableGenerator.sln
Call "%programfiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" package.build.xml /bl /p:Configuration=Release