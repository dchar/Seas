using UnityEngine;
using System.Collections;

public class enemyBehavior : MonoBehaviour {
	public GameObject remainsPrefab;

	private int hp;

	public int getHP() {
		return hp;
	}

	public void changeHP(int x) {
		hp += x;
	}

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
	void Start () {
		hp = 100;
	}

	void Update () {
		if (hp <= 0) {
			Vector3 vec = new Vector3(12.7f, 0.25f, 0);
			GameObject clone = (GameObject)Instantiate (remainsPrefab, vec, transform.rotation);
			Destroy (gameObject);
		}
	}




}
