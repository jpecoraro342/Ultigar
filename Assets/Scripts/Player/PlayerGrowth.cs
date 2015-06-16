using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGrowth : MonoBehaviour {
	public MiniCellManager babyManager;
	private List<GameObject> enemyPlayers;

	public float smoothing = 20.0f;

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

		StartCoroutine(LerpGrowth(smoothing * Time.deltaTime, gameObject.transform.localScale, scale));
	}

	IEnumerator LerpGrowth(float time, Vector3 original, Vector3 newScale) {
		var reducedTime = time;
		while (reducedTime > 0.0f) {
			reducedTime -= Time.deltaTime;
			transform.localScale = Vector3.Lerp(newScale, original, reducedTime/time);

			yield return null;
		}
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
