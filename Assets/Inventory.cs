using UnityEngine;
using System.Collections.Generic;

public class Inventory
{

  static Inventory instance;
  List<string> hats;
  List<string> homegoods;
  int currentHatIndex = -1;
  HatsController playerHats;
  PlayerHomeGoods playerHomeGoods;

  public static Inventory GetInstance()
  {
    if (instance == null)
    {      
      instance = new Inventory();
      instance.LoadCoins();
      instance.LoadHats();
      instance.LoadHomeGoods();

      instance.playerHats = GameObject.Find("player-hats").GetComponent<HatsController>();
      instance.playerHomeGoods = GameObject.Find("player-home-goods").GetComponent<PlayerHomeGoods>();

    }
    return instance;
  }

  int coins = 0;

  public void AddCoins(int count)
  {
    coins = coins + count;
    SaveCoins();
  }

  public int GetCoinCount()
  {
    return coins;
  }

  public bool BuyItem(int cost, string itemType, string itemKey)
  {    
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
    if (itemType == "homegoods")
    {
      homegoods.Add(itemKey);
      ActivateHomeGood(itemKey);
      SaveHomeGoods();
    }
    return true;
  }

  public bool HasItem(string itemType, string itemKey)
  {
    if (itemType == "hat")
    {
      return hats.Contains(itemKey);
    }
    if (itemType == "homegoods")
    {
      return homegoods.Contains(itemKey);
    }
    return false;
  }

  void ActivateHat(string hatName)
  {    
    playerHats.Wear(hatName);
  }

  void ActivateHomeGood(string itemName)
  {
    Debug.Log("Activate:" + itemName);
    playerHomeGoods.Show(itemName);
  }

  void SaveHomeGoods()
  {
    PlayerPrefsEx.SetStringArray("homegoods", homegoods.ToArray());
    PlayerPrefs.Save();
  }

  void LoadHomeGoods()
  {
    homegoods = new List<string>(PlayerPrefsEx.GetStringArray("homegoods"));
  }

  public List<string> GetHats()
  {
    return hats;
  }

  void SaveCoins()
  {
    PlayerPrefs.SetInt("coins", coins);
    PlayerPrefs.Save();
  }

  void LoadCoins()
  {
    coins = PlayerPrefs.GetInt("coins");
  }


  void SaveHats()
  {
    PlayerPrefsEx.SetStringArray("hats", hats.ToArray());
    PlayerPrefs.SetInt("currentHatIndex", currentHatIndex);
    PlayerPrefs.Save();
  }

  void LoadHats()
  {
    hats = new List<string>(PlayerPrefsEx.GetStringArray("hats"));
    currentHatIndex = PlayerPrefs.GetInt("currentHatIndex");
  }

  public string GetNextHat()
  {
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
