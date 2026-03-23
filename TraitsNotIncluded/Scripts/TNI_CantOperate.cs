using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace TraitsNotIncluded.Content.Scripts
{
    internal class TNI_CantOperate
    {
        public const string ID = "CantOperate";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "CantOperate",
                statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
                rarity = DUPLICANTSTATS.RARITY_EPIC,
                mutuallyExclusiveTraits = new List<string>()
              {
                    "MachineryDown",
                    "GreaseMonkey",
                    "GrantSkill_Technicals2"
              }
            };
        }
    }
}
