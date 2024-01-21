using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AttackDuckAlchemistPath.Displays.Towers
{
  class GumballTurretDisplay : ModDisplay
  {

    // Copy the Boomerang Monkey display
    public override string BaseDisplay => "68327dd22d8f90243a06b44e896e5a0e";
    //public override string BaseDisplay => GetDisplay(TowerType.DartlingGunner,0,0,3);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
      // Print info about the node in order to edit it easier
      //node.PrintInfo();
      //for (int i = 0; i <= 12; i++)
      //{
      //  node.SaveMeshTexture(i);
      //}



      // Set our custom texture
      SetMeshTexture(node, Name+"0",0);
      SetMeshTexture(node, Name+"0",1);
      SetMeshTexture(node, Name+"0",2);
      SetMeshTexture(node, Name+"0",3);
      SetMeshTexture(node, Name+"0",4);
      SetMeshTexture(node, Name+"0",5);

      SetMeshTexture(node, Name+"1",7);
      SetMeshTexture(node, Name+"1",8);
      SetMeshTexture(node, Name+"1",9);

      SetMeshOutlineColor(node, new Color(2f / 255, 11f / 255, 12f / 255),0);
      SetMeshOutlineColor(node, new Color(2f / 255, 11f / 255, 12f / 255),1);
      SetMeshOutlineColor(node, new Color(229f / 255, 0f / 255, 168f / 255),2);
      SetMeshOutlineColor(node, new Color(229f / 255, 0f / 255, 168f / 255),3);
      SetMeshOutlineColor(node, new Color(229f / 255, 0f / 255, 168f / 255),4);
      SetMeshOutlineColor(node, new Color(229f / 255, 0f / 255, 168f / 255),7);
      SetMeshOutlineColor(node, new Color(229f / 255, 0f / 255, 168f / 255),8);

      // Make it not hold the Boomerang
      //node.RemoveBone("SuperMonkeyRig:Dart");
    }
  }
}
