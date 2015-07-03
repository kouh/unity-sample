using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpPower = 3.0f;

	private bool jump;
	private Rigidbody2D rigidbody2D; 

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();

		jump = false;
	}
	
	void Update () {
		Move();
	}

	void FixedUpdate () {
		if(jump && rigidbody2D.velocity.y == 0){
			jump = false;
		}
	}

	void Move () {
		if(Controller.Right()){
			transform.Translate(new Vector2(+0.1f,0),Space.World);
		}else if(Controller.Left()){
			transform.Translate(new Vector2(-0.1f,0),Space.World);
		}

		Jump();
  	}

  	void Jump () {
  		if(!jump && Controller.Up()){
  			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpPower);
  			jump = true;
  		}
  	}
}
