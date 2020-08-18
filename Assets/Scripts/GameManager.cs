using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    List<GameObject> currentObstacles = new List<GameObject>();

    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        NextLevel();
    }

    public void NextLevel()
    {
        // Used to delete any items from the last level
        foreach(GameObject obstacle in currentObstacles)
        {
            Destroy(obstacle);
        }
        float[] xLocations = { -10, 0, 10 };
        float[] zLocations = { -12, 0, 12};
        // Used to track the spot that does not have a wall each loop
        int blankIndex = -1;
        for(int i = 0; i< 3; i++)
        {
            int zIndex1 = blankIndex > -1 ? blankIndex : Random.Range(0, zLocations.Length);
            int zIndex2 = Random.Range(0, zLocations.Length);
            while(zIndex1 == zIndex2)
            {
                zIndex2 = Random.Range(0, zLocations.Length);
            }
            Vector3 location = new Vector3(xLocations[i], 1, zLocations[zIndex1]);
            currentObstacles.Add(Instantiate(obstaclePrefab, location, Quaternion.Euler(0, 90, 0)));
            location = new Vector3(xLocations[i], 1, zLocations[zIndex2]);
            currentObstacles.Add(Instantiate(obstaclePrefab, location, Quaternion.Euler(0, 90, 0)));
            currentObstacles[currentObstacles.Count - 1].transform.localScale += new Vector3(-0.001f, -0.001f, -0.001f);
            blankIndex = 0;
            if(blankIndex == zIndex1 || blankIndex == zIndex2)
            {
                blankIndex = 1;
            }
            if (blankIndex == zIndex1 || blankIndex == zIndex2)
            {
                blankIndex = 2;
            }
        }
    }
    
}
