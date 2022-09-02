using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject objToSpawn;
    public float timer;
    public float spawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoords;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        this.timer = 0;
        this.spawnPeriod = 5.0f;
        this.numberSpawnedEachPeriod = 3;
        this.originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer > this.spawnPeriod)
        {
            this.timer = 0;
            float width = Screen.width;
            float height = Screen.height;
            for (int i = 0; i < this.numberSpawnedEachPeriod; i++)
            {
                float horizontalPos = Random.Range(0.0f, width);
                float verticalPos = Random.Range(0.0f, height);
                Instantiate(this.objToSpawn,
                Camera.main.ScreenToWorldPoint(
                new Vector3(horizontalPos,
                verticalPos, originInScreenCoords.z)),
                Quaternion.identity);
            }
        }
        /* if you want to verify that this method works, uncomment 
          this  code.  What  will  happen  when  it  runs  is  that  one  object  will  be  spawned 
          at  each  corner  of  the  screen,  regardless  of  the  size  of  the  screen.  If  you 
          pause the Scene and inspect each object, you will see that each has a Y coordinate
          value of 0.
        */

        /* 
        Vector3 botLeft = new Vector3(0, 0, this.originInScreenCoords.z);  
        Vector3 botRight = new Vector3(width, 0, this.originInScreenCoords.z); 
        Vector3 topLeft = new Vector3(0, height, this.originInScreenCoords.z); 
        Vector3 topRight = new Vector3(width, height, this.originInScreenCoords.z); 
        Instantiate(this.objToSpawn, Camera.main.ScreenToWorldPoint(topLeft), Quaternion.identity );  
        Instantiate(this.objToSpawn, Camera.main.ScreenToWorldPoint(topRight), Quaternion.identity);  
        Instantiate(this.objToSpawn, Camera.main.ScreenToWorldPoint(botLeft), Quaternion.identity); 
        Instantiate(this.objToSpawn, Camera.main.ScreenToWorldPoint(botRight), Quaternion.identity);
        */

    }
}
