using System;
using System.Collections.Generic;
using System.Text;
using TUNING;

namespace TraitsNotIncluded.Content.Scripts
{
    internal class TNI_DUPLICANTSTATS
    {
        public static Dictionary<string, List<string>> ARCHETYPE_TRAIT_EXCLUSIONS = new Dictionary<string, List<string>>()
        {
            {
              "Mining",
              new List<string>() {
                  "Anemic",
                  "DiggingDown",
                  "Narcolepsy"
              }
            },
            {
              "Building",
              new List<string>()
              {
                "Anemic",
                "NoodleArms",
                "ConstructionDown",
                "DiggingDown",
                "Narcolepsy"
              }
            },
            {
              "Farming",
              new List<string>()
              {
                "Anemic",
                "NoodleArms",
                "BotanistDown",
                "RanchingDown",
                "Narcolepsy",
                "CantFarm"
              }
            },
            {
              "Ranching",
              new List<string>()
              {
                "RanchingDown",
                "BotanistDown",
                "Narcolepsy",
                "CantRanch"
              }
            },
            {
              "Cooking",
              new List<string>() {
                  "NoodleArms",
                  "CookingDown"
              }
            },
            {
              "Art",
              new List<string>() {
                  "ArtDown",
                  "DecorDown"
              }
            },
            {
              "Research",
              new List<string>() {
                  "SlowLearner"
              }
            },
            {
              "Suits",
              new List<string>() {
                  "Anemic",
                  "NoodleArms"
              }
            },
            {
              "Hauling",
              new List<string>() {
                  "Anemic",
                  "NoodleArms",
                  "Narcolepsy"
              }
            },
            {
              "Technicals",
              new List<string>() {
                  "MachineryDown",
                  "CantOperate"
              }
            },
            {
              "MedicalAid",
              new List<string>() {
                  "CaringDown",
                  "WeakImmuneSystem"
              }
            },
            {
              "Basekeeping",
              new List<string>() {
                  "Anemic",
                  "NoodleArms"
              }
            },
            {
              "Rocketry",
              new List<string>()
              {
                  "CantOperate"
              }
            }
        };

        public static List<DUPLICANTSTATS.TraitVal> BADTRAITS = new List<DUPLICANTSTATS.TraitVal>()
        {
            new DUPLICANTSTATS.TraitVal()
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
            },
            new DUPLICANTSTATS.TraitVal()
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
            },
            new DUPLICANTSTATS.TraitVal()
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
            }
        };

        public static List<DUPLICANTSTATS.TraitVal> GENESHUFFLERTRAITS = new List<DUPLICANTSTATS.TraitVal>()
        {
            new DUPLICANTSTATS.TraitVal()
            {
                id = "BoneChilled"
            },
            new DUPLICANTSTATS.TraitVal()
            {
                id = "HotStuff"
            }
        };

        public static List<DUPLICANTSTATS.TraitVal> GOODTRAITS = new List<DUPLICANTSTATS.TraitVal>()
        {
            new DUPLICANTSTATS.TraitVal()
            {
                id = "HeatProof",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "FrostProof"
                }
            }
        };
        public static List<DUPLICANTSTATS.TraitVal> NEEDTRAITS = new List<DUPLICANTSTATS.TraitVal>()
        {
            new DUPLICANTSTATS.TraitVal()
            {
                id = "Munchies",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "Phytivorous",
                    "Carnivorous",
                    "GrainGrouse",
                    "Ichthyophobia",
                    "Foodie"
                }
            },

            new DUPLICANTSTATS.TraitVal()
            {
                id = "Phytivorous",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "Foodie",
                    "SimpleTastes",
                    "Carnivorous",
                    "GrainGrouse",
                    "Ichthyophobia"
                }
            },

            new DUPLICANTSTATS.TraitVal()
            {
                id = "Carnivorous",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "Phytivorous",
                    "Foodie",
                    "SimpleTastes",
                    "GrainGrouse",
                    "Ichthyophobia"
                }
            },

            new DUPLICANTSTATS.TraitVal()
            {
                id = "GrainGrouse",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "Phytivorous",
                    "Carnivorous",
                    "Foodie",
                    "SimpleTastes",
                    "Ichthyophobia"
                }
            },

            new DUPLICANTSTATS.TraitVal()
            {
                id = "Ichthyophobia",
                rarity = DUPLICANTSTATS.RARITY_COMMON,
                mutuallyExclusiveTraits = new List<string>()
                {
                    "Phytivorous",
                    "Carnivorous",
                    "GrainGrouse",
                    "Foodie",
                    "SimpleTastes"
                }
            }
        };
    }
}
