using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationState : GameState 
{
  public float planetRad = 300.0f;
  public Vector2 planetPosition = new Vector2();
	// Use this for initialization
	public override void Start () 
  {
    base.Start();
    GameObject ship = GameObject.Find("Player");
    ShipClass shipComp = ship.GetComponent<ShipClass>();
    LaunchStage newStage = new LaunchStage();
    List<ShipPart> partList = newStage.parts;
    ShipPart part = (ShipPart)ship.GetComponent<CabinPart>();
    if(part) 
    {
      partList.Add(part);
    }
    GameObject engineObj = GameObject.Find("Engine");
    part = engineObj.GetComponent<ShipPart>();
    if(part) 
    {
      partList.Add(part);
    }
    GameObject fuelObj = GameObject.Find("FuelTank");
    part = fuelObj.GetComponent<ShipPart>();
    if(part) 
    {
      partList.Add(part);
    }
    shipComp.stages.Add(newStage);
    Debug.Log("sim");

    planetPosition.x = Random.Range(-10000.0f, 10000.0f);
    planetPosition.y = Random.Range(-10000.0f, 10000.0f);

    
	}
	
	// Update is called once per frame
	public override void Update () 
  {
    base.Update();
    if(Input.GetKeyDown(KeyCode.Space))
    {
      GameObject player = GameObject.Find("Player");
      player.GetComponent<ShipClass>().Launch();
      Debug.Log("launch");
    }

    GameObject spacePlayer = GameObject.Find("SpacePlayer");
    GameObject spaceCamObj = GameObject.Find("SpaceCamera");
    Camera spaceCam = spaceCamObj.GetComponent<Camera>();
    float scale = spaceCam.orthographicSize * 0.025f;
    spacePlayer.transform.localScale = new Vector3(scale, scale, 1.0f);

    Rigidbody2D playerBody = spacePlayer.GetComponent<Rigidbody2D>();
    GameStateManager gsm = GameObject.Find("World").GetComponent<GameStateManager>();
    List<GameObject> planets = gsm.planets;
    
    double gravConst = 6.67 * Mathf.Pow(10.0f, -11.0f);
    foreach(GameObject planet in planets)
    {
      Rigidbody2D body = planet.GetComponent<Rigidbody2D>();
      Vector2 gravDir = planet.transform.position - spacePlayer.transform.position;

      double gravForce = (double)body.mass * gravConst / (double)(body.transform.localScale.x * body.transform.localScale.x);
      playerBody.AddForce((float)gravForce * gravDir);
    }
	}

  public override void End()
  {
    base.End();
  }
}
