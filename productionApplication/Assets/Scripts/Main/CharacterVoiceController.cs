using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoiceController : MonoBehaviour
{
    public Vector3 temp;//仮
    public Vector3 oldPosition;
    public GameObject Player;

    public int playerHp=3;
    public int countBomb = 3;
    private float fieldMaxLength = 100.0f;
    private float fieldMinLength = 10.0f;
    private float fieldMaxWidth = 45.0f;
    private float fieldMinWidth= -45.0f;
    private float moveVecX;
    private float moveVecZ;
    // Start is called before the first frame update
    void Awake()
    {
        moveVecX= (fieldMaxLength - fieldMinLength) / 2;
        moveVecZ= (fieldMaxWidth - fieldMinWidth) /9;
        temp = Player.transform.position;
        oldPosition = Player.transform.position;
        FindPlayer(gameObject.tag);
    }

    void FindPlayer(string tagName)//tagから識別
    {
        if (tagName == "Player")
        {
            Player = GameObject.Find("Player1");
            temp = new Vector3(-100,42f, 0);
        }
        else if (tagName == "Player2P")
        {
            Player = GameObject.Find("Player2");
            temp = new Vector3(100, 42f, 0);
        }
    }

    public Vector3 PlayerMove(Vector3 temp, int direction)
    {
        switch (direction)
        {
            case 0:
                if (temp.z > fieldMinWidth && gameObject.tag=="Player")
                {
                    temp.z -= moveVecZ;
                }
                if (temp.z < fieldMaxWidth && gameObject.tag == "Player2P")
                {
                    temp.z += moveVecZ;
                }
                break;
            case 1:
                if (temp.z < fieldMaxWidth && gameObject.tag == "Player")
                {
                    temp.z += moveVecZ;
                }
                if (temp.z > fieldMinWidth && gameObject.tag == "Player2P")
                {
                    temp.z -= moveVecZ;
                }
                break;
            case 2:
                if (temp.x < -fieldMinLength && gameObject.tag == "Player")
                {
                    temp.x += moveVecX;
                }
                if (temp.x > fieldMinLength && gameObject.tag == "Player2P")
                {
                    temp.x -= moveVecX;
                }
                break;
            case 3:
                if (temp.x > -fieldMaxLength && gameObject.tag == "Player")
                {
                    temp.x -= moveVecX;
                }
                if (temp.x < fieldMaxLength && gameObject.tag == "Player2P")
                {
                    temp.x += moveVecX;
                }
                break;
        }
        return temp;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2P")
        {
            if (gameObject.tag == "Player" || gameObject.tag == "Player2P")
            {
                temp = oldPosition;
            }
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bullet2P" || other.gameObject.tag == "Bomb" || other.gameObject.tag == "Bomb2P")
        {
            playerHp--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
