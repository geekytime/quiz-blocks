using UnityEngine;
using System.Collections;

public class Inventory {

  static Inventory instance;

  public static Inventory GetInstance(){
    if (instance == null){
      instance = new Inventory();
    }
    return instance;
  }

  int coins = 0;

  public void AddCoin(){
    coins = coins + 1;
  }

  public int GetCoinCount(){
    return coins;
  }
    	
}
