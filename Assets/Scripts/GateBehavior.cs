using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    private Dictionary<Collider2D, BallBehavior> ballsTable = new Dictionary<Collider2D, BallBehavior>();

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.LogError("here");
        if (ballsTable.TryGetValue(other, out var ballBehavior))
        {
            ballBehavior.Restart();
        }
        else
        {
            ballBehavior = other.GetComponent<BallBehavior>();
            if (ballBehavior != null)
            {
                ballsTable.Add(other, ballBehavior);
                ballBehavior.Restart();
            }
        }
    }
}