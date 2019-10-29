
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class NewBehaviourScript : MonoBehaviour
{

    private KeywordController keyCon;
    private string[][] keywords;
    private float vector;

    // Use this for initialization
    void Start()
    {
        keywords = new string[6][];
        keywords[0] = new string[] { "りんご", "みに","みぎ","みみ","みり","いい" };//ひらがなでもカタカナでもいい
        keywords[1] = new string[] { "みかん", "オレンジ", "ひだり" };
        keywords[2] = new string[] { "もも", "ピーチ", "まえ" };//ひらがなでもカタカナでもいい
        keywords[3] = new string[] { "いちご", "ストロベリー", "うしろ" };
        keywords[4] = new string[] { "しゃがみ", "した", "しゃがめ" };
        keywords[5] = new string[] { "たて", "たつ", "うえ" };

        keyCon = new KeywordController(keywords, true);//keywordControllerのインスタンスを作成
        keyCon.SetKeywords();//KeywordRecognizerにkeywordsを設定する
        keyCon.StartRecognizing(0);//シーン中で音声認識を始めたいときに呼び出す
        keyCon.StartRecognizing(1);
        keyCon.StartRecognizing(2);//シーン中で音声認識を始めたいときに呼び出す
        keyCon.StartRecognizing(3);
        keyCon.StartRecognizing(4);
        keyCon.StartRecognizing(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCon.hasRecognized[0])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            Debug.Log("keyword[0] was recognized");
            vector -= 0.1f;
            if (this.transform.position.y > 0&& this.transform.position.z >-4.5)
            {
                this.transform.position += new Vector3(0, 0, vector);
            }
            if (vector == -0.5f)
            {
                vector = 0;
                keyCon.hasRecognized[0] = false;
            }
        }
        if (keyCon.hasRecognized[1])
        {
            vector += 0.1f;
            Debug.Log("keyword[1] was recognized");
            if (this.transform.position.y > 0 && this.transform.position.z < 4.5)
            {
                this.transform.position += new Vector3(0, 0, vector);
            }
            if (vector == 0.5f)
            {
                vector = 0;
                keyCon.hasRecognized[1] = false;
            }
        }
        if (keyCon.hasRecognized[2])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            vector += 0.1f;
            Debug.Log("keyword[2] was recognized");
            if (this.transform.position.y > 0 && this.transform.position.x < -1.1)
            {
                this.transform.position += new Vector3(vector, 0, 0);
            }
            if (vector == 0.5f)
            {
                vector = 0;
                keyCon.hasRecognized[2] = false;
            }
        }
        if (keyCon.hasRecognized[3])
        {
            vector -= 0.1f;
            Debug.Log("keyword[3] was recognized");
            if (this.transform.position.y > 0 && this.transform.position.x > -10)
            {
                this.transform.position += new Vector3(vector, 0, 0);
            }
            if (vector == -0.5f)
            {
                vector = 0;
                keyCon.hasRecognized[3] = false;
            }
        }
        if (keyCon.hasRecognized[4])
        {
            vector -= 0.1f;
            Debug.Log("keyword[4] was recognized");
            if (this.transform.position.y > 0)
            {
                this.transform.position += new Vector3(0, vector, 0);

            }
            if (vector == -0.4f)
            {
                vector = 0;
                keyCon.hasRecognized[4] = false;
            }
        }
        if (keyCon.hasRecognized[5])
        {
            vector += 0.1f;
            Debug.Log("keyword[5] was recognized");
            if (this.transform.position.y < 0.8f)
            {
                this.transform.position += new Vector3(0, vector, 0);
            }
            if (vector == 0.4f)
            {
                vector = 0;
                keyCon.hasRecognized[5] = false;
            }
        }
    }
}