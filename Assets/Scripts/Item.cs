using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	//public GameObject esquerdaItem;
	//public GameObject direitaItem;
	public GameObject tinta;
	private GameObject tempTinta;

	private bool isDead;

	private Vector3 Screen;

	public float minY;
	public float maxY;
	public static bool timerTinta = false;

	// Use this for initialization
	void Start () {
		minY = GerenciarCamera.MinY();
		maxY = GerenciarCamera.MaxY();
	}
	
	// Update is called once per frame
	void Update () {
		Remover ();
	}
	public void Remover(){
		Screen = Camera.main.WorldToScreenPoint(transform.position);
		if(isDead && Screen.y<minY){
			Destroy (gameObject);
		}else{
			isDead = true;
		}
	}

	public void InstanciarDestruir(){
		// instanciar tinta
		tempTinta = Instantiate (tinta,new Vector2(transform.position.x, transform.position.y), 
								 transform.rotation)  as GameObject;
		
		Destroy (gameObject);

		//timer para destruir a tinta
		timerTinta = true;
	}
}