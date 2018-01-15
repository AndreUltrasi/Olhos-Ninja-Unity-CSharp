using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicio : MonoBehaviour {
	private Vector3 position;
	public GameObject sair;
	public GameObject iniciar;
	public GameObject final;
	public AudioSource musica;
	public static bool playing = true;
	//public AudioSource audioSource;
	void Start(){
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			CastRay ();
		}
		//Platform ();
	}
	void CastRay(){
		Ray ray;
		if (Application.platform == RuntimePlatform.Android) {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
		}else{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		}
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
		if(hit.collider.transform.name == "Iniciar"){
			SceneManager.LoadScene ("level1");
		}else if(hit.collider.transform.name == "Sair"){
			Application.Quit ();
		}else if(hit.collider.transform.name == "Final"){
			SceneManager.LoadScene ("Final");
		}else if(hit.collider.transform.name == "MusicaInicio"){
			if(musica.isPlaying){
				musica.Pause ();
				playing = false;
			}else{
				musica.Play ();
				playing = true;
			}
		}
	}
	private void Platform(){
		if (Application.platform == RuntimePlatform.Android){
			if (Input.touchCount == 1){
				// pega a posicao do toque na tela atraves de x, y e z
				position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, 
																		Input.GetTouch (0).position.y, 1));
				transform.position = new Vector2 (position.x, position.y);

				gameObject.GetComponent<Collider2D> ().enabled = true;
				return;
			}
		}else {
			// pega a posicao do mouse atraves de x, y e z
			position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, 
				Input.mousePosition.y, 0));

			transform.position = new Vector2 (position.x, position.y);
		}

	}
	
}
