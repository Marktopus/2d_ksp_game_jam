using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor {
	GameObject Player;

	// Use this for initialization
	public Editor () {
		Player = GameObject.Find("Player");
	}
	
	public void Start () {
		Player.transform.position += new Vector3(0, 10, 0);
	}

	public void End () {

	}
}
