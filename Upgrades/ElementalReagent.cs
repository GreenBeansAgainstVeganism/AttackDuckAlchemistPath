using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppSystem.IO;
using PathsPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDuckAlchemistPath.Upgrades
{
  class ElementalReagent : UpgradePlusPlus<AlchemistPath>
  {
    public override int Cost => 2000;
    public override int Tier => 4;
    //public override string Icon => GetTextureGUID(Name + "-Icon");

    public override string Description => "This mystical substance comes in bigger flasks and deals heavy bonus damage to anything that is glued, frozen, electrified, or on fire. Gains additional +1 damage for every subsequent effect if more than 1 are applied!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
      DamageModifierForBloonStateModel bonusDamageGeneral = new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "Glue,LaserShock1,LaserShock2,LaserShock3,LaserShock4,Ice,Burn,Firestorm,Dot", 1.0f, 3f, false, false, true);
      DamageModifierForBloonStateModel bonusDamageGlue = new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "Glue", 1.0f, 1f, false, false, true);
      DamageModifierForBloonStateModel bonusDamageIce = new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "Ice", 1.0f, 1f, false, false, true);
      DamageModifierForBloonStateModel bonusDamageShock = new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "LaserShock1,LaserShock2,LaserShock3,LaserShock4", 1.0f, 1f, false, false, true);
      DamageModifierForBloonStateModel bonusDamageFire = new DamageModifierForBloonStateModel("DamageModifierForBloonStateModel_", "Burn,Firestorm,Dot", 1.0f, 1f, false, false, true);

      WeaponModel weapon = towerModel.GetAttackModel("AttackModel_Attack_").weapons[0];

      weapon.rate *= 0.55f;

      ProjectileModel splash = weapon.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;

      splash.pierce += 5f;
      splash.radius += 3f;

      if(towerModel.tiers[0] >= 1)
      {
        splash.pierce += 10f;
      }

      //splash.GetBehavior<ClearHitBloonsModel>().interval -= 0.05f;
      //splash.GetBehavior<AcidPoolModel>().Lifespan += 0.05f;

      splash.hasDamageModifiers = true;

      splash.AddBehavior(bonusDamageGeneral);
      splash.AddBehavior(bonusDamageGlue);
      splash.AddBehavior(bonusDamageIce);
      splash.AddBehavior(bonusDamageShock);
      splash.AddBehavior(bonusDamageFire);
    }
  }
}
