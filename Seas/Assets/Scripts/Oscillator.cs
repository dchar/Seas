using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour {
	public float speed;
	public float width;
	public float height;

	private float timeCounter;
	private Rigidbody rb;

	public Vector3 locationAfterDelta (float delta) {
		float temp = timeCounter + (delta*speed);

		float x = Mathf.Cos (temp) * width;
		float y = rb.position.y;
		float z = Mathf.Sin (temp) * height;

		Vector3 retResult = new Vector3 (x, y, z);
		return retResult;
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		timeCounter = 0;
	}

	void Update () {
		// Track time as it passes
		timeCounter += Time.deltaTime*speed;

		float x = Mathf.Cos (timeCounter)*width;
		float y = rb.position.y;
		float z = Mathf.Sin (timeCounter)*height;

		rb.transform.position = new Vector3 (x, y, z);
		transform.LookAt(locationAfterDelta(1.0f));
	}
}
