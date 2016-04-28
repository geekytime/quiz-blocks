using UnityEngine;
using System.Collections;

public class Prize : MonoBehaviour {

  public void Activate(){
    gameObject.SetActive(true);
  }

  public void Hide(){
    gameObject.SetActive(false);
  }
}
