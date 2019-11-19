using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cUI
{
    public GameObject gCanvas;
    public GameObject gHP;
    public GameObject gBomb;
    public GameObject gResult;

    public int bombCount = 3;

    public void HPTextIndicate(int hp)
    {
        switch (hp)
        {
            case 3:
                this.gHP.GetComponent<Text>().text = "たいりょく■　■　■";
                break;
            case 2:
                this.gHP.GetComponent<Text>().text = "たいりょく■　■";
                break;
            case 1:
                this.gHP.GetComponent<Text>().text = "たいりょく■";
                break;
            case 0:
                this.gHP.GetComponent<Text>().text = "たいりょく";
                break;
        }
    }

    public void BombTextIndicate(int count)
    {
        switch (count)
        {
            case 3:
                this.gBomb.GetComponent<Text>().text = "ばくだん　●　●　●";
                break;
            case 2:
                this.gBomb.GetComponent<Text>().text = "ばくだん　●　●";
                break;
            case 1:
                this.gBomb.GetComponent<Text>().text = "ばくだん　●";
                break;
            case 0:
                this.gBomb.GetComponent<Text>().text = "ばくだん";
                break;
        }
    }

    public void ResultTextIndicate(int hp, int time)
    {
        if (hp > 0)
        {
            this.gResult.GetComponent<Text>().text = "う　ぃ　ん";
        }
        else if (hp < 1)
        {
            this.gResult.GetComponent<Text>().text = "る　－　ず";
        }

        if (time > 5000)
            SceneManager.LoadScene("TitleScene");
    }
}


public class MainDirector : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    private int m_useDisplayCount = 2;

    public NewBehaviourScript script;
    cUI p1UI;
    cUI p2UI;

    public CharacterVoiceController mainPlayer;
    public CharacterVoiceController com;

    AudioSource audio;

    public AudioClip gunSE;
    public AudioClip bombSE;
    public AudioClip moveSE;
    public AudioClip finishSE;
    private int time;
    bool finishF;

    private int playerHP;
    private int enemyHP;

    public void SetUI()
    {

        p1UI = new cUI();
        p2UI = new cUI();

        p1UI.gCanvas = GameObject.Find("player1UI");
        p1UI.gHP = GameObject.Find("player1HP");
        p1UI.gBomb = GameObject.Find("player1RemainingBomb");
        p1UI.gResult = GameObject.Find("player1Result");

        p2UI.gCanvas = GameObject.Find("player2UI");
        p2UI.gHP = GameObject.Find("player2HP");
        p2UI.gBomb = GameObject.Find("player2RemainingBomb");
        p2UI.gResult = GameObject.Find("player2Result");

        playerHP = CharacterVoiceController.GetHP();
    }

    void Awake()
    {
        int count = Mathf.Min(Display.displays.Length, m_useDisplayCount);

        for (int i = 0; i < count; ++i)
        {
            Display.displays[i].Activate();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
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
        #region プレイヤーのHPが減ったら動くようにする
        if (Input.GetKeyDown(KeyCode.P))
        {
            CharacterVoiceController.DamageHp();
            playerHP--;
        }
        if (Input.GetKeyDown(KeyCode.Q))
            //com.playerHp--;

            if (Input.GetKeyDown(KeyCode.Slash))
                p1UI.bombCount--;

        if (Input.GetKeyDown(KeyCode.F))
            p2UI.bombCount--;

        p1UI.HPTextIndicate(playerHP);
        //p2UI.HPTextIndicate();
        #endregion
        p1UI.BombTextIndicate(mainPlayer.countBomb);
        //p2UI.BombTextIndicate();

        if (playerHP < 1)
        {
            // if (!finishF)
            //     audio.PlayOneShot(finishSE);
            // finishF = true;


            //DontDestroyOnLoad();
            SceneManager.LoadScene("Result");
        }
    }
}