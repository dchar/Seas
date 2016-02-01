using UnityEngine;
using System.Collections;

public class CameraGrip : MonoBehaviour {

	public GameObject player;
	public Transform lookAt;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		transform.LookAt (lookAt.transform);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	void FixedUpdate() {
		transform.LookAt (lookAt.transform);
	}
}
