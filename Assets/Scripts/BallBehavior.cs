using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startPower = 5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Restart();
    }

    public void Restart()
    {
        transform.position = startPos;
        rb.velocity = GetRandomVelocity();
    }

    private Vector3 GetRandomVelocity()
    {
        var result = Vector3.zero;
        while (result.Equals(Vector3.zero) || result.Equals(Vector3.right) || result.Equals(Vector3.left) || result.Equals(Vector3.up) || result.Equals(Vector3.down))
        {
            result = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f);
        }

        return result.normalized * startPower;
    }
}