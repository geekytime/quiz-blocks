using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {
	
  Text text;

	void Start () {
    text = GetComponent<Text>();
	}
	
	void Update () {    
    text.text = Inventory.GetInstance().GetCoinCount().ToString();
	}
}
