using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		Move();
	}

	void Move(){
		if(Input.GetKey("right")){
			transform.Translate(new Vector2(+0.1f,0),Space.World);
		}else if(Input.GetKey("left")){
			transform.Translate(new Vector2(-0.1f,0),Space.World);
		}
	}
}
