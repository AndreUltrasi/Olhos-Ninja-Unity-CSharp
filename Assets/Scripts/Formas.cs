using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formas : MonoBehaviour {
	//public GameObject esquerdaItem;
	//public GameObject direitaItem;
	public GameObject tinta;

	public float forca;
	public float torque;
	private bool isDead;

	private Vector3 Screen;

	public float alpha = 1;
	public float red = 0.5f;
	public float green = 0.5f;
	public float blue = 0.5f;

	public float minY;
	public float maxY;

	//private float rotDirecao = 50;
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
		//GameObject tempItem = null;
		GameObject tempTinta = null;

		/*
		// instanciar item com sentido a esquerda
		tempItem = Instantiate (esquerdaItem,transform.position, transform.rotation)  as GameObject;
		tempItem.GetComponent<Rigidbody2D>().AddForce (-transform.right * forca);
		tempItem.GetComponent<Rigidbody2D> ().AddTorque (-torque);*/

		/*
		// instanciar item com sentido a direita
		tempItem = Instantiate (direitaItem,transform.position, transform.rotation)  as GameObject;
		tempItem.GetComponent<Rigidbody2D>().AddForce (transform.right * forca);
		tempItem.GetComponent<Rigidbody2D> ().AddTorque (torque);*/

		// instanciar tinta
		tempTinta = Instantiate (tinta,new Vector2(transform.position.x, transform.position.y), 
			transform.rotation)  as GameObject;

		//tempTinta.GetComponent<Tinta>().SetColor (red, green, blue, alpha);
		Destroy (gameObject);
	}
}
