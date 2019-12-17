using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public ParticleSystem particle;
    public void Throw(Vector3 dir)
    {
            GetComponent<Rigidbody>().AddForce(dir);
    }
    //void OnCollisionEnter(Collision other)
    //{

    //    //Destroy(other.gameObject);]
    //    GetComponent<Rigidbody>().isKinematic = true;
    //    Destroy(gameObject);
    //}
    private void OnTriggerEnter(Collider other)
    {
        particle.Play();
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject,0.15f);
    }
    // Start is called before the first frame update
    void Start()
    {
        particle= GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Throw(new Vector3(300, 300, 0));
            GetComponent<Rigidbody>().useGravity = true;
        }
        if (transform.position.x > 150.0f || transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
