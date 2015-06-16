using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Text debugText;

	public float baseSpeed = 5.0f;
	public float radius = .5f;

	private float currentSpeed;

	private Vector3 clickPoint;
	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.LookRotation(transform.position - transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		CalculateDirection();
		CalculateSpeed();

		Move();
		UpdateDebugText();
	}

	void CalculateDirection() {

		RaycastHit hit;
		Vector3 targetPoint;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f)) {
			targetPoint = hit.point;
			clickPoint = targetPoint;
		}
		else {
			//Don't change the target direction
			return;
		}

		Vector3 targetDirection = (targetPoint - transform.position);
		targetDirection.Normalize();

		targetDirection.z = 0.0f;

		moveDirection = targetDirection;
		
		//Choose New Rotation
		Quaternion rotation = Quaternion.LookRotation(targetDirection);

		transform.rotation = rotation;
	}

	void CalculateSpeed() {
		currentSpeed = 1.0f/radius * baseSpeed;
	}

	void Move() {
		if (transform.forward.z > 0.01f) {
			return;
		}
		Vector3 movePosition = transform.position + (transform.forward * currentSpeed * Time.deltaTime);
		movePosition.z = .5f;
		transform.position = movePosition;
	}

	void UpdateDebugText() {
		debugText.text = "Click Point: " + clickPoint + "\nTarget Direction: " + moveDirection + "\nCurrent Rotation: " + transform.rotation + "\nRotation: " + transform.rotation + "\nPosition: " + transform.position + "\nForward Direction: " + transform.forward;
	}
	
}
