using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ballPrefab;
    GameObject ballInstance;
    Vector3 mouseStart, mouseEnd;
    float minSwipeDistance = 15f, zDepth;
    [SerializeField]
    float ballForce;
    public Rigidbody rb;

    // Start is called before the first frame update
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
            if (Vector3.Distance(mouseEnd, mouseStart) >= minSwipeDistance)
            {
                //throw ball
                Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth);
                hitPos = Camera.main.ScreenToWorldPoint(hitPos);
                ballInstance.transform.LookAt(hitPos);
                rb.AddRelativeForce(Vector3.forward * ballForce, ForceMode.Impulse);
            }
        }
    }

    void CreateBall()
    {
        ballInstance = Instantiate(ballPrefab, ballPrefab.transform.position, Quaternion.identity) as GameObject;
    }
}
