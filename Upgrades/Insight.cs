using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
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
  class Insight : UpgradePlusPlus<AlchemistPath>
  {
    public override int Cost => 270;
    public override int Tier => 2;
    //public override string Icon => GetTextureGUID(Name + "-Icon");

    public override string Description => "Grants camo detection and increased range.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

      towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

      towerModel.IncreaseRange(10f);

      // Add camo prio targetting
      towerModel.towerSelectionMenuThemeId = "Camo";
      AttackModel a = towerModel.GetAttackModel("AttackModel_Attack_");
      a.AddBehavior(new TargetFirstPrioCamoModel("TargetFirstPrioCamoModel_",true,false));
      a.AddBehavior(new TargetLastPrioCamoModel("TargetLastPrioCamoModel_",true,false));
      a.AddBehavior(new TargetClosePrioCamoModel("TargetClosePrioCamoModel_",true,false));
      a.AddBehavior(new TargetStrongPrioCamoModel("TargetStrongPrioCamoModel_",true,false));
      
    }
  }
}
