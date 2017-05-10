// Controls cursor

using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {
	
	// move the object to where the mouse is onscreen
	void Update () 
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
		transform.position = new Vector3( pos_move.x, transform.position.y, pos_move.z );
	}
}


