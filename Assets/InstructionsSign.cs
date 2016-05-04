using UnityEngine;
using System.Collections;

public class InstructionsSign : MonoBehaviour {
	
  public GameObject Instructions;
  public GameObject Text;

  BoxCollider2D sensor;
  Collider2D[] colliders = new Collider2D[5];

	void Start () {
    sensor = GetComponent<BoxCollider2D>();	
	}
		
	void Update () {    
    Physics2D.OverlapAreaNonAlloc(sensor.bounds.min, sensor.bounds.max, colliders);
    foreach (var collider in colliders)
    {
      if (collider && collider.name == "bez")
      {
        Instructions.SetActive(true);
        Text.SetActive(false);
        return;
      }
    }
    Instructions.SetActive(false);
    Text.SetActive(true);
	}
}
