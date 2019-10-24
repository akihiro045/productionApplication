using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private int hp=3;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if (other.gameObject.tag == "Bullet")
        {
            hp--;
        }
        if (other.gameObject.tag == "Bomb")
        {
            hp-=3;
        }
        if (hp <= 0)
            Destroy(gameObject);
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
