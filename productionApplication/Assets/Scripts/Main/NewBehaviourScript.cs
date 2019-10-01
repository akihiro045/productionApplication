using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class NewBehaviourScript : MonoBehaviour
{

    private KeywordController keyCon;
    private string[][] keywords;
    private float vector;
    public GameObject BulletPrefab;
    public GameObject BombPrefab;
    public GameObject Player;

    [SerializeField, Range(1, 8)]
    private int m_useDisplayCount = 2;
    void Awake()
    {
        int count = Mathf.Min(Display.displays.Length, m_useDisplayCount);

        for (int i = 0; i < count; ++i)
        {
            Display.displays[i].Activate();
        }
    }
    // Use this for initialization
    void Start()
    {
       
        keywords = new string[8][];
        keywords[0] = new string[] { "りんご", "みに","みぎ","みみ","みり","いい" };
        keywords[1] = new string[] { "みかん", "オレンジ", "ひだり" };
        keywords[2] = new string[] { "もも", "ピーチ", "まえ" };
        keywords[3] = new string[] { "いちご", "ストロベリー", "うしろ" };
        keywords[4] = new string[] { "しゃがみ", "した", "しゃがめ" };
        keywords[5] = new string[] { "たて", "たつ", "うえ" };
        keywords[6] = new string[] { "ばん", "だん", "ぱん" };
        keywords[7] = new string[] { "ドカン", "ボン", "ドン" };

        keyCon = gameObject.AddComponent<KeywordController>();//keywordControllerのインスタンスを作成
        keyCon.SetKeywords(keywords,true);//KeywordRecognizerにkeywordsを設定する
        keyCon.StartRecognizing(0);//シーン中で音声認識を始めたいときに呼び出す
        keyCon.StartRecognizing(1);
        keyCon.StartRecognizing(2);
        keyCon.StartRecognizing(3);
        keyCon.StartRecognizing(4);
        keyCon.StartRecognizing(5);
        keyCon.StartRecognizing(6);
        keyCon.StartRecognizing(7);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
            Bullet.transform.position = this.transform.position;
            Bullet.transform.position += new Vector3(1,0,0);
            Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
            //this.GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, 600.0f,ForceMode.Acceleration);
        }

        if (keyCon.hasRecognized[0])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            Debug.Log("keyword[0] was recognized");
            vector -= 0.1f;
            if (this.transform.position.y > 0 && this.transform.position.z > -4.5)
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
        if (keyCon.hasRecognized[6])
        {
            Debug.Log("keyword[6] was recognized");
            GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
            Bullet.transform.position = this.transform.position;
            Bullet.transform.position += new Vector3(1, 0, 0);
            Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
            keyCon.hasRecognized[6] = false;
        }
        if (keyCon.hasRecognized[7])
        {
            Debug.Log("keyword[7] was recognized");
            GameObject Bomb = Instantiate(BombPrefab, this.transform.position, Quaternion.identity);
            //Bomb.transform.parent = Player.transform;
            Bomb.transform.position = this.transform.position;
            Bomb.transform.position += new Vector3(1.5f, 0, 0);
            Bomb.GetComponent<BombController>().Throw(new Vector3(300, 300, 0));
            keyCon.hasRecognized[7] = false;
        }
    }
}