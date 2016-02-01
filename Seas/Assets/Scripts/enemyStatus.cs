using UnityEngine;
using System.Collections;

public class enemyStatus : MonoBehaviour {

	public enemyBehavior enemyScript;
	private int hpToShow;
	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = GetComponent <TextMesh> ();
		hpToShow = enemyScript.getHP ();
		text.text = "HP: " + hpToShow;
	}

	// Update is called once per frame
	void Update () {
		hpToShow = enemyScript.getHP ();
		text.text = "HP: " + hpToShow;
	}
}
