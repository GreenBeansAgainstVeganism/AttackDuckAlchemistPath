using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
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
  class PhilosophersStone : UpgradePlusPlus<AlchemistPath>
  {
    public override int Cost => 45000;
    public override int Tier => 5;

    public override string DisplayName => "Philosopher's Stone";
    //public override string Icon => GetTextureGUID(Name + "-Icon");

    public override string Description => "The power of the stone grants any monkey that holds it supermonkey strength. Equivalent Exchange Ability: empties your wallet and deals as much damage as you had cash to every bloon on screen.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
      towerModel.IncreaseRange(10f);

      WeaponModel weapon = towerModel.GetAttackModel("AttackModel_Attack_").weapons[0];

      weapon.rate /= 4f;

      ProjectileModel splash = weapon.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;

      splash.GetDamageModel().damage += 1f;
      //splash.GetBehavior<DamageModifierForBloonStateModel>().damageAdditive += 4f;
      splash.radius += 3f;
      splash.pierce += 5f;

      if(towerModel.tiers[0] >= 1)
      {
        splash.pierce += 10f;
      }

      splash.GetBehavior<AcidPoolModel>().pierce += 5f;

      AbilityModel ability = Game.instance.model.GetTowerFromId("Gwendolin 10").GetAbility(1).Duplicate();

      AttackModel abilityAttack = ability.GetBehavior<ActivateAttackModel>().attacks[0];
      ProjectileModel abilityProjectile = abilityAttack.weapons[0].projectile;

      ability.name = "AbilityModel_AttackDuckEquivalentExchange";
      ability.displayName = "Equivalent Exchange";
      ability.description = "Equivalent Exchange";
      ability.addedViaUpgrade = "Alchemist PhilosophersStone";
      ability.GetBehavior<ActivateAttackModel>().attacks = new AttackModel[1] { abilityAttack };

      abilityProjectile.RemoveBehavior<AddBehaviorToBloonModel>();
      abilityProjectile.RemoveBehavior<PierceUpTowersModel>();
      abilityProjectile.RemoveBehavior<HeatItUpDamageBuffModel>();
      abilityProjectile.filters = new FilterModel[0] { };
      abilityProjectile.GetBehavior<ProjectileFilterModel>().filters = new FilterModel[0] { };
      abilityProjectile.GetDamageModel().immuneBloonProperties = 0;
      abilityProjectile.GetDamageModel().overrideDistributeBlocker = true;

      towerModel.AddBehavior(ability);

    }
  }
}
