using UnityEngine;
using System.Collections;

public class RayFromSide : MonoBehaviour {
	
	private bool _startRay = false;

	void Update () {
		if(Input.GetMouseButtonDown(0)) 
			_startRay = true;

		if(Input.GetMouseButtonUp(0))
			_startRay = false;

		if(_startRay) {
			Debug.DrawLine(transform.position * 2, transform.forward * -4);
			RaycastHit hit;
			if(Physics.Raycast(transform.position * 2, transform.forward * -4, out hit)) {
				if (hit.collider.name == "UpRayControler") {
					if(Game.CurrentPictogram == System.Convert.ToInt16( transform.GetComponentInChildren<Renderer>().material.name )) {
						Game.PlayerGuessedPictogram();
						PictogramElapsedTime.StartTheClock();
						DrawnPictogram.ResetRandomPictogram();
					}
				}
			}

		}
	}
}