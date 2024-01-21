using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
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
  class LingeringPotions : UpgradePlusPlus<AlchemistPath>
  {
    public override int Cost => 360;
    public override int Tier => 1;
    //public override string Icon => GetTextureGUID(Name + "-Icon");

    public override string Description => "Potions can damage bloons multiple times if they have remaining pierce. Also increases duration for the acid status effect, berserker brew and acid pools.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

      ClearHitBloonsModel rehit = new ClearHitBloonsModel("ClearHitBloonsModel_", 0.2f);

      ProjectileModel splash = towerModel.GetAttackModel("AttackModel_Attack_").weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;

      splash.GetBehavior<AcidPoolModel>().Lifespan += 0.4f;

      splash.GetBehavior<AddBehaviorToBloonModel>().lifespan += 2f;

      splash.AddBehavior(rehit);

      if(towerModel.tiers[2] >= 2)
      {
        splash.GetBehavior<AcidPoolModel>().LifespanIfMisses += 3f;
      }

      if(towerModel.tiers[0] >= 3)
      {
        towerModel.GetAttackModel("AttackModel_BerserkerBrewAttack_").GetDescendant<AddBerserkerBrewToProjectileModel>().lifespan += 3f;
      }

      // Reduce perishing potions' bonus damage towards fortified moabs because it's way too powerful with rehit
      if(towerModel.tiers[1] >= 2)
      {
        splash.GetBehaviors<DamageModifierForTagModel>().Find(m => m.tag.Equals("Moabs,Fortified")).damageAddative -= 10f;
        splash.GetBehaviors<DamageModifierForTagModel>().Find(m => m.tag.Equals("Moabs")).damageAddative -= 2f;
      }
    }
  }
}
