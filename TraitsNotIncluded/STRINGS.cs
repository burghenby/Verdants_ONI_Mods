using STRINGS;
using System;
using System.Collections.Generic;
using System.Text;

namespace TraitsNotIncluded
{
    internal class STRINGS
    {
        public class DUPLICANTS
        {
            public class TRAITS
            {
                public class TNI_CANTRANCH
                {
                    public static LocString NAME = "Hates Critters";
                    public static LocString DESC = "This Duplicant hates critters! Especially THAT one!";
                    public static LocString SHORT_DESC = "Cannot perform ranching tasks.";
                    public static LocString SHORT_DESC_TOOLTIP = "Cannot perform ranching tasks.";
                }
                public class TNI_CANTFARM
                {
                    public static LocString NAME = "Black Thumb";
                    public static LocString DESC = "This Duplicant should never be in charge of your plants.";
                    public static LocString SHORT_DESC = "Cannot perform farming tasks.";
                    public static LocString SHORT_DESC_TOOLTIP = "Cannot perform farming tasks.";
                }
                public class TNI_CANTOPERATE
                {
                    public static LocString NAME = "Walking Techbane";
                    public static LocString DESC = "Never let this Duplicant touch a machine you don't want broken.";
                    public static LocString SHORT_DESC = "Cannot perform machinery tasks.";
                    public static LocString SHORT_DESC_TOOLTIP = "Cannot operate machinery.";
                }
                public class TNI_THRESHOLDEFFECT
                {
                    public static LocString NAME = "Threshold Effect";
                    public static LocString DESC = "This Duplicant swears they entered this room for a reason...";
                    public static LocString SHORT_DESC = "Cannot perform ranching tasks.";
                    public static LocString SHORT_DESC_TOOLTIP = "Cannot perform ranching tasks.";
                }
                public class TNI_MIGRAINES
                {
                    public static LocString NAME = "Migraines";
                    public static LocString DESC = "Why does the colony need so many bright lights?";
                    public static LocString SHORT_DESC = "Exposure to lights can cause increased stress, but time spent in dark, natural environments brings relief.";
                    public static LocString SHORT_DESC_TOOLTIP = "Lights are stressful; dark, natural surroundings bring relief.";
                }
                public class TNI_INSOMNIA
                {
                    public static LocString NAME = "Insomniac";
                    public static LocString DESC = "This Duplicant's sleep schedule doesn't always match the rest of the colony.";
                    public static LocString SHORT_DESC = "Has a chance of treating sleep period as work or downtime, especially if espresso was drank before bed.";
                    public static LocString SHORT_DESC_TOOLTIP = "Has a chance to work or play instead of sleeping, especially if espresso is consumed.";
                }
                public class TNI_MUNCHIES
                {
                    public static LocString NAME = "Munchies";
                    public static LocString DESC = "This Duplicant just can't resist a nibble.";
                    public static LocString SHORT_DESC = "Has a chance of eating unswept and unharvested food when running past.";
                    public static LocString SHORT_DESC_TOOLTIP = "Has a chance of eating unswept and unharvested food when running past.";
                }
                public class TNI_VEGETARIAN
                {
                    public static LocString NAME = "Phytivorous";
                    public static LocString DESC = "There's nothing more satisfying that food grown straight from the planter.";
                    public static LocString SHORT_DESC = "Will only eat meals that contain no meat unless absolutely necessary. If meat is consumed, bathroom trips will come faster and take longer for the next 1.5 cycle.";
                    public static LocString SHORT_DESC_TOOLTIP = "Consuming meat gives this Duplicant bathroom troubles.";
                }
                public class TNI_CARNIVORE
                {
                    public static LocString NAME = "Carnivorous";
                    public static LocString DESC = "This Duplicant never has to worry about iron deficiency!";
                    public static LocString SHORT_DESC = "A meal that doesn't contain meat will make this Duplicant stressed with disappointment.";
                    public static LocString SHORT_DESC_TOOLTIP = "A meal that doesn't contain meat makes this Duplicant disappointed.";
                }
                public class TNI_CELIAC
                {
                    public static LocString NAME = "Grain Grouse";
                    public static LocString DESC = "This Duplicant is hoping the colony can provide grain-free alternatives.";
                    public static LocString SHORT_DESC = "Will not eat grain foods or drink brackene unless necessary but cannot resist a Frost Burger. If Sleet Wheat Grain or Brakene is consumed, will have to use the bathroom sooner and for longer for the next day.";
                    public static LocString SHORT_DESC_TOOLTIP = "Eating anything made from grain will give this Duplicant bathroom trouble.";
                }
                public class TNI_ICHTHYOPHOBIA
                {
                    public static LocString NAME = "Ichthyophobia";
                    public static LocString DESC = "Living or fried, this Duplicant wants nothing to do with that scaly hide.";
                    public static LocString SHORT_DESC = "Will not eat food containing fish unless necessary. Will flee at the presence of fish.";
                    public static LocString SHORT_DESC_TOOLTIP = "Won't eat fish unless desperate and will flee at the sight of fish.";
                }
                public class TNI_HEATPROOF
                {
                    public static LocString NAME = "Heat Proof";
                    public static LocString DESC = "This Duplicant could almost swim in magma, but best not to test it.";
                    public static LocString SHORT_DESC = "Unaffected by most warm temperatures.";
                    public static LocString SHORT_DESC_TOOLTIP = "Unaffected by most warm temperatures.";
                }
                public class TNI_BONECHILLED
                {
                    public static LocString NAME = "Bone Chilled";
                    public static LocString DESC = "This Duplicant is cooler than chewing mint gum after swishing mouthwash.";
                    public static LocString SHORT_DESC = "Immune to the effects of cold. Emits a persistent cool aura.";
                    public static LocString SHORT_DESC_TOOLTIP = "Cannot operate machinery; has a cool aura.";
                }
                public class TNI_HOTSTUFF
                {
                    public static LocString NAME = "Hot Stuff";
                    public static LocString DESC = "This Duplicant is hot hot HOT.";
                    public static LocString SHORT_DESC = "Immune to the effects of heat. Emits a persistent warm aura.";
                    public static LocString SHORT_DESC_TOOLTIP = "Immune to the effects of heat; has a warm aura.";
                }
            }
            public class STATUS
            {
                public class TNI_COOLING
                {
                    public static LocString NAME = "Cool Aura";
                    public static LocString TOOLTIP = "A cooling aura is radiating from this Duplicant.";
                }
                public class TNI_MUNCHIES
                {
                    public static LocString NAME = "Munchies";
                    public static LocString TOOLTIP = "This Duplicant has a sudden craving!";
                }
            }
            public class MODIFIERS
            {
                public class TNI_MUNCHIES
                {
                    public static LocString NAME = (LocString)"Snack Time";
                    public static LocString TOOLTIP = (LocString)$"This Duplicant has a sudden craving and can't resist stopping what their doing for a quick snack.";
                    public static LocString NOTIFICATION_NAME = (LocString)"Munchies";
                    public static LocString NOTIFICATION_TOOLTIP = (LocString)$"These Duplicants has a sudden craing and stopped what they were doing for a quick snack:";
                }
            }
        }
    }
}