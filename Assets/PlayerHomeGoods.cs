using UnityEngine;
using System.Collections;

public class PlayerHomeGoods : MonoBehaviour {

  void Start(){
    foreach (Transform child in transform)
    {
      var name = child.gameObject.name;
      if (Inventory.GetInstance().HasItem("homegoods", name))
      {
        child.gameObject.SetActive(true);
      } else
      {
//        child.gameObject.SetActive(false);
      }
    }
  }

  public void Show(string itemName){
    var child = transform.FindChild(itemName);
    if (child)
    {
      child.gameObject.SetActive(true);
    }
  }    

}
