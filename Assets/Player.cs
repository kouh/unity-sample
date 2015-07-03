using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		Move();
	}

	void Move(){
		if(Controller.Right()){
			transform.Translate(new Vector2(+0.1f,0),Space.World);
		}else if(Controller.Left()){
			transform.Translate(new Vector2(-0.1f,0),Space.World);
		}
  }
}
