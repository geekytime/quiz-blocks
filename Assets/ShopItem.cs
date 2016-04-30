using Platypus;
using UnityEngine;
using System.Collections;


public class ShopItem : UsableActivated {

  public int Cost = 100;
  public string ItemType = "item";
  public string ItemKey = "item";

  TextMesh costText;
  SpriteRenderer icon;

  void Start(){
    costText = transform.FindChild("cost").GetComponent<TextMesh>();
    costText.text = Cost.ToString();

    icon = transform.FindChild("icon").GetComponent<SpriteRenderer>();
  }

  public override void Activate(GameObject player){    
    var success = Inventory.GetInstance().BuyItem(Cost, ItemType, ItemKey);
    if (success)
    {
      costText.gameObject.SetActive(false);
      icon.gameObject.SetActive(false);
    }
  }
}
