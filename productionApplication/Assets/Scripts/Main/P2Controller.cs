using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : MonoBehaviour
{
    NewBehaviourScript script;
    // Start is called before the first frame update
    void Start()
    {
        this.script = GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //script.KeyboardController();
        foreach (string device in Microphone.devices)
        {
            if (device == "USB PnP Sound Device")
            {
                //script.VoiceController();
            }
        }
    }
}
