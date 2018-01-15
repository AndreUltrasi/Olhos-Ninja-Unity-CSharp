using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Iniciar : MonoBehaviour {
	private Vector3 position;
	
	// Update is called once per frame
	void Update () {
		Platform ();
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
	void OnTriggerEnter2D(Collider2D collisor){
		
	}
}
