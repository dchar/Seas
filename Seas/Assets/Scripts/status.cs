using UnityEngine;
using System.Collections;

public class status : MonoBehaviour {
	public ShipBehavior playerScript;
	private int hpToShow;
	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = GetComponent <TextMesh> ();
		hpToShow = playerScript.getHP ();

		text.text = "HP: " + hpToShow;
	}
	
	// Update is called once per frame
	void Update () {
		hpToShow = playerScript.getHP ();
		text.text = "HP: " + hpToShow;
	}
}
