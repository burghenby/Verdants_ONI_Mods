using HarmonyLib;
using KMod;
using System.Collections.Generic;

namespace TraitsNotIncluded
{
    public class Mod : UserMod2
    {
        public static Harmony Harmony;
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            Harmony = harmony;
        }
        public override void OnAllModsLoaded(Harmony harmony, IReadOnlyList<KMod.Mod> mods)
        {
            base.OnAllModsLoaded(harmony, mods);
        }
    }
}