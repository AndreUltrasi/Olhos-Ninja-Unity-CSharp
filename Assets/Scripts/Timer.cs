using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
	public float timeLeft = 60f;
	public UnityEngine.UI.Text txtTimer;
	int tmp;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if ((Mathf.RoundToInt(timeLeft))/60 >= 1){
			if(Mathf.RoundToInt(timeLeft)-60 < 10){
				txtTimer.text = "0" + ((Mathf.RoundToInt(timeLeft))/60).ToString () + ":0" + (Mathf.RoundToInt(timeLeft)-60).ToString ();
			}else{
				txtTimer.text = "0" + ((Mathf.RoundToInt(timeLeft))/60).ToString () + ":" + (Mathf.RoundToInt(timeLeft)-60).ToString ();
			}
		}else{
			if(Mathf.RoundToInt(timeLeft)<10){
				txtTimer.text = "00:0" + (Mathf.RoundToInt(timeLeft)).ToString ();
			}else{
				txtTimer.text = "00:"+ (Mathf.RoundToInt(timeLeft)).ToString ();
			}
		}

		if(timeLeft<0){
			SceneManager.LoadScene ("Final");
		}
	}
}
