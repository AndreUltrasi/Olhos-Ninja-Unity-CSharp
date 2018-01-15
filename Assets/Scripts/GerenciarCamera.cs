using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarCamera : MonoBehaviour {
	public Camera mainCamera;
	private static float camMinX;
	public static float camMaxX;
	private static float camMinY;
	private static float camMaxY;
	private static float distanciaZ;
	// Use this for initialization
	void Start () {
		// atribui a distanciaZ o valor atual do eixo z de mainCamera
		distanciaZ = mainCamera.transform.position.z - mainCamera.transform.position.z;

		// atribui as variaveis minX e maxX as 
		// dimensões minimas(0) e máximas(largura da tela/2) respectivamente do eixo x 
		// da mainCamera
		camMinX = mainCamera.ScreenToWorldPoint (new Vector3 (0, 0, distanciaZ)).x;
		camMaxX = mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, distanciaZ)).x;

		// atribui as variaveis minY e maxY as 
		// dimensões minimas(0) e máximas(altura da tela/2) respectivamente, do eixo y 
		// da mainCamera
		camMinY = mainCamera.ScreenToWorldPoint (new Vector3 (0, 0, distanciaZ)).y;
		camMaxY = mainCamera.ScreenToWorldPoint (new Vector3 (0, Screen.height, distanciaZ)).y;
	}
	public static float MinX(){
		return camMinX;
	}
	public static float MaxX(){
		return camMaxX;
	}
	public static float MinY(){
		return camMinY;
	}
	public static float MaxY(){
		return camMaxY;
	}
}
