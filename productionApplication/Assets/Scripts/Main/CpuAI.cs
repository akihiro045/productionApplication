using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuAI : MonoBehaviour
{
    private GameObject PlayerCpu;
    private int result;
    private int nextResult;
    private float searchValue;
    private int searchCount;
    RaycastHit hitObj;
    int distance = 200;
    int layerMask = 1 << 8;
    int bombCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCpu = GameObject.Find("Player2");
        searchValue = 0;
        nextResult = -1;
    }

    public int ActionSelectCpu(Vector3 checkPos)
    {
        Ray ray = new Ray(checkPos, new Vector3(-1, 0, 0));


        if(Physics.BoxCast(this.transform.position, Vector3.one * 0.5f, new Vector3(-1, 0, 0), out hitObj, Quaternion.identity,distance))
        {
            if (Physics.Raycast(ray, out hitObj, distance))
            {
                result = 6;
                if (hitObj.collider.tag == "Wall" && bombCount < 3)
                {
                    bombCount++;
                    result = 7;
                }
                if (hitObj.collider.tag == "Wall2P")
                {
                    if (nextResult == -1)
                    {
                        result = Random.Range(0, 2);
                        nextResult = result;
                    }
                    else
                    {
                        result = nextResult;
                    }
                }
            }
            else
            {
                result = Random.Range(0, 3);
                if (nextResult != -1)
                {
                    nextResult = 2;
                    result = nextResult;
                    nextResult = -1;
                }
            }
            
        }
        else
        {
            result = 5;
            while (result == 5)
            {
                Tracking(checkPos);
                if (searchCount > 13)
                {
                    break;
                }
            }
            searchCount = 0;
            searchValue = 0;
            if (nextResult != -1)
            {
                nextResult = 2;
                result = nextResult;
                nextResult = -1;
            }
        }
   
        return result;
    }

    void Tracking(Vector3 checkPos)
    {
        searchCount++;
        searchValue = 7.5f*searchCount;
        if(searchValue>45f)
        {
            searchValue = -7.5f*(searchCount-6);
        }
        checkPos.z += searchValue;
        Ray ray = new Ray(checkPos, new Vector3(-1, 0, 0));
        RaycastHit hitObj;
        int distance = 200;

        if (Physics.Raycast(ray, out hitObj, distance,layerMask))
        {
            if (hitObj.collider.tag == "Player")
            {
                if (searchValue > 0)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                }
            }
        }
        else
        {
            result = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
