using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Player : MonoBehaviour {
	private Vector3 position;
	//private Score score;
	//private Vidas vida;
	//private Pause pause;
	//public GameObject gameOver;
	public AudioClip clipForma;

	// muda o nome da forma a ser cortada
	public UnityEngine.UI.Text txtForma;

	// muda a imagem da forma a ser cortada
	public UnityEngine.UI.Image imgForma;

	// numero aleatorio que pega o indice de uma forma qualquer
	public static int indexRandom;

	//pontuacao
	public UnityEngine.UI.Text txtScore;
	public UnityEngine.UI.Text txtFault;
	public static int score;
	public static int fault;
	public static int record;
	public bool found = false;

	//rastro do mouse
	public TrailRenderer trail;

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("acertos", score);
		PlayerPrefs.SetInt ("erros", fault);
		generateRandomIndex (8);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("Inicio");
		}
		if(GameObject.Find((ShapeName (indexRandom, false) + "(Clone)")) != null){
			found = true;
		}else if(found == true && GameObject.Find((ShapeName (indexRandom, false) + "(Clone)")) == null){
			HitOrFail(false);
			found = false;
			generateRandomIndex (8);
		}
		Platform ();
	}

	// checa se sera jogado no pc ou no android
	private void Platform(){
		// checa se esta na plataforma android
		if (Application.platform == RuntimePlatform.Android){
			// evita cortar sem que tenha clicado na tela
			if(Input.touchCount == 0){
				gameObject.GetComponent<Collider2D> ().enabled = false;
				return;
			}else if (Input.touchCount == 1){
				// pega a posicao do toque na tela atraves de x, y e z
				position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, 
																		Input.GetTouch (0).position.y, 1));
				transform.position = new Vector2 (position.x, position.y);

				gameObject.GetComponent<Collider2D> ().enabled = true;
				return;
			}
		// checa se esta no pc
		} else {
			// pega a posicao do mouse atraves de x, y e z
			position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, 
																	Input.mousePosition.y, 0));
			
			transform.position = new Vector2 (position.x, position.y);
		}

	}
	// caso ative o gatilho de um collisor
	void OnTriggerEnter2D(Collider2D collisor){
		// checa se o collisor do objeto atual possui a tag "Formas"
		if (collisor.tag == "Formas") {
			collisor.GetComponent<Item> ().InstanciarDestruir ();
			Audio (clipForma);
		}
		// checa e o gameObject atual possui o mesmo nome que o objeto do objetivo
		if(collisor.transform.gameObject.name  == (ShapeName(indexRandom, false) + "(Clone)")){
			generateRandomIndex (8);
			HitOrFail(true);
			found = false;
		}else{
			HitOrFail(false);
		}
	}
	void Audio(AudioClip clip){
		//audio.clip = clip;
		AudioSource.PlayClipAtPoint (clip, transform.position, 0.2f);
	}
	// atualiza pontuacao
	void UpdateScore(){
		txtScore.text = score.ToString();
	}
	void OnTriggerEnter2D(){
		PlayerPrefs.SetInt ("acertos", score);
		if(score > PlayerPrefs.GetInt("recorde")){
			PlayerPrefs.SetInt ("recorde", score);
		}

	}
	public void generateRandomIndex(int tmpArrayLenght){
		int tmpIndexRandom = indexRandom;

		while(tmpIndexRandom == indexRandom){
			// gerar numero aletatorio
			tmpIndexRandom = (int)Random.Range (0, tmpArrayLenght);
		}
		indexRandom = tmpIndexRandom;

		// define o nome de uma forma aleatoria de indice "indexRandom" através da função ShapeName
		txtForma.text = ShapeName (indexRandom, true);

		// define a imagem de uma forma aleatoria de indice "indexRandom" através da função ShapeImage
		imgForma.sprite = Resources.Load<Sprite> (ShapeName(indexRandom, false)) as Sprite;

	}
	public void HitOrFail(bool tmpScore){
		if (tmpScore == true){
			score = int.Parse (txtScore.text);
			score += 1;
			txtScore.text = score.ToString();
		}else{
			fault = int.Parse (txtFault.text);
			fault += 1;
			txtFault.text = fault.ToString();
		}
	}
	public string ShapeName(int tmpIndex, bool tmpBreakLine){
		string tmpShapeName;
		if (tmpIndex == 0) {
			if (tmpBreakLine == true) {
				tmpShapeName = "Quadrado\nAzul";
			} else {
				tmpShapeName = "QuadradoAzul";
			}
			return tmpShapeName;
		} else if (tmpIndex == 1) {
			if (tmpBreakLine == true) {
				tmpShapeName = "Quadrado\nVermelho";
			} else {
				tmpShapeName = "QuadradoVermelho";
			}
			return tmpShapeName;
		} else if (tmpIndex == 2) {
			if(tmpBreakLine == true){
				tmpShapeName = "Triângulo\nAzul";
			}else{
				tmpShapeName = "TrianguloAzul";
			}
			return tmpShapeName;
		} else if (tmpIndex == 3) {
			if(tmpBreakLine == true){
				tmpShapeName = "Triângulo\nVermelho";
			}else{
				tmpShapeName = "TrianguloVermelho";
			}
			return tmpShapeName;
		}else if(tmpIndex == 4){
			if (tmpBreakLine == true){
				tmpShapeName = "Estrela\nAzul";
			}else{
				tmpShapeName = "EstrelaAzul";
			}
			return tmpShapeName;
		}else if(tmpIndex == 5){
			if (tmpBreakLine == true){
				tmpShapeName = "Estrela\nVermelha";
			}else{
				tmpShapeName = "EstrelaVermelha";
			}
			return tmpShapeName;
		}else if(tmpIndex == 6){
			if (tmpBreakLine == true){
				tmpShapeName = "Círculo\nAzul";
			}else{
				tmpShapeName = "CirculoAzul";
			}
			return tmpShapeName;
		}else if(tmpIndex == 7){
			if (tmpBreakLine == true){
				tmpShapeName = "Círculo\nVermelho";
			}else{
				tmpShapeName = "CirculoVermelho";
			}
			return tmpShapeName;
		}else{
			return "null";
		}
	}

}
