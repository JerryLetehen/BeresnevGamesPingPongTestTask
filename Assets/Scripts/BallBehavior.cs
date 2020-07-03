using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Vector3 startVelocity;
    void Start()
    {
        rb.velocity = startVelocity;
    }
}