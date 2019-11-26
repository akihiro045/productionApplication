using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cResultUI
{
    public GameObject gText;
    public CharacterVoiceController hp;
}
public class ResultDirector : MonoBehaviour
{
    private cResultUI[] result;

    void SetUI()
    {
        result[0] = new cResultUI();
        //result[1] = new cResultUI();


        result[0].gText = GameObject.Find("p1VictoryOrDefeat");
        //result[1].gText = GameObject.Find("p2VictoryOrDefeat");

    }

    void Start()
    {
        SetUI();
    }

    void Update()
    {
        Debug.Log("hp : ");

        if (MainDirector.playerHP > 0)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("lose");
        }
    }
}
