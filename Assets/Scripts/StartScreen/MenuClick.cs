using UnityEngine;
using System.Collections;

public class MenuClick : MonoBehaviour {

	private Vector3 _firstScreenCameraPosition = new Vector3(0,0,-4);
	private Vector3 _seconScreenCameraPosition = new Vector3(10,0,-4);

	private GameObject _lastSpeedLevelButtonClicked;
	private GameObject _lastTimeLevelButtonClicked;

	void Start() {
		transform.position = _firstScreenCameraPosition;
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 10)) {
				if(hit.collider.transform.parent.name == "FirstScreen") {
					switch(hit.collider.name) {
						case "1PlayerButton": PlayerPrefs.SetInt("PlayerNumber", 1); break;
						case "2PlayersButton": PlayerPrefs.SetInt("PlayerNumber", 2); break;
					}
					StartCoroutine("MoveCamera", 1);
				}

				if(hit.collider.transform.parent.name == "SecondScreen") {
					switch(hit.collider.name) {
						case "Back": StartCoroutine("MoveCamera", -1); break;
						case "Play": Application.LoadLevel(1); break;
					}
				}

				if(hit.collider.transform.parent.name == "SpeedLevel") {
					switch(hit.collider.name) {
						case "DiaperButton": SpeedLevelButtonClickActions(hit.collider.gameObject, 1); break;
						case "SchoolBusDriverButton": SpeedLevelButtonClickActions(hit.collider.gameObject, 2); break;
						case "WrestlerButton": SpeedLevelButtonClickActions(hit.collider.gameObject, 3); break;
						case "JediMasterButton": SpeedLevelButtonClickActions(hit.collider.gameObject, 4); break;
						case "DevilCrusherButton": SpeedLevelButtonClickActions(hit.collider.gameObject, 5); break;
					}
				}

				if(hit.collider.transform.parent.name == "TimeLevel") {
					switch(hit.collider.name) {
						case "30seconds": TimeLevelButtonClickActions(hit.collider.gameObject, 30); break;
						case "60seconds": TimeLevelButtonClickActions(hit.collider.gameObject, 60); break;
						case "90seconds": TimeLevelButtonClickActions(hit.collider.gameObject, 90); break;
						case "Eternity": TimeLevelButtonClickActions(hit.collider.gameObject, 0); break;
					}
				}
			}
		}
	}

	private void SpeedLevelButtonClickActions(GameObject clickedButton, int level) {
		if(_lastSpeedLevelButtonClicked != null)
			_lastSpeedLevelButtonClicked.animation.Play("ButtonUnselected");

		clickedButton.animation.Play("ButtonSelected");
		PlayerPrefs.SetInt("SelectedLevel", level);

		_lastSpeedLevelButtonClicked = clickedButton;
	}

	private void TimeLevelButtonClickActions(GameObject clickedButton, int time) {
		if(_lastTimeLevelButtonClicked != null)
			_lastTimeLevelButtonClicked.animation.Play("ButtonUnselected");
		
		clickedButton.animation.Play("ButtonSelected");
		PlayerPrefs.SetInt("TimeLevel", time);
		
		_lastTimeLevelButtonClicked = clickedButton;
	}

	private IEnumerator MoveCamera(int direction) {
		if(direction > 0) {
			while(Vector3.Distance(transform.position, _seconScreenCameraPosition) > 0.1f) {
				transform.position = Vector3.Lerp(transform.position, _seconScreenCameraPosition, Time.deltaTime * 20);
				yield return 0;
			}
		}

		if(direction < 0) {
			while(Vector3.Distance(transform.position, _firstScreenCameraPosition) > 0.1f) {
				transform.position = Vector3.Lerp(transform.position, _firstScreenCameraPosition, Time.deltaTime * 20);
				yield return 0;
			}
		}

		yield return null;
	}
}
