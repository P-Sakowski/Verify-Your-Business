[Setup]
AppName=Verify-Your-Business
AppVersion=1.0
WizardStyle=modern
DefaultDirName={autopf}\Verify-Your-Business
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\Verify-Your-Business.exe
Compression=lzma2
SolidCompression=yes
OutputDir=userdocs:Verify-Your-Business-Installer

[Files]
Source: "bin/Release/Verify-Your-Business-Library.pdb"; DestDir: "{app}"
Source: "bin/Release/de/MigraDoc.DocumentObjectModel.netstandard.resources.dll"; DestDir: "{app}"
Source: "bin/Release/de/MigraDoc.Rendering.netstandard.resources.dll"; DestDir: "{app}"
Source: "bin/Release/de/PdfSharp.Charting.netstandard.resources.dll"; DestDir: "{app}"
Source: "bin/Release/MaterialDesignColors.dll"; DestDir: "{app}"
Source: "bin/Release/MaterialDesignColors.pdb"; DestDir: "{app}"
Source: "bin/Release/MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"
Source: "bin/Release/MaterialDesignThemes.Wpf.pdb"; DestDir: "{app}"
Source: "bin/Release/MaterialDesignThemes.Wpf.xml"; DestDir: "{app}"
Source: "bin/Release/MigraDoc.DocumentObjectModel.netstandard.dll"; DestDir: "{app}"
Source: "bin/Release/MigraDoc.Rendering.netstandard.dll"; DestDir: "{app}"
Source: "bin/Release/Newtonsoft.Json.dll"; DestDir: "{app}"
Source: "bin/Release/Newtonsoft.Json.xml"; DestDir: "{app}"
Source: "bin/Release/PdfSharp.Charting.netstandard.dll"; DestDir: "{app}"
Source: "bin/Release/PdfSharp.netstandard.dll"; DestDir: "{app}"
Source: "bin/Release/System.Drawing.Common.dll"; DestDir: "{app}"
Source: "bin/Release/System.Net.Http.Extensions.dll"; DestDir: "{app}"
Source: "bin/Release/System.Net.Http.Formatting.dll"; DestDir: "{app}"
Source: "bin/Release/System.Net.Http.Primitives.dll"; DestDir: "{app}"
Source: "bin/Release/Verify-Your-Business.exe"; DestDir: "{app}"
Source: "bin/Release/Verify-Your-Business.exe.config"; DestDir: "{app}"
Source: "bin/Release/Verify-Your-Business.pdb"; DestDir: "{app}"
Source: "bin/Release/Verify-Your-Business-Library.dll"; DestDir: "{app}"


[Icons]
Name: "{autoprograms}\Verify-Your-Business"; Filename: "{app}\Verify-Your-Business.exe"
Name: "{autodesktop}\Verify-Your-Business"; Filename: "{app}\Verify-Your-Business.exe"
