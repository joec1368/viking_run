using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public GameObject wall;
    public GameObject coin;


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
    private int turn = 1;
    public float decidehollow = 0.23f;
    int totalcount = 0;
    int round = 1;

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
        float randoom = Random.value;
        if(randoom < 0.5)
        {
            otehrDirect = otherDirect_sec;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > timeOffset)
        {
            Vector3 spawnPos;
            float num_temp = Random.value;
            if(round == 1)
            {
                totalcount++;
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceforhollow * direction;
                startTime = Time.time;
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                previousTilePosition = spawnPos;
                decide = 0;
                have_wall = 0;
                round = 0;
            }
            else if (num_temp < decidehollow && judge >= 0 && have_wall <= 0 && totalcount <= 5)
            {
                totalcount++;
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceforhollow * direction;
                startTime = Time.time;
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                previousTilePosition = spawnPos; 
                decide = 0;
                have_wall = 0;
                
            }
            else if(num_temp < 0.7 && num_temp >= decidehollow && have_wall <= 0)
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
                Debug.Log("turn");
                totalcount = 0;



            }
            else if(num_temp >= 0.7 && totalcount <= 5)
            {
                float num_obstacle = Random.value;
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                startTime = Time.time;
                totalcount++;
                if (num_obstacle < 0.2 && totalcount <= 5)
                {
                    turn = 0;
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    have_wall= 0;
                    previousTilePosition = spawnPos;
                    decide = 0;
                }
                else if(have_wall == 0 && decide != 1&& totalcount <= 5)
                {
                    turn = 0;
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    if(judge%2 == 1)
                        Instantiate(wall, spawnPos, Quaternion.Euler(0, 90f, 0));
                    else Instantiate(wall, spawnPos, Quaternion.Euler(0, 0, 0));
                    have_wall += 1;
                    previousTilePosition = spawnPos;
                    decide = 0;
                    


                }
                //else
                //{


                //    turn = 1;
                //    judge++;
                //    Vector3 temp = direction;
                //    direction = otehrDirect;
                //    mainDirection = direction;
                //    otehrDirect = temp;
                //    spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                //    startTime = Time.time;
                //    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                //    previousTilePosition = spawnPos;
                //    decide = 1; totalcount = 0;


                //}
                if (totalcount >= 5)
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

                    totalcount = 0;
                    Debug.Log("turn");

                }


            }
            else if(totalcount >= 5)
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

                totalcount = 0;
                Debug.Log("turn");
            }
            else
            {
                turn = 0;
                direction = mainDirection;
                spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                startTime = Time.time;
                totalcount++;
                turn = 0;
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                have_wall = 0;
                previousTilePosition = spawnPos;
                decide = 0;
            }

           

            float num_random_coin;
            num_random_coin = Random.value;
            if(num_random_coin < 0.25 && totalcount <= 5)
            {
                float num_random_first = Random.value * 10 / 2 - 3;
                float num_random_second = Random.value * 10 / 2 - 3;
                Instantiate(coin, spawnPos + new Vector3(0 + num_random_first, 1.5f, 0 + num_random_second), Quaternion.Euler(0,0,0));
            }
            
        }
    }
}
