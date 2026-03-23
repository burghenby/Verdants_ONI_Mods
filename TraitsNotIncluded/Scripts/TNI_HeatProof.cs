using System;
using System.Collections.Generic;
using System.Text;
using TUNING;

namespace TraitsNotIncluded.Content.Scripts
{
    internal class TNI_HeatProof
    {
        public const string ID = "HeatProof";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "HeatProof",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "FrostProof"
                }
            };
        }
    }
}
