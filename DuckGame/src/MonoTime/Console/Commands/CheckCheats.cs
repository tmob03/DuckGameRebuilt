﻿using System.Linq;

namespace DuckGame
{
    public static partial class DevConsoleCommands
    {
        [DevConsoleCommand(Description = "Checks if you qualify as a cheater for the developer console")]
        public static string CheckCheats()
        {
            if (Network.isActive && !Network.connections.Any())
                return "|DGBLUE|PASS | Sole online player";

            if (NetworkDebugger.enabled)
                return "|DGBLUE|PASS | NetworkDebugger.enabled";

            ulong[] specialUsers =
            {
                76561197996786074UL,    // landon
                76561198885030822UL,    // landon alt
                76561198416200652UL,    // landon alt
                76561198104352795UL,    // dord
                76561198114791325UL,    // collin
            };
            ulong[] extraSpecialUsers =
            {
                76561198090678474UL,    // tater 
                76561198441121574UL,    // klof
                76561198797606383UL,    // othello
            };

            if (Steam.user is null)
                return "|DGBLUE|PASS | Steam inactive";

            if (specialUsers.Contains(Steam.user.id))
                return "|DGBLUE|PASS | Exempt by landon";

            if (extraSpecialUsers.Contains(Steam.user.id))
                return "|DGBLUE|PASS | Exempt by Tater";

            if (Network.isActive)
                return "|RED|FAIL | Online with other players";

            if (Level.current is ChallengeLevel or ArcadeLevel)
                return "|RED|FAIL | Arcade";

            return "|DGBLUE|PASS | Passed all cheater checks";
        }
    }
}