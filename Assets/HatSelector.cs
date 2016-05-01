using Platypus;
using UnityEngine;
using System.Collections;

public class HatSelector : UsableActivated {

  AudioSource hatSound;

  void Start(){
    hatSound = GetComponent<AudioSource>();
  }

  public override void Activate(GameObject player){
    var hat = Inventory.GetInstance().GetNextHat();
    var hatsController = player.GetComponentInChildren<HatsController>();
    hatsController.Wear(hat);
    hatSound.Play();
  }

}
