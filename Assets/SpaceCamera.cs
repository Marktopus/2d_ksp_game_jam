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
    mytr.position = new Vector3(targetTr.position.x, targetTr.position.y, mytr.position.z);
	}
}
