using UnityEngine;
using System.Collections;

public class HatsController : MonoBehaviour {
	
  void Start(){
    var currentHat = Inventory.GetInstance().GetCurrentHat();
    if (currentHat != "none")
    {
      Wear(currentHat);
    }
  }

  public void Wear(string hatName){    
    HideAll();
    if (hatName != "none")
    {
      this.transform.FindChild(hatName).gameObject.SetActive(true);
    }
  }

  void HideAll(){
    foreach (Transform hat in this.transform)
    {
      hat.gameObject.SetActive(false);
    }
  }
}
