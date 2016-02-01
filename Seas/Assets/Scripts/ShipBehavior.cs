using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {
	public float angle;
	public float gravity;
	public int damage;

	public GameObject cannonPrefab;
	public enemyBehavior enemyScript;
	public Oscillator enemyOsc;
	public Transform target;

	private Transform shipTransform;
	private int hp;
	private int enemyHP;
	private GameObject enemy;

	public int getHP() {
		return hp;
	}

	IEnumerator fire() {
		Vector3 pos = transform.position;
		float temp = pos.y + 0.5f;
		pos.y = temp;

		GameObject projectileObject = (GameObject) Instantiate (cannonPrefab, pos, transform.rotation);
		Transform projectileTransform = projectileObject.transform;
		projectileTransform.position = shipTransform.position + new Vector3 (0, 2.0f, 0);

		// Calculate distance to target
		float targetDist = Vector3.Distance (projectileTransform.position,
			                   target.position);

		// Calculate velocity needed to throw object to the target
		float projectileVelo = targetDist / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);

		// Extract the X & Y components of the velocity
		float Vx = Mathf.Sqrt(projectileVelo) * Mathf.Cos(angle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectileVelo) * Mathf.Sin(angle * Mathf.Deg2Rad);

		// Calculate flight timme
		float flightDuration = targetDist / Vx;

		// Rotate projectile to face the target
		projectileTransform.rotation = Quaternion.LookRotation (target.position -
						projectileTransform.position);
		float elapse = 0;
		bool dmgFlag = false;
		while (elapse < flightDuration) {
			if (projectileObject.gameObject != null) {
				projectileTransform.Translate (0, (Vy - (gravity * elapse)) * Time.deltaTime, Vx * Time.deltaTime);
			} 
			else {
				if (!dmgFlag) {
					enemyScript.changeHP (-damage);
					dmgFlag = true;
				}
			}

			elapse += Time.deltaTime;
			yield return null;

		}

		if (projectileObject.gameObject !=null)
			Destroy(projectileObject.gameObject);


	}


	void Start () {
		angle = 45.0f;
		gravity = 9.8f;

		enemy = GameObject.FindWithTag ("Enemy");
		enemyOsc = enemy.GetComponent <Oscillator> ();
		shipTransform = transform;
		hp = 100;
		enemyHP = enemyScript.getHP ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (enemy.gameObject != null) {
				StartCoroutine (fire ());
			}
		}
			
	}
}
