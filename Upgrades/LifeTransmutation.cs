using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
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
  class LifeTransmutation : UpgradePlusPlus<AlchemistPath>
  {
    public override int Cost => 1200;
    public override int Tier => 3;
    //public override string Icon => GetTextureGUID(Name + "-Icon");

    public override string Description => "Potions instantly vaporize regen bloons and turn them into lives.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
      DamageModifierForTagModel regenDamage = new DamageModifierForTagModel("DamageModifierForTagModel_", "Grow", 1.0f, 9999999f,false,false);

      WeaponModel weapon = towerModel.GetAttackModel("AttackModel_Attack_").weapons[0];

      ProjectileModel splash = weapon.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;

      splash.hasDamageModifiers = true;

      splash.AddBehavior(regenDamage);
    }
  }
}
