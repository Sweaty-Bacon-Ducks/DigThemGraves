using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContoller : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private string horizontalAxisName;
    [SerializeField]
    private string verticalAxisName;
    [SerializeField]
    private float acceleration;

    public float Acceleration { get => acceleration; set => acceleration = value; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis(horizontalAxisName);
        var verticalInput = Input.GetAxis(verticalAxisName);
        var inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputVector.magnitude > 0)
        {
            rb.AddForce(acceleration * (new Vector2(horizontalInput, verticalInput).normalized));
        }
        else
        {
            if (rb.velocity.magnitude >= 0.05f)
            {
                rb.AddForce(-acceleration * rb.velocity.normalized);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

    }
}
