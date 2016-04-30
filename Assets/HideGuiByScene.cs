using UnityEngine;
using UnityEngine.SceneManagement;

public class HideGuiByScene : MonoBehaviour {

  public static string playerScene = "";

  Canvas canvas;

  void Awake(){
    canvas = GetComponent<Canvas>();
  }

	void Update () {    
    var enabled = (playerScene == "quiz-room");
    canvas.enabled = enabled;
	}
}
