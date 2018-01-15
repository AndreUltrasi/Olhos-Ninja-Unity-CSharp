using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinta : MonoBehaviour {
	public float speed;
	private float alpha;
	private float red;
	private float green;
	private float blue;
	SpriteRenderer _renderer;
	// Use this for initialization
	void Start () {
		_renderer = this.GetComponent<SpriteRenderer> ();
		_renderer.color = new Color (red, green, blue, alpha);
	}
	
	// Update is called once per frame
	void Update () {
		_renderer.color = new Color (red, green, blue, alpha -= speed*Time.deltaTime);
		if(alpha<=0){
			Destroy (gameObject);
		}
	}
	public void setColor(float _red, float _green, float _blue, float _alpha){
		red = _red;
		green = _green;
		blue = _blue;
		alpha = _alpha;
	}
}
