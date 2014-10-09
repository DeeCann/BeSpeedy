using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	/**
	 * GAME SETTINGS
	 **/
	private static int _playerNumber = 0;
	private static int _gameSpeed = 0;
	private static int _gameTime = 0;

	public GameObject GuessedText;
	public GameObject MissedText;
	public GameObject CurrentTimeValueText;
	public GameObject TotalTimeValueText;

	public GameObject EndScreen;

	private static List<int> selectedPictograms = new List<int> {};

	private static bool _gameIsStarted = false;
	private  bool _gameHasEnded = false;

	private static int _currentPictogram = 0;
	private static int _correctPictograms = 0;
	private static int _missedPictograms = 0;

	private float _startedTimeValue = 0;

	void Start() {
		_playerNumber = PlayerPrefs.GetInt("PlayerNumber");
		_gameSpeed = PlayerPrefs.GetInt("SelectedLevel");
		_gameTime = PlayerPrefs.GetInt("TimeLevel");

		if(_gameTime > 0)
			TotalTimeValueText.guiText.text = " / "+ _gameTime + " s";
		else
			TotalTimeValueText.guiText.text = "/ infinity ";
	}

	void Update () {
		if(_gameHasEnded) {
			if(Input.GetMouseButtonDown(0)) {
				if(EndScreen.transform.FindChild("Back").guiTexture.HitTest(Input.mousePosition)) 
					Application.LoadLevel(0);
			}
		}

		if(GameIsStarted && (Time.time - _startedTimeValue) > _gameTime) {
			EndScreen.gameObject.SetActive( true );
			GameIsStarted = false;
			_gameHasEnded = true;
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			GameIsStarted = true;
			_startedTimeValue = Time.time;
		}

		GuessedText.guiText.text = _correctPictograms.ToString();
		MissedText.guiText.text = _missedPictograms.ToString();

		if(GameIsStarted)
			CurrentTimeValueText.guiText.text = (Time.time - _startedTimeValue).ToString("#.##");
	}

	public static bool GameIsStarted {
		get {
			return _gameIsStarted;
		}

		set {
			_gameIsStarted = value;
		}
	}

	public static int CurrentPictogram {
		set {
			_currentPictogram = value;
		}
		
		get {
			return _currentPictogram;
		}
	}

	public static int GetGameSpeed {
		get{
			return _gameSpeed;
		}
	}

	public static void AddSelctedPictogram(int pictogramValue) {
		selectedPictograms.Add(pictogramValue);
	}

	public static int GetRandomPictogram(int randomValue) {
		return selectedPictograms[randomValue];
	}

	public static void PlayerGuessedPictogram() {
		_correctPictograms++;
	}

	public static void PlayerMissedPictogram() {
		_missedPictograms++;
	}


}
