using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Cube.006");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);
            Bullet.transform.parent = Player.transform;
            Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
        }
    }
}
