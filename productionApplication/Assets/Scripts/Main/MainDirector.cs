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

    public int iHP = 3;
    public int bombCount = 3;
    //TODO : テキストUIの名前変更
    public void HPTextController()
    {
        switch (iHP)
        {
            case 3:
                this.gHP.GetComponent<Text>().text = "たいりょく ■ ■ ■";
                break;
            case 2:
                this.gHP.GetComponent<Text>().text = "たいりょく ■ ■";
                break;
            case 1:
                this.gHP.GetComponent<Text>().text = "たいりょく ■";
                break;
            case 0:
                this.gHP.GetComponent<Text>().text = "たいりょく ";
                break;
        }

    }

    public void BombTextController()
    {
        switch (bombCount)
        {
            case 3:
                this.gBomb.GetComponent<Text>().text = "ば　く　だ　ん";
                break;
            case 2:
                this.gBomb.GetComponent<Text>().text = "ば　く　だ";
                break;
            case 1:
                this.gBomb.GetComponent<Text>().text = "ば　く";
                break;
            case 0:
                this.gBomb.GetComponent<Text>().text = "ば";
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


    public void SetUI()
    {
        p1UI = new cUI();
        p2UI = new cUI();

        p1UI.gCanvas = GameObject.Find("player1UI");
        p1UI.gHP = GameObject.Find("player1HP");
        p1UI.gBomb = GameObject.Find("player1RemainingBomb");

        p2UI.gCanvas = GameObject.Find("player2UI");
        p2UI.gHP = GameObject.Find("player2HP");
        p2UI.gBomb = GameObject.Find("player2RemainingBomb");
    }

    void MigrationResult()
    {
        //いずれはリザルト画面に移行
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
        #region プレイヤーのHPが減ったら動くようにする
        if (Input.GetKeyDown(KeyCode.G))
            p1UI.iHP--;

        if (Input.GetKeyDown(KeyCode.Q))
            p2UI.iHP--;

        if (Input.GetKeyDown(KeyCode.Slash))
            p1UI.bombCount--;

        if (Input.GetKeyDown(KeyCode.Slash) && Input.GetKeyDown(KeyCode.LeftShift))
            p2UI.bombCount--;

        p1UI.HPTextController();
        p2UI.HPTextController();
        #endregion
        p1UI.BombTextController();
        p2UI.BombTextController();
    }
}
