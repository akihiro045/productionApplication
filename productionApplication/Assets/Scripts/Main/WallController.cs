﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //銃弾の消去はここでやらないほうが楽かも
        // if (other.gameObject.tag == "Bullet")
        // {
        //     Destroy(other.gameObject);
        // }
        // else 
        if (other.gameObject.tag == "Floor")
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
