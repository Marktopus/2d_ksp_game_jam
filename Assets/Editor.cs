// TODO non-hardcoded parts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor {
	GameObject ShipContainer;
	GameObject Ship;
	Dictionary<string, GameObject> PrefabDict;

	GameObject ActivePart;

	public Editor (GameObject shipContainer, GameObject player) {
		ShipContainer = shipContainer;
		Ship = player;
		Ship.transform.position = new Vector3(0, 20, 0);
		ActivePart = Ship;

		LaunchStage stage = new LaunchStage();
		stage.parts.Add(Ship.GetComponent<ShipPart>());
		ShipClass shipClass = Ship.GetComponent<ShipClass>();
		shipClass.stages.Add(stage);
		// ActivePart = player;
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

// TODO make this more generalized and less gross
	public void AddPart (string name) {
		GameObject part = null;
		if (name == "CapsuleA") {
			Debug.Log("multiple cabins not yet supported");
			return;
		}

		part = GameObject.Instantiate(PrefabDict[name]);
		part.transform.position = ActivePart.transform.position + new Vector3(0, -1, 0);
		SpriteRenderer rendrr = part.GetComponent<SpriteRenderer>();
		SpriteRenderer lastRendrr = ActivePart.GetComponent<SpriteRenderer>();
		rendrr.sortingOrder = lastRendrr.sortingOrder - 1;

		LaunchStage stage = Ship.GetComponent<ShipClass>().stages[0];
		// TODO make this not gross
		ShipPart partObj = part.GetComponent<FuelPart>();
		if (partObj) {
			Debug.Log("adding fuel part");
			stage.parts.Add(partObj);
		} else {
			partObj = part.GetComponent<EnginePart>();
			if (partObj) {
				Debug.Log("adding engine part");
				foreach (ShipPart stagePart in stage.parts) {
					if (stagePart is FuelPart) {
						((EnginePart)partObj).fuelParts.Add((FuelPart)stagePart);
					}
				}
				stage.parts.Add(partObj);
			} else {
				Debug.Log("not known part bad");
			}
		}
		ActivePart = part;
		part.transform.parent = Ship.transform;
	}
}
