using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamLogic : MonoBehaviour 
{
  public GameObject target;
	// Use this for initialization
	void Start () 
  {
    		
	}
	
	// Update is called once per frame
	void Update () 
  {
    Transform mytr = GetComponent<Transform>();
    Transform targetTr = target.GetComponent<Transform>();
    mytr.position = new Vector3(targetTr.position.x, targetTr.position.y, mytr.position.z);

	}
}
