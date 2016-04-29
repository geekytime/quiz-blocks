using UnityEngine;
using UnityEngine.SceneManagement;

public class HideGuiByScene : MonoBehaviour {

  public static string playerScene = "";

  Canvas canvas;

  void Awake(){
    canvas = GetComponent<Canvas>();
  }

	void Update () {
    Debug.Log(playerScene);
    var enabled = (playerScene == "quiz-room");
    canvas.enabled = enabled;
	}
}
