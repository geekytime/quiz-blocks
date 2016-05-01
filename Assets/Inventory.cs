using UnityEngine;
using System.Collections.Generic;

public class Inventory {

  static Inventory instance;
  List<string> hats;
  int currentHatIndex = -1;

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

  public List<string> GetHats(){
    return hats;
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
    PlayerPrefs.SetInt("currentHatIndex", currentHatIndex);
    PlayerPrefs.Save();
  }

  void LoadHats(){
    hats = new List<string>(PlayerPrefsEx.GetStringArray("hats"));
    currentHatIndex = PlayerPrefs.GetInt("currentHatIndex");
  }

  public string GetNextHat(){
    if (currentHatIndex + 1 < hats.Count)
    {
      currentHatIndex++;
    } else
    {
      currentHatIndex = -1;
    }
    if (currentHatIndex == -1)
    {
      return "none";
    }
    return hats [currentHatIndex];
  }
    	
}
