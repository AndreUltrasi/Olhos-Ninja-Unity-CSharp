using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciarObjetos : MonoBehaviour {
	//tempo minimo para um objeto ser gerado
	public float minSpawnTime;

	//tempo maximo para um objeto ser gerado
	public float maxSpawnTime;

	//tempo para o objeto ser gerado
	public float spawnItem;

	// vetor com todos os Prefabs(letras)
	public GameObject[] Itens;

	//pega um filho(letra) do vetor itens[pegará de forma randomica];
	private GameObject item;

	// variaveis usadas para lancar objeto em parabola
	public float upForce = 700f; 
	public float leftForce = 150f;

	//posicao do instanciador
	public float minX; 
	public float maxX; 

	// indice da posicao de um objeto no vetor Itens
	private int index,index0;

	// indice da posicao do objeto gerao anteriormente
	private int previousIndex;
	private int previousObj;

	private int probability;

	public int x = 150, y = 50, width = 800, height = 800;

	public float positionX;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Instanciador");
	}
	// define quando e onde o objeto sera instanciado
	private IEnumerator Instanciador(){
		minX = GerenciarCamera.MinX();
		maxX = GerenciarCamera.MaxX();


		// define um tempo em segundos para instanciar o proximo objeto baseado em um numero
		// aleatorio entre o minSpawnTime e o maxSpawnTime
		spawnItem = Random.Range (minSpawnTime, maxSpawnTime);

		index = Random.Range (0, 8);
		probability = Random.Range (0, 6);

		if(probability <= 2){
			index = Player.indexRandom;
		}

		while(previousIndex == index){
			index = Random.Range (0, 8);
		}


		// espera ate spawnItem segundos para executar a proxima linha de codigo
		yield return new WaitForSeconds(spawnItem);

		positionX = Random.Range (minX, maxX);

		item = Instantiate(Itens[index], new Vector2(Random.Range(minX, maxX)
			, transform.position.y), Quaternion.Euler(0, 0, Random.Range(-30, 30))) as GameObject;
		
		previousIndex = index;


		// se o instanciador estiver a esquerda lance no sentido da direita 
		// se o instanciador estiver a direita lance para a esquerda
		if(item.transform.position.x > 0){
			//item.rigidbody2d.AddForce() obsoleto
			item.GetComponent<Rigidbody2D>().AddForce (new Vector2 (-leftForce, upForce));
		}else{
			//item.rigidbody2d.AddForce() obsoleto
			item.GetComponent<Rigidbody2D>().AddForce (new Vector2 (leftForce, upForce));
		}
		StartCoroutine ("Instanciador");
	}
}