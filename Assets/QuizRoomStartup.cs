﻿using Platypus;
using UnityEngine;
using System.Collections;

public class QuizRoomStartup : MonoBehaviour {
	
	void Start () {
    GameSupervisor.GetInstance().AddPlayer(new InputDevice("bez", KeyboardInputMap.Create()));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
