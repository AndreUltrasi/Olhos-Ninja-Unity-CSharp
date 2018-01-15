using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pontuacao : MonoBehaviour {
	public UnityEngine.UI.Text txtScore;
	public UnityEngine.UI.Text txtRecord;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Pontos");

	}

	// Update is called once per frame
	void Update () {
		
	}
	private IEnumerator Pontos(){
		PlayerPrefs.SetInt ("score", Player.score);
		if(PlayerPrefs.GetInt("record") <= PlayerPrefs.GetInt("score")){
			PlayerPrefs.SetInt("record",PlayerPrefs.GetInt("score")) ;
		}
		txtRecord.text = (PlayerPrefs.GetInt("record")).ToString();
		txtScore.text = (PlayerPrefs.GetInt("score")).ToString();
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene ("Inicio");

	}
}
