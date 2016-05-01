using UnityEngine;
using System.Collections;

public class PlayerMoveDetector : MonoBehaviour {

  AudioSource audioSource;

  void Start(){
    audioSource = GetComponent<AudioSource>();
  }

  public void OnPlayerMove(object playAreaName){
    HideGuiByScene.playerScene = playAreaName.ToString();
    audioSource.Play();
  }
}
