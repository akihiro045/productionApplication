using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject WallPrefab2;
    private int pattern;
    private const int wallMax=8;
    GameObject[] Wall;

    // Start is called before the first frame update
    void Start()
    {
        
        Wall =new GameObject[wallMax];
        pattern = Random.Range(0,2);
        SetWall(pattern);
    }

    void SetWall(int pattern)
    {
        for (int i = 0; i < wallMax/2; i++)
        {
            Wall[i] = Instantiate(WallPrefab2) as GameObject;
        }
        for (int i = wallMax / 2; i < wallMax ; i++)
        {
            Wall[i] = Instantiate(WallPrefab) as GameObject;
        }
        switch (pattern)
        {
            case 0:
                Wall[0].transform.position = new Vector3(-8.0f, 0.8f, 0.0f);
                Wall[1].transform.position = new Vector3(-8.0f, 0.8f, 5.0f);
                Wall[2].transform.position = new Vector3(-8.0f, 0.8f, -5.0f);
                Wall[3].transform.position = new Vector3(-5.0f, 0.8f, 0.0f);
                Wall[4].transform.position = new Vector3(5.0f, 0.8f, 4.0f);
                Wall[5].transform.position = new Vector3(8.0f, 0.8f, 2.5f);
                Wall[6].transform.position = new Vector3(8.0f, 0.8f, -2.5f);
                Wall[7].transform.position = new Vector3(5.0f, 0.8f, -4.0f);
                break;
            case 1:
                Wall[0].transform.position = new Vector3(-8.0f, 0.8f, 0.0f);
                Wall[1].transform.position = new Vector3(-5.0f, 0.8f, 5.0f);
                Wall[2].transform.position = new Vector3(-5.0f, 0.8f, -5.0f);
                Wall[3].transform.position = new Vector3(-5.0f, 0.8f, 0.0f);
                Wall[4].transform.position = new Vector3(8.0f, 0.8f, 4.0f);
                Wall[5].transform.position = new Vector3(5.0f, 0.8f, 2.5f);
                Wall[6].transform.position = new Vector3(5.0f, 0.8f, -2.5f);
                Wall[7].transform.position = new Vector3(8.0f, 0.8f, -4.0f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
