using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public GameObject wall;
    public float timeOffset = 1000f;
    public float distanceBetweenTiles = 50.0f;
    public float distanceforhollow = 50.0f;
    public float randomValus = 0.8f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otehrDirect = new Vector3(1, 0, 0),otherDirect_sec = new Vector3(-1,0,0);
    private int decide = 0;
    private int judge = 0;
    private int have_wall = 0;
    private int turn = 0;
    public float decidehollow = 0.23f;

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > timeOffset)
        {
            Vector3 spawnPos;
            float num_temp = Random.value;
            if (num_temp < decidehollow && judge >= 0 && have_wall <=0)
            {
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceforhollow * direction;
                startTime = Time.time;
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                previousTilePosition = spawnPos; 
                decide = 0;
                have_wall = 0;
                
            }
            else if(num_temp < 0.6 && num_temp >= decidehollow && have_wall <= 0 && turn == 0)
            {
                
                float num_obstacle = Random.value;
                if(num_obstacle < 0.5)
                {
                    turn = 1;
                    judge++;
                    Vector3 temp = direction;
                    direction = otehrDirect;
                    mainDirection = direction;
                    otehrDirect = temp;
                    spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                    startTime = Time.time;
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    previousTilePosition = spawnPos;
                    decide = 1;
                }
                //else
                //{
                //    Vector3 temp = direction;
                //    direction = otherDirect_sec;
                //    mainDirection = direction;
                //    otherDirect_sec = temp;
                //    spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                //    startTime = Time.time;
                //}

                
                
               
            }
            else 
            {
                float num_obstacle = Random.value;
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                startTime = Time.time;
                if (num_obstacle < 0.5 && decide != 1)
                {
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    have_wall--;
                    previousTilePosition = spawnPos;
                    decide = 0;
                }
                else if(have_wall != 1)
                {
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    if(judge%2 == 1)
                        Instantiate(wall, spawnPos, Quaternion.Euler(0, 90f, 0));
                    else Instantiate(wall, spawnPos, Quaternion.Euler(0, 0, 0));
                    have_wall = 1;
                    previousTilePosition = spawnPos;
                    decide = 0;
                }
                      
                
            }
            
        }
    }
}
