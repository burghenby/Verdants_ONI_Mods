using Klei.AI;
using System;
using System.Collections.Generic;
using System.Text;
using TUNING;

namespace TraitsNotIncluded.Content.Scripts
{
#nullable disable
    internal class TNI_BoneChilled : StateMachineComponent<TNI_BoneChilled.StatesInstance>
    {
        public const string ID = "BoneChilled";

        public static DUPLICANTSTATS.TraitVal GetTrait()
        {
            return new DUPLICANTSTATS.TraitVal()
            {
                id = "BoneChilled"
            };
        }
        protected override void OnSpawn() => this.smi.StartSM();

        public class StatesInstance :
          GameStateMachine<TNI_BoneChilled.States, TNI_BoneChilled.StatesInstance, TNI_BoneChilled, object>.GameInstance
        {
            [MyCmpAdd]
            private SpaceHeater _spaceHeater;
            private ColdBreather _coldBreather;
            private RadiationEmitter _radiationEmitter;
            public AttributeModifier coldImmunity;
            public AttributeModifier luminescenceModifier;

            public StatesInstance(TNI_BoneChilled master)
              : base(master)
            {
                this._coldBreather.deltaEmitTemperature = -5f;
                this._radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
                this._spaceHeater.radius = 2;
                this.coldImmunity = new AttributeModifier(Db.Get().Attributes.ScoldingThreshold.Id, TNI_TRAITS.BONECHILLED_SCOLDING_IMMUNITY, (string)STRINGS.DUPLICANTS.TRAITS.TNI_BONECHILLED.NAME);
                this.luminescenceModifier = new AttributeModifier(Db.Get().Attributes.Luminescence.Id, TNI_TRAITS.BONECHILLED_AURA_LUX, (string)STRINGS.DUPLICANTS.TRAITS.TNI_BONECHILLED.NAME);
            }
        }

        public class States : GameStateMachine<TNI_BoneChilled.States, TNI_BoneChilled.StatesInstance, TNI_BoneChilled>
        {
            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                default_state = (StateMachine.BaseState)this.root;
                this.root.ToggleComponent<RadiationEmitter>().ToggleAttributeModifier("Luminescence Modifier", (Func<TNI_BoneChilled.StatesInstance, AttributeModifier>)(smi => smi.luminescenceModifier));
            }
        }
    }
}