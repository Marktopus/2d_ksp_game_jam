// TODO non-hardcoded parts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor {
	GameObject ShipContainer;
	Dictionary<string, GameObject> PrefabDict;

	GameObject ActivePart;

	public Editor (GameObject shipContainer) {
		ShipContainer = shipContainer;
		BuildPrefabDict();
		AddListeners();
	}

	// TODO load from file
	public void BuildPrefabDict () {
		PrefabDict = new Dictionary<string, GameObject>();
		PrefabDict.Add("CapsuleA", Resources.Load("CapsuleAPrefab") as GameObject);
		PrefabDict.Add("FuelTankA", Resources.Load("FuelTankAPrefab") as GameObject);
		PrefabDict.Add("EngineA", Resources.Load("EngineAPrefab") as GameObject);
	}

	public void AddListeners () {
		(GameObject.Find("CapsuleAButton") as GameObject).GetComponent<Button>().onClick.AddListener(() => { AddPart("CapsuleA"); });
		(GameObject.Find("FuelTankAButton") as GameObject).GetComponent<Button>().onClick.AddListener(() => { AddPart("FuelTankA"); });
		(GameObject.Find("EngineAButton") as GameObject).GetComponent<Button>().onClick.AddListener(() => { AddPart("EngineA"); });
	}

	public void AddPart (string name) {
		GameObject prefab = PrefabDict[name];
		GameObject part = GameObject.Instantiate(prefab);
		if (ActivePart == null) {
			part.transform.position = new Vector3(0, 20, 0);
		} else {
			part.transform.position = ActivePart.transform.position + new Vector3(0, -1, 0);
		}
		ActivePart = part;
		part.transform.parent = ShipContainer.transform;
	}
}
