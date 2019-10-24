using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognize : MonoBehaviour
{
    private KeywordController keyCon;
    private string[][] keywords;
    public int result;
    // Start is called before the first frame update
    void Start()
    {
        keywords = new string[8][];
        keywords[0] = new string[] { "りんご", "みに", "みぎ", "みみ", "みり", "いい" };
        keywords[1] = new string[] { "みかん", "オレンジ", "ひだり" };
        keywords[2] = new string[] { "もも", "ピーチ", "まえ" };
        keywords[3] = new string[] { "いちご", "ストロベリー", "うしろ" };
        keywords[4] = new string[] { "ストップ", "した", "とまれ" };
        keywords[5] = new string[] { "たて", "たつ", "うえ" };
        keywords[6] = new string[] { "ばん", "だん", "ぱん" };
        keywords[7] = new string[] { "ドカン", "ボン", "ドン" };

        keyCon = gameObject.AddComponent<KeywordController>();//keywordControllerのインスタンスを作成
        keyCon.SetKeywords(keywords, true);//KeywordRecognizerにkeywordsを設定する
        StartRecognizing();
    }
    void StartRecognizing()
    {
        keyCon.StartRecognizing(0);//シーン中で音声認識を始めたいときに呼び出す
        keyCon.StartRecognizing(1);
        keyCon.StartRecognizing(2);
        keyCon.StartRecognizing(3);
        keyCon.StartRecognizing(4);
        keyCon.StartRecognizing(5);
        keyCon.StartRecognizing(6);
        keyCon.StartRecognizing(7);
    }
    void StopRecognizing()
    {
        keyCon.StopRecognizing(0);
        keyCon.StopRecognizing(1);
        keyCon.StopRecognizing(2);
        keyCon.StopRecognizing(3);
        keyCon.StopRecognizing(4);
        keyCon.StopRecognizing(5);
        keyCon.StopRecognizing(6);
        keyCon.StopRecognizing(7);
    }
    public void KeyBoardController(int i)
    {
        //キーボードデバッグ用
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyCon.hasRecognized[0] = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyCon.hasRecognized[1] = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyCon.hasRecognized[2] = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyCon.hasRecognized[3] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            keyCon.hasRecognized[4] = true;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            keyCon.hasRecognized[6] = true;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            keyCon.hasRecognized[7] = true;
        }
    }
    public void VoiceController(int i)
    {
        //音声
        if (keyCon.hasRecognized[0])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            Debug.Log("keyword[0] was recognized");
            result = 0;
            Debug.Log(this.transform.position.z);
            keyCon.hasRecognized[0] = false;
        }
        else if (keyCon.hasRecognized[1])
        {
            Debug.Log("keyword[1] was recognized");
            result = 1;
            keyCon.hasRecognized[1] = false;
        }
        else if (keyCon.hasRecognized[2])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            Debug.Log("keyword[2] was recognized");
            result = 2;
            Debug.Log(this.transform.position.x);
            keyCon.hasRecognized[2] = false;
        }
        else if (keyCon.hasRecognized[3])
        {
            Debug.Log("keyword[3] was recognized");
            result = 3;
            keyCon.hasRecognized[3] = false;
        }
        else if (keyCon.hasRecognized[4])
        {
            Debug.Log("keyword[4] was recognized");
            keyCon.hasRecognized[0] = false;
            keyCon.hasRecognized[1] = false;
            keyCon.hasRecognized[2] = false;
            keyCon.hasRecognized[3] = false;
            keyCon.hasRecognized[4] = false;
            keyCon.hasRecognized[5] = false;
            keyCon.hasRecognized[6] = false;
            keyCon.hasRecognized[7] = false;
            result = 4;
        }
        else if (keyCon.hasRecognized[5])
        {
            result = 5;
        }
        else if (keyCon.hasRecognized[6])
        {
            Debug.Log("keyword[6] was recognized");
            result = 6;
            keyCon.hasRecognized[6] = false;
        }
        else if (keyCon.hasRecognized[7])
        {
            Debug.Log("keyword[7] was recognized");
            result = 7;
            keyCon.hasRecognized[7] = false;
        }
        else
        {
            result = -1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
