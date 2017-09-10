// TODO non-hardcoded parts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor {
	GameObject ShipContainer;
	Dictionary<string, GameObject> PrefabDict;

	public Editor (GameObject shipContainer) {
		ShipContainer = shipContainer;
		BuildPrefabDict();
		AddListeners();
	}

	// TODO load from file
	public void BuildPrefabDict () {
		PrefabDict = new Dictionary<string, GameObject>();
		PrefabDict.Add("CapsuleA", Resources.Load("CapsuleAPrefab") as GameObject);
	}

	public void AddListeners () {
		(GameObject.Find("CapsuleAButton") as GameObject).GetComponent<Button>().onClick.AddListener(()=>{AddPrefab("CapsuleA");});
	}

	public void AddPrefab (string name) {
		GameObject prefab = PrefabDict[name];
		GameObject part = GameObject.Instantiate(prefab);
		part.transform.parent = ShipContainer.transform;
	}
}
