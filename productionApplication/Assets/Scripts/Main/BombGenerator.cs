using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject BombPrefab;
    public GameObject Player;

    bool mouseOnFlag;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Cube.006");
        mouseOnFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !mouseOnFlag)
        {
            GameObject Bomb = Instantiate(BombPrefab, this.transform.position, Quaternion.identity);
            Bomb.transform.parent = Player.transform;
            Bomb.GetComponent<BombController>().Throw(new Vector3(300, 300, 0));
        }
    }
}
