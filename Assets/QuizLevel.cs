using UnityEngine;
using System.Collections;

public class QuizLevel : MonoBehaviour {

  public static QuizLevel instance;
  public TextMesh text;

  int level = 1;

  void Awake(){
    instance = this;

    level = PlayerPrefs.GetInt ("quiz-level");
    if (level <= 0) {
      level = 1;
    }
    text.text = level.ToString ();
  }
	
  public void GoUp(){
    level++;
    text.text = level.ToString ();
    PlayerPrefs.SetInt ("quiz-level", level);
    PlayerPrefs.Save ();
  }
}
