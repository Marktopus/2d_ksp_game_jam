using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationState : GameState 
{
  public float planetRad = 300.0f;
  public Sprite planetSprite = Resources.Load("circle-512", typeof(Sprite)) as Sprite;
  public List<GameObject> planets = new List<GameObject>();
  public Vector2 startPos = new Vector2();


  public Vector2 planetPosition = new Vector2();
	// Use this for initialization
	public override void Start () 
  {
    base.Start();


    GameObject planetPre = Resources.Load("PlanetPrefab") as GameObject;
    for(int i = 0; i < 1; ++i)
    {



      GameObject newObj = GameObject.Instantiate(planetPre);
      float radius = Random.Range(100.0f, 1000.0f);
      newObj.transform.localScale = new Vector3(radius * 2.0f, radius * 2.0f, 1.0f);
      newObj.transform.position = 
        new Vector3(
          Random.Range(-100000.0f, 100000.0f), 
          Random.Range(-100000.0f, 100000.0f), 
          -41.0f);

      float density = 200.0f;
      newObj.GetComponent<Rigidbody2D>().mass = density * Mathf.PI * radius * radius;
      planets.Add(newObj);
    }

    int startingPlanet = Random.Range(0, planets.Count - 1);
    Vector2 startDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    startDir.Normalize();
    startPos = (startDir * (planets[startingPlanet].transform.localScale.x + 4.0f)) + 
                (Vector2)planets[startingPlanet].transform.position;
    GameObject player = GameObject.Find("Player");
    player.transform.localPosition = new Vector3(startPos.x, startPos.y, player.transform.position.z);
    player.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(new Vector2(0.0f, 1.0f), startDir));

    GameObject farCam = GameObject.Find("Main Camera");
    farCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, farCam.transform.position.z);



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
    GameObject player = GameObject.Find("Player");
    if(Input.GetKeyDown(KeyCode.Space))
    {
      player.GetComponent<ShipClass>().Launch();
      Debug.Log("launch");
    }

    GameObject spacePlayer = GameObject.Find("SpacePlayer");
    GameObject spaceCamObj = GameObject.Find("SpaceCamera");
    Camera spaceCam = spaceCamObj.GetComponent<Camera>();
    float scale = spaceCam.orthographicSize * 0.025f;
    spacePlayer.transform.localScale = new Vector3(scale, scale, 1.0f);

    Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
    GameStateManager gsm = GameObject.Find("World").GetComponent<GameStateManager>();
    
    double gravConst = 6.67 * Mathf.Pow(10.0f, -4.0f);
    foreach(GameObject planet in planets)
    {
      Rigidbody2D body = planet.GetComponent<Rigidbody2D>();
      Vector2 gravDir = planet.transform.position - spacePlayer.transform.position;

      gravDir.Normalize();

      double gravForce = (double)body.mass * gravConst / (double)(gravDir.SqrMagnitude());
      Debug.Log(gravForce);
      playerBody.AddForce((float)gravForce * gravDir);
    }
	}

  public override void End()
  {
    base.End();
  }
}
