using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudo : MonoBehaviour {
	// Use this for initialization
	public AudioSource musica;
	void Start () {
		if (TelaInicio.playing){
			musica.Play ();
		}else{
			musica.Pause ();
		}
	}
}
