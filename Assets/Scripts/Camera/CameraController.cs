using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 baseOffset;

	private float baseSize;

	private Camera camera;

	void Start () {
		camera = gameObject.GetComponent<Camera>();
		baseOffset = transform.position;
		baseSize = camera.orthographicSize;
	}

	void LateUpdate () {
		transform.position = player.transform.position + baseOffset;

		var playerScale = player.transform.localScale.magnitude; 
		camera.orthographicSize = baseSize + playerScale * .2f; 
	}
}
