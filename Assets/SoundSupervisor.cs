using UnityEngine;
using System.Collections;

public class SoundSupervisor : MonoBehaviour {
	
  AudioSource[] sources;

	void Start () {
    sources = GetComponentsInChildren<AudioSource>();
	}

  public void Play(){
    sources [0].Play();
  }

}
