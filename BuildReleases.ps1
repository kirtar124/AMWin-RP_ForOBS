# Run this to generate releases. You need to supply the publish profiles.

dotnet publish AMWin-RichPresence/AMWin-RichPresence.csproj -c Release -r win-x64 --self-contained true

$projectPath = "AMWin-RichPresence\AMWin-RichPresence.csproj"
$xml = [xml](Get-Content $projectPath)
$fileVersion = $xml.Project.PropertyGroup.FileVersion

cd AMWin-RichPresence/bin/Publish

Compress-Archive -Force -Path "arm64-WithRuntime/*" -DestinationPath "AMWin-RichPresence-v$fileVersion-arm64.zip"
Compress-Archive -Force -Path "x64-WithRuntime/*" -DestinationPath "AMWin-RichPresence-v$fileVersion-x64.zip"
Compress-Archive -Force -Path "arm64-NoRuntime/AMWin-RichPresence.exe" -DestinationPath "AMWin-RichPresence-v$fileVersion-arm64-NoRuntime.zip"
Compress-Archive -Force -Path "x64-NoRuntime/AMWin-RichPresence.exe" -DestinationPath "AMWin-RichPresence-v$fileVersion-x64-NoRuntime.zip"

cd ../../..