﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using osu.Game.Beatmaps;
using osu.Game.Rulesets;

namespace osu.Game.Online.API.Requests.Responses
{
    public class APIBeatmapSet : BeatmapMetadata // todo: this is a bit wrong...
    {
        [JsonProperty(@"covers")]
        private BeatmapSetOnlineCovers covers { get; set; }

        private int? onlineBeatmapSetID;

        [JsonProperty(@"id")]
        public int? OnlineBeatmapSetID
        {
            get { return onlineBeatmapSetID; }
            set { onlineBeatmapSetID = value > 0 ? value : null; }
        }

        [JsonProperty(@"preview_url")]
        private string preview { get; set; }

        [JsonProperty(@"play_count")]
        private int playCount { get; set; }

        [JsonProperty(@"favourite_count")]
        private int favouriteCount { get; set; }

        [JsonProperty(@"bpm")]
        private double bpm { get; set; }

        [JsonProperty(@"video")]
        private bool hasVideo { get; set; }

        [JsonProperty(@"storyboard")]
        private bool hasStoryboard { get; set; }

        [JsonProperty(@"status")]
        private BeatmapSetOnlineStatus status { get; set; }

        [JsonProperty(@"submitted_date")]
        private DateTimeOffset submitted { get; set; }

        [JsonProperty(@"ranked_date")]
        private DateTimeOffset? ranked { get; set; }

        [JsonProperty(@"last_updated")]
        private DateTimeOffset lastUpdated { get; set; }

        [JsonProperty(@"user_id")]
        private long creatorId
        {
            set { Author.Id = value; }
        }

        [JsonProperty(@"beatmaps")]
        private IEnumerable<APIBeatmap> beatmaps { get; set; }

        public BeatmapSetInfo ToBeatmapSet(RulesetStore rulesets)
        {
            return new BeatmapSetInfo
            {
                OnlineBeatmapSetID = OnlineBeatmapSetID,
                Metadata = this,
                OnlineInfo = new BeatmapSetOnlineInfo
                {
                    Covers = covers,
                    Preview = preview,
                    PlayCount = playCount,
                    FavouriteCount = favouriteCount,
                    BPM = bpm,
                    Status = status,
                    HasVideo = hasVideo,
                    HasStoryboard = hasStoryboard,
                    Submitted = submitted,
                    Ranked = ranked,
                    LastUpdated = lastUpdated,
                },
                Beatmaps = beatmaps?.Select(b => b.ToBeatmap(rulesets)).ToList(),
            };
        }
    }
}
