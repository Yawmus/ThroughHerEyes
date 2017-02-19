using UnityEngine;
using System.Collections;

public class CreditCard : MonoBehaviour {

	float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.fixedDeltaTime;
		if (timer > 25f)
			Application.LoadLevel ("MainMenu");
	}
}
