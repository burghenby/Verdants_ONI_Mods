using Klei.AI;
using System;
using System.Collections.Generic;
using System.Text;
using TUNING;
using UnityEngine;

namespace TraitsNotIncluded.Content.Scripts
{
    internal class TNI_Munchies : Chore<TNI_Munchies.StatesInstance>
    {
        public const string ID = "Munchies";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
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
            };
        }
        private int onEatHandlerID;

        public TNI_Munchies(IStateMachineTarget target, Action<Chore> on_complete = null)
          : base(Db.Get().ChoreTypes.BingeEat, target, target.GetComponent<ChoreProvider>(), false, on_complete, master_priority_class: PriorityScreen.PriorityClass.compulsory)
        {
            this.smi = new TNI_Munchies.StatesInstance(this, target.gameObject);
            this.onEatHandlerID = this.Subscribe(1121894420, new Action<object>(this.OnEat));
        }

        private void OnEat(object data)
        {
            Edible edible = (Edible)data;
            if (!((UnityEngine.Object)edible != (UnityEngine.Object)null))
                return;
            double num = (double)this.smi.sm.munchiesremaining.Set(Mathf.Max(0.0f, this.smi.sm.munchiesremaining.Get(this.smi) - edible.unitsConsumed), this.smi);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            this.Unsubscribe(ref this.onEatHandlerID);
        }

        public class StatesInstance :
          GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.GameInstance
        {
            public StatesInstance(TNI_Munchies master, GameObject eater)
              : base(master)
            {
                this.sm.eater.Set(eater, this.smi, false);
                double num = (double)this.sm.munchiesremaining.Set(2f, this.smi);
            }

            public void FindFood()
            {
                Navigator component1 = this.GetComponent<Navigator>();
                int num1 = int.MaxValue;
                Edible edible = (Edible)null;
                if ((double)this.sm.munchiesremaining.Get(this.smi) <= (double)PICKUPABLETUNING.MINIMUM_PICKABLE_AMOUNT)
                {
                    this.GoTo((StateMachine.BaseState)this.sm.eat_pst);
                }
                else
                {
                    foreach (Edible cmp in Components.Edibles.Items)
                    {
                        if (!cmp.HasTag(GameTags.Dehydrated) && !((UnityEngine.Object)cmp == (UnityEngine.Object)null) && !((UnityEngine.Object)cmp == (UnityEngine.Object)this.sm.ediblesource.Get<Edible>(this.smi)) && !cmp.isBeingConsumed)
                        {
                            Pickupable component2 = cmp.GetComponent<Pickupable>();
                            if ((double)component2.UnreservedFetchAmount > 0.0 && component2.CouldBePickedUpByMinion(this.GetComponent<KPrefabID>().InstanceID) && !component2.HasTag(GameTags.StoredPrivate))
                            {
                                int navigationCost = component1.GetNavigationCost((IApproachable)cmp);
                                if (navigationCost != -1 && navigationCost < num1)
                                {
                                    num1 = navigationCost;
                                    edible = cmp;
                                }
                            }
                        }
                    }
                    this.sm.ediblesource.Set((KMonoBehaviour)edible, this.smi);
                    double num2 = (double)this.sm.requestedfoodunits.Set(this.sm.munchiesremaining.Get(this.smi), this.smi);
                    if ((UnityEngine.Object)edible == (UnityEngine.Object)null)
                        this.GoTo((StateMachine.BaseState)this.sm.cantFindFood);
                    else
                        this.GoTo((StateMachine.BaseState)this.sm.fetch);
                }
            }

            public bool IsMunching() => this.sm.isMunching.Get(this.smi);
        }

        public class States :
          GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies>
        {
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.TargetParameter eater;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.TargetParameter ediblesource;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.TargetParameter ediblechunk;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.BoolParameter isMunching;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.FloatParameter requestedfoodunits;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.FloatParameter actualfoodunits;
            public StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.FloatParameter munchiesremaining;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State noTarget;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State findfood;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State eat;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State eat_pst;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State cantFindFood;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State finish;
            public GameStateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.FetchSubState fetch;
            private Effect munchiesEffect;

            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                default_state = (StateMachine.BaseState)this.findfood;
                this.Target(this.eater);
                this.munchiesEffect = new Effect("Munchies", (string)STRINGS.DUPLICANTS.MODIFIERS.TNI_MUNCHIES.NAME, (string)STRINGS.DUPLICANTS.MODIFIERS.TNI_MUNCHIES.TOOLTIP, 0.0f, true, false, true);
                this.munchiesEffect.Add(new AttributeModifier(Db.Get().Attributes.Decor.Id, -10f, (string)STRINGS.DUPLICANTS.MODIFIERS.TNI_MUNCHIES.NAME));
                this.munchiesEffect.Add(new AttributeModifier("CaloriesDelta", -2000f, (string)STRINGS.DUPLICANTS.MODIFIERS.TNI_MUNCHIES.NAME));
                Db.Get().effects.Add(this.munchiesEffect);
                this.root.ToggleEffect((Func<TNI_Munchies.StatesInstance, Effect>)(smi => this.munchiesEffect));
                this.noTarget.GoTo(this.finish);
                this.eat_pst.ToggleAnims("anim_eat_overeat_kanim").PlayAnim("working_pst").OnAnimQueueComplete(this.finish);
                this.finish.Enter((StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State.Callback)(smi => smi.StopSM("complete/no more food")));
                this.findfood.Enter("FindFood", (StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State.Callback)(smi => smi.FindFood()));
                this.fetch.InitializeStates(this.eater, this.ediblesource, this.ediblechunk, this.requestedfoodunits, this.actualfoodunits, this.eat, this.cantFindFood);
                this.eat.ToggleAnims("anim_eat_overeat_kanim").QueueAnim("working_loop", true).Enter((StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State.Callback)(smi => this.isMunching.Set(true, smi))).DoEat(this.ediblechunk, this.actualfoodunits, this.findfood, this.findfood).Exit("ClearIsMunching", (StateMachine<TNI_Munchies.States, TNI_Munchies.StatesInstance, TNI_Munchies, object>.State.Callback)(smi => this.isMunching.Set(false, smi)));
                this.cantFindFood.ToggleAnims("anim_interrupt_binge_eat_kanim").PlayAnim("interrupt_binge_eat").OnAnimQueueComplete(this.noTarget);
            }
        }
    }
}
