using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawPictograms : MonoBehaviour {
	
	private List<int> _cards = new List<int> {};

	void Start () {
		GeneratePictograms();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			RemoveOldCard();
			GeneratePictograms();
		}
	}

	private void GeneratePictograms() {
		for(int j = 1;j <= 16; j++) 
			_cards.Add(j);

		for(int i = 0;i <= 5; i++) {
			int randomPictogram = Random.Range(0, _cards.Count - 1);
			
			GameObject _card = (GameObject)Instantiate(Resources.Load("PictogramPrefab"), Vector3.zero, Quaternion.identity);
			
			switch(i) {
			case 0:_card.transform.parent = transform.FindChild("UpSocket"); break;
			case 1:_card.transform.parent = transform.FindChild("DownSocket");break;
			case 2:_card.transform.parent = transform.FindChild("LeftSocket");break;
			case 3:_card.transform.parent = transform.FindChild("RightSocket");break;
			case 4:_card.transform.parent = transform.FindChild("FrontSocket");break;
			case 5:_card.transform.parent = transform.FindChild("BackSocket");break;
			}
			
			_card.transform.localPosition = Vector3.zero;
			_card.transform.localRotation = Quaternion.identity;
			
			Material _cardMaterial = Resources.Load("PictogramsMaterials/" + _cards[randomPictogram], typeof(Material)) as Material;
			_card.renderer.material = _cardMaterial;

			_card.renderer.material.name = _card.renderer.material.name.Replace(" (Instance)","");

			Game.AddSelctedPictogram(_cards[randomPictogram]);

			_cards.RemoveAt(randomPictogram);
		}
	}

	private void RemoveOldCard() {
		Destroy(transform.FindChild("UpSocket").GetChild(0).gameObject);
		Destroy(transform.FindChild("DownSocket").GetChild(0).gameObject);
		Destroy(transform.FindChild("LeftSocket").GetChild(0).gameObject);
		Destroy(transform.FindChild("RightSocket").GetChild(0).gameObject);
		Destroy(transform.FindChild("FrontSocket").GetChild(0).gameObject);
		Destroy(transform.FindChild("BackSocket").GetChild(0).gameObject);
 		
		_cards.Clear();
	}
}
