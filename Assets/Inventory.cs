using UnityEngine;
using System.Collections.Generic;

public class Inventory {

  static Inventory instance;
  static List<string> hats = new List<string>();

  public static Inventory GetInstance(){
    if (instance == null){
      instance = new Inventory();
    }
    return instance;
  }

  int coins = 100;

  public void AddCoin(){
    coins = coins + 1;
  }

  public int GetCoinCount(){
    return coins;
  }

  public bool BuyItem(int cost, string itemType, string itemKey){    
    if (coins < cost)
    {
      return false;
    }

    coins = coins - cost;
    if (itemType == "hat")
    {       
      hats.Add(itemKey);
      ActivateHat(itemKey);
    }
    return true;
  }

  void ActivateHat(string hatName){
    var hats = GameObject.Find("player-hats").GetComponent<HatsController>();
    hats.Wear(hatName);
  }
    	
}
