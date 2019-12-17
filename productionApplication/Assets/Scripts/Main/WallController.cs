using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public int hp = 3;
    private int wallCount = -1;
    void OnCollisionEnter(Collision other)
    {

        //   Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet2P")
        {
            hp--;
            wallCount++;
            transform.GetChild(wallCount).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(wallCount).gameObject.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(-700.0f, 200.0f, 0.0f), transform.GetChild(wallCount).transform.position);
            StartCoroutine(DestroyWall(wallCount));
            //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 50.0f,-1000.0f));
        }
        /*if (other.gameObject.tag == "Bomb2P" && gameObject.tag != "BigWall")
        {
            hp--;
            GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<Rigidbody>().AddForce(new Vector3(-1000.0f, 50.0f,0.0f));
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 50.0f, -1000.0f));
        }*/
        if (other.gameObject.tag == "Bomb2P")
        {
            Destroy(gameObject);
        }
        if (hp <= 0)
        {
            StartCoroutine(DestroyWall(4));
        }
    }

    IEnumerator DestroyWall(int wallNum)
    {
        yield return new WaitForSeconds(2.0f);
        if (wallNum >= 4)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.GetChild(wallCount).gameObject.transform.position += new Vector3(0, -50, 0);
        }
        Debug.LogFormat("destroy");
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
