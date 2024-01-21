using MelonLoader;
using BTD_Mod_Helper;
using AttackDuckAlchemistPath;
using PathsPlusPlus;
using Il2CppAssets.Scripts.Models.Towers;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;

[assembly: MelonInfo(typeof(AttackDuckAlchemistPath.AttackDuckAlchemistPath), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AttackDuckAlchemistPath
{
  public class AttackDuckAlchemistPath : BloonsTD6Mod
  {
      public override void OnApplicationStart()
      {
          ModHelper.Msg<AttackDuckAlchemistPath>("AttackDuckAlchemistPath loaded!");
      }
  }

  public class AlchemistPath : PathPlusPlus
  {
    public override string Tower => TowerType.Alchemist;

    //public override int UpgradeCount => 5; // Increase this up to 5 as you create your Upgrades
  }

  [HarmonyPatch(typeof(Ability), nameof(Ability.Activate))]
  internal class Ability_Activate
  {
    [HarmonyPostfix]
    internal static void Postfix(Ability __instance)
    {
      Ability a = __instance;
      if(a.abilityModel.name.Equals("AbilityModel_AttackDuckEquivalentExchange"))
      {
        double cash = InGame.instance.GetCash();
        ModHelper.Msg<AttackDuckAlchemistPath>("Detected ability use... cash = "+cash);
        InGame.instance.SetCash(0);
        a.abilityModel.GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].projectile.GetDamageModel().damage = (float) cash;
      }
    }
  }
}
