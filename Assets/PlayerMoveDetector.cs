using UnityEngine;
using System.Collections;

public class PlayerMoveDetector : MonoBehaviour {

  public void OnPlayerMove(object playAreaName){
    Debug.Log("OnPlayerMove: " + playAreaName.ToString());
    HideGuiByScene.playerScene = playAreaName.ToString();
  }
}
