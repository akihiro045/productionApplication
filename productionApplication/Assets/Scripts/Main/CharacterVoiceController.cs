using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoiceController : MonoBehaviour
{
    public Vector3 temp;//仮
    public Vector3 oldPosition;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer(gameObject.tag);

        temp = Player.transform.position;
        oldPosition= Player.transform.position;

    }

    void FindPlayer(string tagName)//tagから識別
    {
        if (tagName == "Player")
        {
            Player = GameObject.Find("Cube.006");
        }
        else if (tagName == "Player2P")
        {
            Player = GameObject.Find("Cube.007");
        }
    }

    public Vector3 PlayerMove(Vector3 temp, int direction)
    {
        switch (direction)
        {
            case 0:
                if (temp.z > -4.5f&&gameObject.tag=="Player")
                {
                    temp.z -= 0.75f;
                }
                if (temp.z < 4.5f && gameObject.tag == "Player2P")
                {
                    temp.z += 0.75f;
                }
                break;
            case 1:
                if (temp.z < 4.5f && gameObject.tag == "Player")
                {
                    temp.z += 0.75f;
                }
                if (temp.z > -4.5f && gameObject.tag == "Player2P")
                {
                    temp.z -= 0.75f;
                }
                break;
            case 2:
                if (temp.x < -1.0f && gameObject.tag == "Player")
                {
                    temp.x += 4.5f;
                }
                if (temp.x > 1.0f && gameObject.tag == "Player2P")
                {
                    temp.x -= 4.5f;
                }
                break;
            case 3:
                if (temp.x > -10.0f && gameObject.tag == "Player")
                {
                    temp.x -= 4.5f;
                }
                if (temp.x < 10.0f && gameObject.tag == "Player2P")
                {
                    temp.x += 4.5f;
                }
                break;
        }
        return temp;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (gameObject.tag == "Player"||gameObject.tag=="Player2P")
            {
                temp = oldPosition;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
