using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGrowth : MonoBehaviour {
	public MiniCellManager babyManager;
	private List<GameObject> enemyPlayers;

	void Start () {
		enemyPlayers = new List<GameObject>();
	}

	void Update () {
	
	}

	public void Grow(float growthAmount) {
		Vector3 scale = gameObject.transform.localScale;
		scale.x += growthAmount;
		scale.y += growthAmount;
		scale.z += growthAmount;

		gameObject.transform.localScale = scale;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Add to the list, do some calculations
		}
		else {
			EatBaby(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			//Remove from the list
		}
		else {

		}
	}

	void EatBaby(GameObject babyCell) {
		Grow(babyCell.transform.localScale.x / 2.0f);
		babyManager.EatCell(babyCell);
	}
}
