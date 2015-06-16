using UnityEngine;
using System.Collections;

public class MiniCellColor : MonoBehaviour {

	private Color color;
	
	void Start () {
		color = new Color(Random.value, Random.value, Random.value);
		gameObject.GetComponent<Renderer>().material.color = color;
	}

	void Update () {
	
	}
}
