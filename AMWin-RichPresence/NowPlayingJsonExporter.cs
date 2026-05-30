using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace AMWin_RichPresence {
internal static class NowPlayingJsonExporter {
private static readonly object fileLock = new();

public static string DefaultPath => Path.Combine(Constants.AppDataFolder, "nowplaying.json");

public static void Export(AppleMusicInfo? info, bool includeLyrics = true, string? path = null) {
if (info == null) return;

var data = new Dictionary<string, object?> {
{"title", info.SongName},
{"artist", info.SongArtist},
{"album", info.SongAlbum},
{"subtitle", info.SongSubTitle},
{"coverArtUrl", info.CoverArtUrl},
{"songUrl", info.SongUrl},
{"artistUrl", info.ArtistUrl},
{"isPaused", info.IsPaused},
{"isNowPlaying", !info.IsPaused},
{"currentTime", info.CurrentTime},
{"duration", info.SongDuration},
{"progress", (info.CurrentTime.HasValue && info.SongDuration.HasValue && info.SongDuration > 0) ? (double)info.CurrentTime.Value / info.SongDuration.Value : (double?)null},
{"startedAtUtc", info.PlaybackStart?.ToString("o")},
{"endsAtUtc", info.PlaybackEnd?.ToString("o")},
{"lyrics", includeLyrics ? info.SyncedLyrics : null}
};

var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
var target = path ?? DefaultPath;
var dir = Path.GetDirectoryName(target);
if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

lock (fileLock) {
File.WriteAllText(target, json);
}
}
}
}