using UnityEngine;
using System.Collections;

public class DrawnPictogram : MonoBehaviour {

	private static bool _randomPictogramSelected = false;
	private int _lastRandomPictogramValue = 0;

	void Update () {
		if(Game.GameIsStarted && !_randomPictogramSelected) {
			GetRandomPictogram();
			_randomPictogramSelected = true;
		}
	}

	private void GetRandomPictogram() {
		int currentRandomPictogramValue = 0;
		do {
			currentRandomPictogramValue = Random.Range(0,6);
		} while (_lastRandomPictogramValue == currentRandomPictogramValue);

		int curentPictogramValue = Game.GetRandomPictogram(currentRandomPictogramValue);
		Game.CurrentPictogram = curentPictogramValue;

		GetComponent<GUITexture>().texture = Resources.Load("PictogramTextures/" + curentPictogramValue) as Texture;
		GetComponent<GUITexture>().enabled = true;

		PictogramElapsedTime.StartTheClock();

		_lastRandomPictogramValue = currentRandomPictogramValue;
	}

	public static void ResetRandomPictogram() {
		_randomPictogramSelected = false;
	}
}
