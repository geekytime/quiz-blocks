using UnityEngine;
using System.Collections;

public class PlayerMoveDetector : MonoBehaviour {

  public void OnPlayerMove(object playAreaName){
    HideGuiByScene.playerScene = playAreaName.ToString();
  }
}
