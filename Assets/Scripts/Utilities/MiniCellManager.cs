using UnityEngine;
using System.Collections;

public class MiniCellManager : MonoBehaviour {

	public int maxNumberOfCells = 1000;
	public GameObject cellParent;
	public GameObject miniCellPrefab;
	
	void Start () {
		InitializeMiniCells();
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
	}
}
