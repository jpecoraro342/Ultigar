using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	//TODO: Adjust z for sphere radius

	void Start () {
		offset = transform.position;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
