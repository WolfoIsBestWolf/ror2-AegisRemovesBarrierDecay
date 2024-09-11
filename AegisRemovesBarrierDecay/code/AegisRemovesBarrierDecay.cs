using BepInEx;
using RoR2;
using R2API;
using System;
using UnityEngine;

namespace AegisRemovesBarrierDecay
{
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin("com.Wolfo.AegisRemovesBarrierDecay", "AegisRemovesBarrierDecay", "1.0.1")]
    public class AegisRemovesBarrierDecay : BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.CharacterBody.RecalculateStats += AegisNoDecay;
            LanguageAPI.Add("ITEM_BARRIERONOVERHEAL_PICKUP", "Healing past full grants you a barrier. Barrier no longer decays.", "en");
            LanguageAPI.Add("ITEM_BARRIERONOVERHEAL_DESC", "Healing past full grants you a <style=cIsHealing>barrier</style> for <style=cIsHealing>50% <style=cStack>(+50% per stack)</style></style> of the amount you <style=cIsHealing>healed</style>. All <style=cIsHealing>barrier</style> no longer naturally decays.", "en");
        }

        private void AegisNoDecay(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);
            if (self.inventory)
            {
                if (self.inventory.GetItemCount(RoR2Content.Items.BarrierOnOverHeal) > 0)
                {
                    self.barrierDecayRate = 0;
                }
            }
        }
    }
}