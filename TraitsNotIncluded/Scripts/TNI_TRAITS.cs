using HarmonyLib;
using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using static TraitsNotIncluded.STRINGS;
using static TraitsNotIncluded.STRINGS.DUPLICANTS.TRAITS;
using static TUNING.DUPLICANTSTATS;

namespace TraitsNotIncluded.Content.Scripts
{
    public class TNI_TRAITS
    {
        public static float HOTSTUFF_SCALDING_IMMUNITY = 999999f;
        public static float HOTSTUFF_AURA_LUX = 100f;
        public static float BONECHILLED_SCOLDING_IMMUNITY = -999999f;
        public static float BONECHILLED_AURA_LUX = 100f;

        [HarmonyPatch(typeof(Localization), "Initialize")]
        public static class Localization_Initialize_Patch
        {
            public static void Postfix()
            {
                RegisterTrait();
            }

            /// <summary>
            /// this has to be registered after localization has run, otherwise the translations of Traits break.
            /// </summary>
            static void RegisterTrait()
            {
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateDisabledTaskTrait("CantOperate", STRINGS.DUPLICANTS.TRAITS.TNI_CANTOPERATE.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_CANTOPERATE.DESC, "Machinery", true));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateDisabledTaskTrait("CantRanch", STRINGS.DUPLICANTS.TRAITS.TNI_CANTRANCH.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_CANTRANCH.DESC, "Ranching", true));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateDisabledTaskTrait("CantFarm", STRINGS.DUPLICANTS.TRAITS.TNI_CANTFARM.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_CANTFARM.DESC, "Farming", true));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateTrait(TNI_Munchies.ID, STRINGS.DUPLICANTS.TRAITS.TNI_MUNCHIES.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_MUNCHIES.DESC, new Action<GameObject>(TNI_TRAITS.OnAddMunchies)));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Vegetarian>("Phytivorous", STRINGS.DUPLICANTS.TRAITS.TNI_VEGETARIAN.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_VEGETARIAN.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Carnivore>("Carnivorous", STRINGS.DUPLICANTS.TRAITS.TNI_CARNIVORE.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_CARNIVORE.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Celiac>("GrainGrouse", STRINGS.DUPLICANTS.TRAITS.TNI_CELIAC.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_CELIAC.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Ichthyophobia>("Ichthyophobia", STRINGS.DUPLICANTS.TRAITS.TNI_ICHTHYOPHOBIA.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_ICHTHYOPHOBIA.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Migraines>("Migraines", STRINGS.DUPLICANTS.TRAITS.TNI_MIGRAINES.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_MIGRAINES.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_Insomnia>("Insomnia", STRINGS.DUPLICANTS.TRAITS.TNI_INSOMNIA.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_INSOMNIA.DESC));
                //TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_ThresholdEffect>("ThresholdEffect", STRINGS.DUPLICANTS.TRAITS.TNI_THRESHOLDEFFECT.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_THRESHOLDEFFECT.DESC));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateEffectModifierTrait("HeatProof", STRINGS.DUPLICANTS.TRAITS.TNI_HEATPROOF.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_HEATPROOF.DESC, new string[1]
                        {
                          "WarmAir"
                        }, true));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_BoneChilled>("BoneChilled", STRINGS.DUPLICANTS.TRAITS.TNI_BONECHILLED.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_BONECHILLED.DESC));
                TUNING.TRAITS.TRAIT_CREATORS.Add(TraitUtil.CreateComponentTrait<TNI_HotStuff>("HotStuff", STRINGS.DUPLICANTS.TRAITS.TNI_HOTSTUFF.NAME, STRINGS.DUPLICANTS.TRAITS.TNI_HOTSTUFF.DESC));

                //NEED TRAITS
                if (!DUPLICANTSTATS.NEEDTRAITS.Contains(TNI_Munchies.GetTrait()))
                {
                    DUPLICANTSTATS.NEEDTRAITS.Add(TNI_Munchies.GetTrait());
                    if (DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "Foodie"))
                    {
                        var foodie = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "Foodie");
                        if (foodie.mutuallyExclusiveTraits == null)
                        {
                            foodie.mutuallyExclusiveTraits = [TNI_Munchies.ID];
                        }
                        else
                        {
                            foodie.mutuallyExclusiveTraits.Add(TNI_Munchies.ID);
                        }
                    }
                }

                //BAD TRAITS
                if (!DUPLICANTSTATS.BADTRAITS.Contains(TNI_CantOperate.GetTrait()))
                {
                    DUPLICANTSTATS.BADTRAITS.Add(TNI_CantOperate.GetTrait());
                    if (DUPLICANTSTATS.BADTRAITS.Any(traitval => traitval.id == "MachineryDown") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "GreaseMonkey") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "GrantSkill_Technicals2"))
                    {
                        var machinerydown = DUPLICANTSTATS.BADTRAITS.First(traitval => traitval.id == "MachineryDown");
                        var greasemonkey = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "GreaseMonkey");
                        var technicals2 = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "GrantSkill_Technicals2");
                        if (machinerydown.mutuallyExclusiveTraits == null ||
                            greasemonkey.mutuallyExclusiveTraits == null ||
                            technicals2.mutuallyExclusiveTraits == null)
                        {
                            machinerydown.mutuallyExclusiveTraits = [TNI_CantOperate.ID];
                            greasemonkey.mutuallyExclusiveTraits = [TNI_CantOperate.ID];
                            technicals2.mutuallyExclusiveTraits = [TNI_CantOperate.ID];
                        }
                        else
                        {
                            machinerydown.mutuallyExclusiveTraits.Add(TNI_CantOperate.ID);
                            greasemonkey.mutuallyExclusiveTraits.Add(TNI_CantOperate.ID);
                            technicals2.mutuallyExclusiveTraits.Add(TNI_CantOperate.ID);
                        }
                    }
                }
                if (!DUPLICANTSTATS.BADTRAITS.Contains(TNI_CantFarm.GetTrait()))
                {
                    DUPLICANTSTATS.BADTRAITS.Add(TNI_CantFarm.GetTrait());
                    if (DUPLICANTSTATS.BADTRAITS.Any(traitval => traitval.id == "BotanistDown") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "GreenThumb") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "GrantSkill_Farming2"))
                    {
                        var botanistdown = DUPLICANTSTATS.BADTRAITS.First(traitval => traitval.id == "BotanistDown");
                        var greenthumb = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "GreenThumb");
                        var farming2 = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "GrantSkill_Farming2");
                        if (botanistdown.mutuallyExclusiveTraits == null ||
                            greenthumb.mutuallyExclusiveTraits == null ||
                            farming2.mutuallyExclusiveTraits == null)
                        {
                            botanistdown.mutuallyExclusiveTraits = [TNI_CantFarm.ID];
                            greenthumb.mutuallyExclusiveTraits = [TNI_CantFarm.ID];
                            farming2.mutuallyExclusiveTraits = [TNI_CantFarm.ID];
                        }
                        else
                        {
                            botanistdown.mutuallyExclusiveTraits.Add(TNI_CantFarm.ID);
                            greenthumb.mutuallyExclusiveTraits.Add(TNI_CantFarm.ID);
                            farming2.mutuallyExclusiveTraits.Add(TNI_CantFarm.ID);
                        }
                    }
                }
                if (!DUPLICANTSTATS.BADTRAITS.Contains(TNI_CantRanch.GetTrait()))
                {
                    DUPLICANTSTATS.BADTRAITS.Add(TNI_CantRanch.GetTrait());
                    if (DUPLICANTSTATS.BADTRAITS.Any(traitval => traitval.id == "RanchingDown") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "RanchingUp") ||
                        DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "GrantSkill_Ranching1"))
                    {
                        var ranchingdown = DUPLICANTSTATS.BADTRAITS.First(traitval => traitval.id == "RanchingDown");
                        var ranchingup = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "RanchingUp");
                        var ranching1 = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "GrantSkill_Ranching1");
                        if (ranchingdown.mutuallyExclusiveTraits == null ||
                            ranchingup.mutuallyExclusiveTraits == null ||
                            ranching1.mutuallyExclusiveTraits == null)
                        {
                            ranchingdown.mutuallyExclusiveTraits = [TNI_CantRanch.ID];
                            ranchingup.mutuallyExclusiveTraits = [TNI_CantRanch.ID];
                            ranching1.mutuallyExclusiveTraits = [TNI_CantRanch.ID];
                        }
                        else
                        {
                            ranchingdown.mutuallyExclusiveTraits.Add(TNI_CantRanch.ID);
                            ranchingup.mutuallyExclusiveTraits.Add(TNI_CantRanch.ID);
                            ranching1.mutuallyExclusiveTraits.Add(TNI_CantRanch.ID);
                        }
                    }
                }

                //GOOD TRAITS
                if (!DUPLICANTSTATS.GOODTRAITS.Contains(TNI_HeatProof.GetTrait()))
                {
                    DUPLICANTSTATS.GOODTRAITS.Add(TNI_HeatProof.GetTrait());
                    if (DUPLICANTSTATS.GOODTRAITS.Any(traitval => traitval.id == "FrostProof"))
                    {
                        var frostproof = DUPLICANTSTATS.GOODTRAITS.First(traitval => traitval.id == "FrostProof");
                        if (frostproof.mutuallyExclusiveTraits == null)
                        {
                            frostproof.mutuallyExclusiveTraits = [TNI_HeatProof.ID];
                        }
                        else
                        {
                            frostproof.mutuallyExclusiveTraits.Add(TNI_HeatProof.ID);
                        }
                    }
                }
                //NEURAL TRAITS
                if (!DUPLICANTSTATS.GENESHUFFLERTRAITS.Contains(TNI_BoneChilled.GetTrait()))
                {
                    DUPLICANTSTATS.GENESHUFFLERTRAITS.Add(TNI_BoneChilled.GetTrait());
                }
                if (!DUPLICANTSTATS.GENESHUFFLERTRAITS.Contains(TNI_HotStuff.GetTrait()))
                {
                    DUPLICANTSTATS.GENESHUFFLERTRAITS.Add(TNI_HotStuff.GetTrait());
                }



            }
        }
        private static void OnAddMunchies(GameObject go)
        {
            StatusItem tierOneBehaviourStatusItem = new StatusItem("SignalGotMunchies", STRINGS.DUPLICANTS.STATUS.TNI_MUNCHIES.NAME, STRINGS.DUPLICANTS.STATUS.TNI_MUNCHIES.TOOLTIP, "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID);
            new StressBehaviourMonitor.Instance((IStateMachineTarget)go.GetComponent<KMonoBehaviour>(), (Func<ChoreProvider, Chore>)(chore_provider => (Chore)new StressEmoteChore((IStateMachineTarget)chore_provider, Db.Get().ChoreTypes.EmoteHighPriority, (HashedString)"anim_interrupt_binge_eat_kanim", new HashedString[1]
            {
                    (HashedString) "interrupt_binge_eat"
            }, KAnim.PlayMode.Once, (Func<StatusItem>)(() => tierOneBehaviourStatusItem))), (Func<ChoreProvider, Chore>)(chore_provider => (Chore)new TNI_Munchies((IStateMachineTarget)chore_provider)), "anim_loco_binge_eat_kanim", 8f).StartSM();
        }

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