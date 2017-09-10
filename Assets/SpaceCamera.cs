using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCamera : MonoBehaviour 
{
  public Sprite planetSprite;
  public GameObject target;
	void Start () 
  {
		
	}
	
	void Update () 
  {
    Transform mytr = GetComponent<Transform>();
    Transform targetTr = target.GetComponent<Transform>();
    Transform toMoveTr = GameObject.Find("SpacePlayer").transform;
    Debug.Log(toMoveTr.position);
    toMoveTr.position = new Vector3(targetTr.position.x, targetTr.position.y, toMoveTr.position.z);
    mytr.position = new Vector3(targetTr.position.x, targetTr.position.y, mytr.position.z);
	}
}
