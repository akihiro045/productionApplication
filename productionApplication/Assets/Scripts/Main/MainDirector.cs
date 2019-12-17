using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cUI
{
    public GameObject gCanvas;
    public GameObject[] gHP;
    public GameObject gBomb;
    public GameObject gResult;

    public int bombCount = 3;

    public void HPTextIndicate(int hp)
    {
        switch(hp)
        {
            case 3:
            this.gHP[0].transform.localPosition = new Vector3(-950.0f , -360.0f, 130.0f);
            this.gHP[1].transform.localPosition = new Vector3(-950.0f , -360.0f, 110.0f);
            this.gHP[2].transform.localPosition = new Vector3(-950.0f , -360.0f, 90.0f);
            break;
            
            case 2:
            this.gHP[0].transform.localPosition = new Vector3(-950.0f , -360.0f, 130.0f);
            this.gHP[1].transform.localPosition = new Vector3(-950.0f , -360.0f, 110.0f);
            this.gHP[2].transform.localPosition = new Vector3(-950.0f , 0.0f, 90.0f);
            break;

            case 1:
            this.gHP[0].transform.localPosition = new Vector3(-950.0f , -360.0f, 130.0f);
            this.gHP[1].transform.localPosition = new Vector3(-950.0f , 0.0f, 110.0f);
            this.gHP[2].transform.localPosition = new Vector3(-950.0f , 0.0f, 90.0f);
            break;
        }
    }

    public void BombTextIndicate(int count)
    {
        switch (count)
        {
            case 3:
                this.gBomb.GetComponent<Text>().text = "× 3";
                break;
            case 2:
                this.gBomb.GetComponent<Text>().text = "× 2";
                break;
            case 1:
                this.gBomb.GetComponent<Text>().text = "× 1";
                break;
            case 0:
                this.gBomb.GetComponent<Text>().text = "× 0";
                break;
        }
    }
}
public class MainDirector : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    private int m_useDisplayCount = 2;

    public NewBehaviourScript script;
    cUI p1UI;
    cUI p2UI;

    private GameObject player;
    private GameObject cpu;
    public CharacterVoiceController mainPlayer;
    public CharacterVoiceController cpuPlayer;

    //ゲーム中のHP
    public static int playerHP;
    public static int enemyHP;

    AudioSource audio;

    public AudioClip gunSE;
    public AudioClip bombSE;
    public AudioClip moveSE;
    public AudioClip finishSE;
    private int time;
    bool finishF;

    //初期HP
    private int firstPlayerHP = 3;
    private int firstEnemyHP = 3;

    public void SetUI()
    {

        p1UI = new cUI();
        p2UI = new cUI();

        p1UI.gHP = new GameObject[firstPlayerHP];

        p1UI.gCanvas = GameObject.Find("player1UI");
        p1UI.gBomb = GameObject.Find("player1RemainingBomb");
        p1UI.gResult = GameObject.Find("player1Result");
        p1UI.gHP[0] = GameObject.Find("Player1HP");
        p1UI.gHP[1] = GameObject.Find("Player1HP1");
        p1UI.gHP[2] = GameObject.Find("Player1HP2");
        // p2UI.gCanvas = GameObject.Find("player2UI");
        // p2UI.gHP = GameObject.Find("player2HP");
        // p2UI.gBomb = GameObject.Find("player2RemainingBomb");
        // p2UI.gResult = GameObject.Find("player2Result");

        //プレイヤーとcomのHPの初期化
        //playerHP = firstPlayerHP;
        //enemyHP = firstEnemyHP;
    }

    //デバッグ用
    private void DebugController()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //DamagePlayerHP();
            //Destroy(p1UI.gHP[GetPlayerHP()]);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
           // com.playerHp--;
            //DamageEnemyHP();
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            p1UI.bombCount--;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            p2UI.bombCount--;
        }
    }

    void Awake()
    {
        int count = Mathf.Min(Display.displays.Length, m_useDisplayCount);
        player= GameObject.Find("Player1");
        cpu = GameObject.Find("Player2");
        mainPlayer = player.GetComponent<CharacterVoiceController>();
        cpuPlayer = cpu.GetComponent<CharacterVoiceController>();
        for (int i = 0; i < count; ++i)
        {
            Display.displays[i].Activate();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHP = mainPlayer.playerHp;
        enemyHP = cpuPlayer.playerHp;
        SetUI();  
        audio = GetComponent<AudioSource>();
        finishF = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }

        DebugController();

        p1UI.HPTextIndicate(mainPlayer.playerHp);
        //p2UI.HPTextIndicate();
        p1UI.BombTextIndicate(mainPlayer.countBomb);
        //p2UI.BombTextIndicate();

        if (mainPlayer.playerHp < 1 || cpuPlayer.playerHp < 1)
        {
            playerHP = mainPlayer.playerHp;
            enemyHP = cpuPlayer.playerHp;
            SceneManager.LoadScene("Result");
        }

    }
}