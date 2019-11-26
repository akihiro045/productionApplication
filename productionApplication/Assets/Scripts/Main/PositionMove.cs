using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Vector3 Move(Vector3 temp,int direction)
    {
        switch (direction)
        {
            case 0:
                if (temp.z > -4.5f)
                {
                    temp.z -= 0.75f;
                }
                break;
            case 1:
                if (temp.z <  4.5f )
                {
                    temp.z += 0.75f;
                }
                break;
            case 2:
                if (temp.x < -1.0f)
                {
                    temp.x += 4.5f;
                }
                break;
            case 3:
                if (temp.x > -10.0f)
                {
                    temp.x -= 4.5f;
                }
                break;
        }
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
