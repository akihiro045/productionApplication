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
    public GameObject[] Player;
    public CharacterVoiceController[] characterVoiceController;
    public VoiceRecognize voiceRecognize;
    private int loopCount;
    private int[] voiceResult = { -1, -1 };//音声認識で何が認識されたか返す
    //[SerializeField, Range(1, 8)]
    //private int m_useDisplayCount = 2;

    private void Awake()
    {
        Player = new GameObject[2];
        Player[0] = GameObject.Find("Player1");
        Player[1] = GameObject.Find("Player2");
        characterVoiceController = new CharacterVoiceController[2];
        characterVoiceController[0] = Player[0].GetComponent<CharacterVoiceController>();
        characterVoiceController[1] = Player[1].GetComponent<CharacterVoiceController>();
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

    }

    void PlayerAction(int i)
    {
        if (voiceResult[i] >= 0 && voiceResult[i] < 4)
        {
            characterVoiceController[i].temp = characterVoiceController[i].PlayerMove(characterVoiceController[i].Player.transform.position, voiceResult[i]);
        }
        if (voiceResult[i] == 6)
        {
            GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
            Bullet.transform.position = characterVoiceController[i].Player.transform.position;
            Bullet.transform.position += new Vector3(1.0f, 0, 0);
            Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
        }
        if (voiceResult[i] == 7)
        {
            GameObject Bomb = Instantiate(BombPrefab, characterVoiceController[i].Player.transform.position, Quaternion.identity);
            //Bomb.transform.parent = Player.transform;
            Bomb.transform.position = characterVoiceController[i].Player.transform.position;
            Bomb.transform.position += new Vector3(1.5f, 0, 0);
            Bomb.GetComponent<BombController>().Throw(new Vector3(300, 300, 0));
        }

    }

    void PlayerMoving(int i)
    {
        characterVoiceController[i].Player.transform.position = Vector3.MoveTowards(characterVoiceController[i].Player.transform.position, characterVoiceController[i].temp, 2.0f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()

    {
        loopCount = 0;
        foreach (string device in Microphone.devices)
        {
            //Debug.Log(loopCount);
            if (characterVoiceController[loopCount].Player.transform.position == characterVoiceController[loopCount].temp)
            {
                voiceRecognize.KeyBoardController(loopCount);
                voiceRecognize.VoiceController(loopCount);
                voiceResult[loopCount] = voiceRecognize.result;
                PlayerAction(loopCount);
                characterVoiceController[loopCount].oldPosition = characterVoiceController[loopCount].Player.transform.position;

            }
            else
            {
                PlayerMoving(loopCount);
            }
            loopCount++;
        }
    }
}