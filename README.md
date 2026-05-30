# 🎵 AMWin-RP_ForOBS


**AMWin-RP_ForOBS** is a customized Windows WPF application designed specifically for streamers and Apple Music users. It seamlessly extracts the currently playing track's metadata from the native Apple Music Windows app and exposes it to OBS overlays, Discord Rich Presence, and popular scrobbling services. 

Lightweight, practical, and highly customizable—this tool bridges the gap between Apple Music and your streaming workflow without any manual data handling.

---

## ✨ Key Features (English)

* **🎥 Exports real-time data :** Exports real-time playback data (metadata, timing, album art, and lyrics) into a structured `nowplaying.json` file.
* **💬 Discord Rich Presence:** Show off what you're currently listening to on your Discord profile in real-time.
* **🎵 Scrobbling Support:** Automatically scrobble your tracks to Last.fm and ListenBrainz.
* **⚙️ Comprehensive Settings:** A built-in UI to configure startup behavior, language, Apple Music region, and toggle specific integrations on or off.
* **📦 Portable & Standalone:** Runs straight out of the box. No separate .NET installation is required when using the prebuilt release.

## 🚀 Installation & Build

### Option 1: Download Prebuilt Release (Recommended)
1. Go to the [Releases](../../releases) page.
2. Download the latest `.zip` file for Windows x64.
3. Extract the folder and run `AMWin-RichPresence.exe`.
4. Right-click the system tray icon or open the app window to access the **Settings** and configure your JSON export path for OBS.

### Option 2: Build from Source
Ensure you have the [.NET 10 SDK](https://dotnet.microsoft.com/download) installed.
```bash
git clone [https://github.com/kirtar124/AMWin-RP_ForOBS.git](https://github.com/kirtar124/AMWin-RP_ForOBS.git)
cd AMWin-RP_ForOBS
dotnet publish AMWin-RichPresence/AMWin-RichPresence.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
