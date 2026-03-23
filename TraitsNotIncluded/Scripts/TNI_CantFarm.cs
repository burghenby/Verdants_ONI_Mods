using Klei.AI;
using KSerialization;
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
    internal class TNI_CantFarm
    {
        public const string ID = "CantFarm";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "CantFarm",
                statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
                rarity = DUPLICANTSTATS.RARITY_EPIC,
                mutuallyExclusiveTraits = new List<string>()
              {
                    "GreenThumb",
                    "BotanistDown",
                    "GrantSkill_Farming2"
              }
            };
        }
    }
}