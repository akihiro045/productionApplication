using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cResultUI
{
    public GameObject gText;
    public CharacterVoiceController hp;
}

public class ResultDirector : MonoBehaviour
{
    private cResultUI result;

    AudioSource audio;
    public AudioClip winSE;
    public AudioClip loseSE;

    public Image image;
    public Sprite[] sprites;

    //SEを多重で鳴らさないようにするフラグ
    private bool SEFlag = false;

    void SetUI()
    {
        result = new cResultUI();
        result.gText = GameObject.Find("p1VictoryOrDefeat");
    }

    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        SetUI();
    }

    void Update()
    {
        Debug.Log("hp : ");

        //フラグが立っていないときに鳴る
        if (!SEFlag)
        {
            image.sprite = null;
            if (MainDirector.playerHP > 0)
            {
                Debug.Log("win");
                audio.PlayOneShot(this.winSE);
                image.sprite = sprites[0];
            }
            else
            {
                Debug.Log("lose");
                audio.PlayOneShot(this.loseSE);
                image.sprite = sprites[1];
            }
            SEFlag = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
