using Platypus;
using UnityEngine;


public class JumpSound : MonoBehaviour {
  EntityActions entityActions;
  public AudioSource Sound;

  void Start(){
    entityActions = GetComponent<EntityActions>();
  }

  void Update(){
    if (entityActions.JumpStart)
    {
      Debug.Log("jump");
      Sound.Play();
    }
  }
}
