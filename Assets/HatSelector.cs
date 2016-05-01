using Platypus;
using UnityEngine;
using System.Collections;

public class HatSelector : UsableActivated {

  public override void Activate(GameObject player){
    var hat = Inventory.GetInstance().GetNextHat();
    var hatsController = player.GetComponentInChildren<HatsController>();
    hatsController.Wear(hat);
  }

}
