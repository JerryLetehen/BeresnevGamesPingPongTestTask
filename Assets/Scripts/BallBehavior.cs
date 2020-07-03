using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Vector3 startVelocity;
    public Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        rb.velocity = startVelocity;
    }

    public void Restart()
    {
        transform.position = startPos;
        rb.velocity = startVelocity;
    }
}