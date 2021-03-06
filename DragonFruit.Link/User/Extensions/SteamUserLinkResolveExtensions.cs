﻿// DragonFruit Link API Copyright 2020 (C) DragonFruit Network <inbox@dragonfruit.network>
// Licensed under the GNU GPLv3 License. Refer to the license.md file at the root of the repo for more info

using DragonFruit.Link.User.Requests;
using DragonFruit.Link.User.Responses;

namespace DragonFruit.Link.User.Extensions
{
    public static class SteamUserLinkResolveExtensions
    {
        /// <summary>
        /// Converts a user's vanity url segment to their SteamID64
        /// </summary>
        /// <param name="client">The <see cref="SteamApiRequest"/> to use</param>
        /// <param name="linkSegment">The segment of the vanity url the user chooses (if the overall link is https://steamcommunity.com/id/papa_curry to get their id pass "papa_curry")</param>
        /// <returns>The users SteamID64 (or null if the link was not found)</returns>
        public static ulong ResolveVanityUrl(this SteamApiClient client, string linkSegment)
        {
            var request = new SteamUserLinkResolveRequest(linkSegment);
            var response = client.Perform<SteamUserLinkResolveResponse>(request).LinkInfo;
            
            return response.Success ? response.Id : 0L;
        }
    }
}
