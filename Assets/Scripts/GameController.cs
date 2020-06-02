using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ballPrefab;
    GameObject ballInstance;
    Vector3 mouseStart, mouseEnd;

    // Start is called before the first frame update
    void Start()
    {
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }
    }

    void CreateBall()
    {
        ballInstance = Instantiate(ballPrefab,ballPrefab.transform.position, Quaternion.identity) as GameObject;
    }
}
