using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	private Vector3 _mouseStartPosition;

	void Start() {
		_mouseStartPosition = Input.mousePosition;
	}
	
	void FixedUpdate() {
		float x = ((_mouseStartPosition.x - Input.mousePosition.x ) * 0.3f);
		float y = ((_mouseStartPosition.y - Input.mousePosition.y ) * -0.3f);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(y, x, 0), Time.deltaTime * 10);	                    
	}
}
