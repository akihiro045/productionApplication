using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
            Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
        }
    }
}
