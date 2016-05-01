using UnityEngine;
using System.Collections.Generic;

public class Inventory {

  static Inventory instance;
  static List<string> hats;

  public static Inventory GetInstance(){
    if (instance == null){      
      instance = new Inventory();
      instance.LoadCoins();
      instance.LoadHats();
    }
    return instance;
  }

  int coins = 0;

  public void AddCoin(){
    coins = coins + 1;
    SaveCoins();
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
    SaveCoins();
    if (itemType == "hat")
    {       
      hats.Add(itemKey);
      ActivateHat(itemKey);
      SaveHats();
    }
    return true;
  }

  public bool HasItem(string itemType, string itemKey){
    if (itemType == "hat")
    {
      return hats.Contains(itemKey);
    }
    return false;
  }

  void ActivateHat(string hatName){
    var hats = GameObject.Find("player-hats").GetComponent<HatsController>();
    hats.Wear(hatName);
  }

  void SaveCoins(){
    PlayerPrefs.SetInt("coins", coins);
    PlayerPrefs.Save();
  }

  void LoadCoins(){
    coins = PlayerPrefs.GetInt("coins");
  }

  void SaveHats(){
    PlayerPrefsEx.SetStringArray("hats", hats.ToArray());
  }

  void LoadHats(){
    hats = new List<string>(PlayerPrefsEx.GetStringArray("hats"));
  }

    	
}
