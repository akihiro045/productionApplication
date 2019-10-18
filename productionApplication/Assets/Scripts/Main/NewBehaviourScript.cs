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
    public GameObject Player1;
    public GameObject Player2;
    private Vector3 temp; //仮
    [SerializeField, Range(1, 8)]
    private int m_useDisplayCount = 2;
    bool setF = false;

    string[] mic;

    public void SetKeyword()
    {
        keywords = new string[8][];
        //ここ｛｝を変更
        keywords[0] = new string[] { "りんご", "みに", "みぎ", "みみ", "みり", "いい", "right" };
        keywords[1] = new string[] { "みかん", "オレンジ", "ひだり", "left" };
        keywords[2] = new string[] { "もも", "ピーチ", "まえ" };
        keywords[3] = new string[] { "いちご", "ストロベリー", "うしろ" };
        keywords[4] = new string[] { "ストップ", "した", "とまれ" };
        keywords[5] = new string[] { "たて", "たつ", "うえ" };
        keywords[6] = new string[] { "ばん", "だん", "ぱん" };
        keywords[7] = new string[] { "ドカン", "ボン", "ドン" };

        keyCon = gameObject.AddComponent<KeywordController>();
        keyCon.SetKeywords(keywords, true);//KeywordRecognizerにkeywordsを設定する
        keyCon.StartRecognizing(0);//シーン中で音声認識を始めたいときに呼び出す
        keyCon.StartRecognizing(1);
        keyCon.StartRecognizing(2);
        keyCon.StartRecognizing(3);
        keyCon.StartRecognizing(4);
        keyCon.StartRecognizing(5);
        keyCon.StartRecognizing(6);
        keyCon.StartRecognizing(7);
        setF = true;
    }

    void MoveFront()
    {
        vector = 0.1f;
        if (this.transform.position.y > 0 && this.transform.position.x < -1.1)
        {
            this.transform.position += new Vector3(vector, 0, 0);
        }
        //keyCon.hasRecognized[2] = false;
    }

    void MoveBack()
    {
        vector = -0.1f;
        if (this.transform.position.y > 0 && this.transform.position.x > -10)
        {
            this.transform.position += new Vector3(vector, 0, 0);
        }
        //keyCon.hasRecognized[3] = false;
    }

    void MoveRight()
    {
        vector = -0.1f;
        if (this.transform.position.y > 0 && this.transform.position.z > -4.5)
        {
            this.transform.position += new Vector3(0, 0, vector);
        }
        Debug.Log(this.transform.position.z);
        //keyCon.hasRecognized[0] = false;
    }

    void MoveLeft()
    {
        vector = 0.1f;
        if (this.transform.position.y > 0 && this.transform.position.z < 4.5)
        {
            this.transform.position += new Vector3(0, 0, vector);
        }
        //keyCon.hasRecognized[1] = false;
    }

    void StopMoving()
    {
        /*vector -= 0.1f;

                    if (this.transform.position.y > 0)
                    {
                        this.transform.position += new Vector3(0, vector, 0);

                    }
                    if (vector == -0.4f)
                    {
                        vector = 0;
                        keyCon.hasRecognized[4] = false;
                    }*/
        keyCon.hasRecognized[0] = false;
        keyCon.hasRecognized[1] = false;
        keyCon.hasRecognized[2] = false;
        keyCon.hasRecognized[3] = false;
        keyCon.hasRecognized[4] = false;
        keyCon.hasRecognized[5] = false;
        keyCon.hasRecognized[6] = false;
        keyCon.hasRecognized[7] = false;
    }

    void StandUp()
    {
        vector += 0.1f;
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

    void ShootingGun()
    {
        GameObject Bullet = Instantiate(BulletPrefab) as GameObject;
        Bullet.transform.position = this.transform.position;
        Bullet.transform.position += new Vector3(1, 0, 0);
        Bullet.GetComponent<BulletController>().Shoot(new Vector3(1000, 0, 0));
        keyCon.hasRecognized[6] = false;
    }

    void ThrowBomb()
    {
        GameObject Bomb = Instantiate(BombPrefab, this.transform.position, Quaternion.identity);
        //Bomb.transform.parent = this.transform;
        Bomb.transform.position = this.transform.position;
        Bomb.transform.position += new Vector3(1.5f, 0, 0);
        Bomb.GetComponent<BombController>().Throw(new Vector3(300, 300, 0));
        keyCon.hasRecognized[7] = false;
    }

    public void VoiceController()
    {
        if (keyCon.hasRecognized[0])
        {
            Debug.Log("keyword[0] was recognized");
            MoveRight();
        }
        if (keyCon.hasRecognized[1])
        {
            Debug.Log("keyword[1] was recognized");
            MoveLeft();
        }
        if (keyCon.hasRecognized[2])//設定したKeywords[0]の単語らが認識されたらtrueになる
        {
            Debug.Log("keyword[2] was recognized");
            MoveFront();
        }
        if (keyCon.hasRecognized[3])
        {
            Debug.Log("keyword[3] was recognized");
            MoveBack();
        }
        if (keyCon.hasRecognized[4])
        {
            Debug.Log("keyword[4] was recognized");
            StopMoving();
        }
        if (keyCon.hasRecognized[5])
        {
            Debug.Log("keyword[5] was recognized");
            StandUp();
        }
        if (keyCon.hasRecognized[6])
        {
            Debug.Log("keyword[6] was recognized");
            ShootingGun();
        }
        if (keyCon.hasRecognized[7])
        {
            Debug.Log("keyword[7] was recognized");
            ThrowBomb();
        }
    }

    public void KeyboardController()
    {
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

    // Use this for initialization
    void Start()
    {
        #region 2プレイヤー分回すのでどこか別の場所に書く
        if (!setF)
        {
            SetKeyword();
        }
        #endregion
        Player1 = GameObject.Find("Cube.006");
        Player2 = GameObject.Find("Cube.007");
        mic = new string[4];
        int i = 0;
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            mic[i] = device;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //キーボードデバッグ用
        KeyboardController();
        VoiceController();
        foreach (string device in Microphone.devices)
        {
            //var mic = device;
            if (device == mic[0])//内部の処理はぶっつけ
            {
                VoiceController();
            }
            else if (device == mic[1])
            {
                VoiceController();

            }
        }
    }
}
