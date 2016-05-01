using Platypus;
using UnityEngine;
using System.Collections;


public class ShopItem : UsableActivated {

  public int Cost = 100;
  public string ItemType = "item";
  public string ItemKey = "item";
  bool available = true;

  TextMesh costText;
  SpriteRenderer icon;

  void Start(){
    costText = transform.FindChild("cost").GetComponent<TextMesh>();
    costText.text = Cost.ToString();

    icon = transform.FindChild("icon").GetComponent<SpriteRenderer>();

    if (Inventory.GetInstance().HasItem(ItemType, ItemKey))
    {
      Hide();
    }
  }

  public override void Activate(GameObject player){
    if (available)
    {
      var success = Inventory.GetInstance().BuyItem(Cost, ItemType, ItemKey);
      if (success)
      {
        Hide();
      }
    }
  }

  void Hide(){
    available = false;
    costText.gameObject.SetActive(false);
    icon.gameObject.SetActive(false);
  }
}
