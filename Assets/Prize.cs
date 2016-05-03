using UnityEngine;
using System.Collections;

public class Prize : MonoBehaviour {

  public QuizRoom quizRoom;

  float delay = .75f;

  public void Activate(int count){
    for (var i = 0; i < count; i++)
    {
      Invoke("Hide", i * delay);
      Invoke("activate", i * delay);
    }
  }

  void activate(){
    gameObject.SetActive(true); 
    quizRoom.PlayCoinSound();
  }

  public void Hide(){
    gameObject.SetActive(false);
  }

}
