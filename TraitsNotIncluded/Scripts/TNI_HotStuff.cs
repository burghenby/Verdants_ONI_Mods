using Klei.AI;
using System;
using System.Collections.Generic;
using System.Text;
using TUNING;

namespace TraitsNotIncluded.Content.Scripts
{
#nullable disable
    internal class TNI_HotStuff : StateMachineComponent<TNI_HotStuff.StatesInstance>
    {
        public const string ID = "HotStuff";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "HotStuff"
            };
        }
        protected override void OnSpawn() => this.smi.StartSM();

        public class StatesInstance :
          GameStateMachine<TNI_HotStuff.States, TNI_HotStuff.StatesInstance, TNI_HotStuff, object>.GameInstance
        {
            [MyCmpAdd]
            private SpaceHeater _spaceHeater;
            private RadiationEmitter _radiationEmitter;
            public AttributeModifier heatImmunity;
            public AttributeModifier luminescenceModifier;

            public StatesInstance(TNI_HotStuff master)
              : base(master)
            {
                this._spaceHeater.targetTemperature = 297f;
                this._radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
                this._spaceHeater.radius = 2;
                this.heatImmunity = new AttributeModifier(Db.Get().Attributes.ScaldingThreshold.Id, TNI_TRAITS.HOTSTUFF_SCALDING_IMMUNITY, (string)STRINGS.DUPLICANTS.TRAITS.TNI_HOTSTUFF.NAME);
                this.luminescenceModifier = new AttributeModifier(Db.Get().Attributes.Luminescence.Id, TNI_TRAITS.HOTSTUFF_AURA_LUX, (string)STRINGS.DUPLICANTS.TRAITS.TNI_HOTSTUFF.NAME);
            }
        }

        public class States : GameStateMachine<TNI_HotStuff.States, TNI_HotStuff.StatesInstance, TNI_HotStuff>
        {
            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                default_state = (StateMachine.BaseState)this.root;
                this.root.ToggleComponent<RadiationEmitter>().ToggleAttributeModifier("Luminescence Modifier", (Func<TNI_HotStuff.StatesInstance, AttributeModifier>)(smi => smi.luminescenceModifier));
            }
        }
    }
}