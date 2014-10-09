using UnityEngine;
using System.Collections;

public class PictogramElapsedTime : MonoBehaviour {

	private static bool _theClockIsStared = false; 
	private static float _startedTimeValue = 0;

	private int _timeForPictogramGuessing = 0;
	private float _currentTime = 0;

	void Start() {
		switch(Game.GetGameSpeed) {
			case 1: _timeForPictogramGuessing = 5; break;
			case 2: _timeForPictogramGuessing = 4; break;
			case 3: _timeForPictogramGuessing = 3; break;
			case 4: _timeForPictogramGuessing = 2; break;
			case 5: _timeForPictogramGuessing = 1; break;
		}
	}

	void Update() {
		if(_theClockIsStared && Game.GameIsStarted) {
			_currentTime = Time.time - _startedTimeValue;
			GetComponent<GUIText>().text = "Time: " + _currentTime.ToString("#.##") + " s";

			if(_currentTime > _timeForPictogramGuessing) {
				Game.PlayerMissedPictogram();
				DrawnPictogram.ResetRandomPictogram();
			}
		}
	}

	public static void StartTheClock() {
		_startedTimeValue = Time.time;
		_theClockIsStared = true;
	}
}
