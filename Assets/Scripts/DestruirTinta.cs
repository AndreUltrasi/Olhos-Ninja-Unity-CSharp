using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTinta : MonoBehaviour {
	public float timerTinta = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Item.timerTinta == true){
			timerTinta -= Time.deltaTime;
			if(timerTinta<=0){
				Destroy (gameObject);
			}
		}
	}
}
