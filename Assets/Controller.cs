using UnityEngine;
using System.Collections;

public class Controller{
  public static bool Up(){
		return Input.GetKey("up");
  }
  public static bool Right(){
		return Input.GetKey("right");
  }
  public static bool Down(){
		return Input.GetKey("down");
  }
  public static bool Left(){
		return Input.GetKey("left");
  }
}
