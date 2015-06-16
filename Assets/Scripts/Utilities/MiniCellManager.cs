using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniCellManager : MonoBehaviour {
	public Text debugText;

	public int maxNumberOfCells = 600;
	public int minNumberOfCells = 300;
	public GameObject cellParent;
	public GameObject miniCellPrefab;

	private List<GameObject> cells;

	private float timeSinceCellSpawn;
	private float spawnThrottle;
	private float spawnTime;
	
	void Start () {
		spawnTime = 3f;
		timeSinceCellSpawn = 0f;
		spawnThrottle = 1f;

		cells = new List<GameObject>();
		InitializeMiniCells();
	}

	void Update() {
		timeSinceCellSpawn += Time.deltaTime;
		if (timeSinceCellSpawn >= spawnTime) {
			CreateCell();
			UpdateThrottle();
			spawnTime = Random.value / spawnThrottle;
			timeSinceCellSpawn = 0f;
		}

		debugText.text = "Spawn Rate: " + spawnThrottle;
	}

	void InitializeMiniCells() {
		for (int i = 0; i < maxNumberOfCells; i++) {
			CreateCell();
		}
	}

	void CreateCell() {
		Vector3 position = new Vector3(Random.Range(-50.0F, 50.0F), Random.Range(-50.0F, 50.0F), 0);
		GameObject miniCell = (GameObject)Instantiate(miniCellPrefab, position, Quaternion.identity);
		miniCell.transform.parent = cellParent.transform;
		cells.Add(miniCell);
	}

	void UpdateThrottle() {
		var currentCount = cells.Count;
		var middle = (maxNumberOfCells + minNumberOfCells) / 2.0f;
		spawnThrottle = middle / currentCount;
	}

	public void EatCell(GameObject cell) {
		cells.Remove(cell);
		GameObject.Destroy(cell);
		UpdateThrottle();
	}
}
