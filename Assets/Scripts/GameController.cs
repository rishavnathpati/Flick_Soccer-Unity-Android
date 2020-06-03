﻿using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    float ballForce;

    GameObject ballInstance;
    Vector3 mouseStart;
    Vector3 mouseEnd;

    float minDragDistance = 15f;
    //float zDepth = 15f;

    void Awake()
    {

    }


    // Use this for initialization
    void Start()
    {
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseEnd = Input.mousePosition;

            if (Vector3.Distance(mouseEnd, mouseStart) > minDragDistance)
            {
                //throw ball

                Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Random.Range(10f,20f));

                hitPos = Camera.main.ScreenToWorldPoint(hitPos);

                ballInstance.transform.LookAt(hitPos);

                ballInstance.GetComponent<Rigidbody>().AddRelativeForce(ballInstance.transform.forward * ballForce, ForceMode.Impulse);

                Invoke("CreateBall", 2f);
            }
        }
    }

    void CreateBall()
    {

        ballInstance = Instantiate(ballPrefab, ballPrefab.transform.position, Quaternion.identity) as GameObject;
    }
}
