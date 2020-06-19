using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private readonly GameObject ballPrefab;

    [SerializeField]
    private readonly float ballForce;
    private readonly GameObject ballInstance;
    private Vector3 mouseStart;
    private Vector3 mouseEnd;
    private readonly float minDragDistance = 15f;

    //float zDepth = 15f;

    private void Awake()
    {

    }


    // Use this for initialization
    private void Start()
    {
        //CreateBall();
    }

    // Update is called once per frame
    private void Update()
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

                Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Random.Range(10f, 20f));

                hitPos = Camera.main.ScreenToWorldPoint(hitPos);

                ballInstance.transform.LookAt(hitPos);

                ballInstance.GetComponent<Rigidbody>().AddRelativeForce(ballInstance.transform.forward * ballForce, ForceMode.Impulse);

                Invoke("CreateBall", 2f);
            }
        }
    }
}
