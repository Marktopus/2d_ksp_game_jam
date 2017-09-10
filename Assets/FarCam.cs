using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarCam : MonoBehaviour 
{
  public GameObject target;

	void Start () 
  {
    		
	}
	
	void Update () 
  {
    Transform mytr = GetComponent<Transform>();
    Transform targetTr = target.GetComponent<Transform>();
    if(targetTr.position.y > 10000.0f)
    {
      // switch to a view of the solar system
    }
	}
}
