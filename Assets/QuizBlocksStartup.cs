using Platypus;
using UnityEngine;
using System.Collections;

public class QuizBlocksStartup : MonoBehaviour {
	
	void Start () {
    var input = new InputDevice ("bez", KeyboardInputMap.Create ());
    GameSupervisor.GetInstance().AddPlayer(input);
	}
	
}
