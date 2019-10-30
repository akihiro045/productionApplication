using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class GameMain : MonoBehaviour
{
    private string[] mic = new string[2];
    private float vector;
    public GameObject BulletPrefab;
    public GameObject BombPrefab;
    public GameObject BulletPrefab2;
    public GameObject BombPrefab2;
    public GameObject[] Player;
    public CharacterVoiceController[] characterVoiceController;
    public VoiceRecognize voiceRecognize;
    private int loopCount;

    private int delayCount=0;
    private int[] voiceResult = { -1, -1 };//音声認識で何が認識されたか返す
    //[SerializeField, Range(1, 8)]
    //private int m_useDisplayCount = 2;

    private void Awake()
    {
        voiceRecognize = gameObject.AddComponent<VoiceRecognize>();
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            mic[loopCount] = device;
            loopCount++;
        }
    }

    // Use this for initialization
    void Start()
    {
        Player = new GameObject[2];
        Player[0] = GameObject.Find("Player1");
        Player[1] = GameObject.Find("Player2");
        characterVoiceController = new CharacterVoiceController[2];
        characterVoiceController[0] = Player[0].GetComponentInChildren<CharacterVoiceController>();
        characterVoiceController[1] = Player[1].GetComponentInChildren<CharacterVoiceController>();
    }

    void PlayerAction(int i)
    {
        if (voiceResult[i] >= 0 && voiceResult[i] < 4)
        {
            characterVoiceController[i].temp = characterVoiceController[i].PlayerMove(characterVoiceController[i].Player.transform.position, voiceResult[i]);
        }
        if (voiceResult[i] == 6)
        {
            if(i==0)
            {
                GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
                Bullet.transform.position = characterVoiceController[i].Player.transform.position;
                Bullet.transform.position += new Vector3(1.0f, 0.5f, 0);
                Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
            }
            else if(i==1)
            {
                GameObject Bullet = Instantiate(BulletPrefab2) as GameObject;
                Bullet.transform.position = characterVoiceController[i].Player.transform.position;
                Bullet.transform.position += new Vector3(-1.0f, 0, 0);
                Bullet.GetComponent<BulletController>().Shoot(new Vector3(-1000, 0, 0));
            }
        }
        if (voiceResult[i] == 7 && characterVoiceController[i].countBomb > 0)
        {
            if(i==0)
            {
                GameObject Bomb = Instantiate(BombPrefab, characterVoiceController[i].Player.transform.position, Quaternion.identity);
                Bomb.transform.position = characterVoiceController[i].Player.transform.position;
                Bomb.transform.position += new Vector3(1.0f, 0.5f, 0);
                Bomb.GetComponent<BombController>().Throw(new Vector3(300, 0, 0));
            }
            else if(i==1)
            {
                GameObject Bomb = Instantiate(BombPrefab2, characterVoiceController[i].Player.transform.position, Quaternion.identity);
                Bomb.transform.position = characterVoiceController[i].Player.transform.position;
                Bomb.transform.position += new Vector3(-1.0f, 0, 0);
                Bomb.GetComponent<BombController>().Throw(new Vector3(-300, 0, 0));
            }
            characterVoiceController[i].countBomb--;
        }
        characterVoiceController[loopCount].oldPosition = characterVoiceController[loopCount].Player.transform.position;
    }

    void PlayerMoving(int i)
    {
          
          characterVoiceController[i].Player.transform.position = Vector3.MoveTowards(characterVoiceController[i].Player.transform.position, characterVoiceController[i].temp, 2.0f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()

    {
        loopCount = 0;
        //foreach (string device in Microphone.devices)
        for(loopCount=0;loopCount<2;loopCount++)
        {
            //Debug.Log(loopCount);
            if (characterVoiceController[loopCount].Player.transform.position == characterVoiceController[loopCount].temp)
            {            
                voiceRecognize.KeyBoardController(loopCount);
                voiceRecognize.VoiceController(loopCount);
                if(loopCount==0)
                {
                    voiceResult[loopCount] = voiceRecognize.result;
                }
                else if(loopCount==1)
                {
                    if(delayCount==200)
                    {
                        delayCount=0;
                        voiceResult[loopCount] = Random.Range(0,8);
                        //voiceResult[loopCount] = 2;
                    }
                    else
                    {
                        delayCount++;
                        voiceResult[loopCount] = 5;
                    }
                    Debug.Log(voiceResult[loopCount]);
                }
                PlayerAction(loopCount);      
            }
            else
            {
                //Debug.Log(device);
                PlayerMoving(loopCount);
            }
            //loopCount++;
        }
    }
}