using Platypus;
using UnityEngine;
using System.Collections;


public class ShopItem : UsableActivated {

  public int Cost = 100;
  public string ItemType = "item";
  public string ItemKey = "item";

  public override void Activate(GameObject player){    
    Inventory.GetInstance().BuyItem(Cost, ItemType, ItemKey);
  }
}
