using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cTitleUI
{
    public GameObject gStart;
    public GameObject gExit;


    public int Index(int index)
    {
        int num = index;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            num++;
            if (num > 1)
            {
                num = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            num--;
            if (num < 0)
                num = 1;
        }
        return num;
    }

    public void UIIndicate(int index)
    {
        switch (index)
        {
            case 0:
                this.gStart.GetComponent<Text>().color = new Color(255, 0, 0, 1);
                this.gExit.GetComponent<Text>().color = new Color(255, 255, 255, 1);
                this.gStart.GetComponent<Text>().text = "すたーと";
                this.gExit.GetComponent<Text>().text = "おわり";
                break;
            case 1:
                this.gStart.GetComponent<Text>().color = new Color(255, 255, 255, 1);
                this.gExit.GetComponent<Text>().color = new Color(255, 0, 0, 1);
                this.gStart.GetComponent<Text>().text = "すたーと";
                this.gExit.GetComponent<Text>().text = "おわり";
                break;
        }
    }

    public void MigrationScene(int num, AudioSource audio, AudioClip se)
    {
        switch (num)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //audio.PlayOneShot(se);
                    SceneManager.LoadScene("GameScene");
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                }
                break;
        }
    }
}
public class TitleDirector : MonoBehaviour
{
    cTitleUI p1UI;
    cTitleUI p2UI;

    public AudioClip choseSE;
    AudioSource audio;
    int index;

    void SetUI()
    {
        index = 0;
        p1UI = new cTitleUI();
        //p2UI = new cTitleUI();

        p1UI.gStart = GameObject.Find("Start1");
        p1UI.gExit = GameObject.Find("Exit1");

        // p2UI.gStart = GameObject.Find("Start2");
        // p2UI.gExit = GameObject.Find("Exit2");
    }
    void Start()
    {
        SetUI();
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        index = p1UI.Index(index);

        p1UI.UIIndicate(index);
        //p2UI.UIIndicate(index);

        p1UI.MigrationScene(index, audio, choseSE);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
