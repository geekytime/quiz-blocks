using UnityEngine;
using System.Collections;

public class HatsController : MonoBehaviour {
	
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
