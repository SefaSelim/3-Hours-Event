using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float force = 10f;

    public GameObject ball;
    private Transform balltransform;  
    private Rigidbody2D rb;

    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
        balltransform = ball.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Input.mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));

            Vector2 ballPosition = balltransform.position;

        
            Vector2 forceDirection = (ballPosition - (Vector2)mousePosition).normalized;

            rb.AddForce(forceDirection * force, ForceMode2D.Impulse);
        }
    }
}
