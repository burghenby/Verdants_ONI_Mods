using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using static STRINGS.DUPLICANTS.TRAITS;

namespace TraitsNotIncluded.Content.Scripts
{
    internal class TNI_CantRanch
    {
        public const string ID = "CantRanch";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "CantRanch",
                statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
                rarity = DUPLICANTSTATS.RARITY_EPIC,
                mutuallyExclusiveTraits = new List<string>()
              {
                    "RanchingDown",
                    "RanchingUp",
                    "GrantSkill_Ranching1"
              }
            };
        }
    }
}