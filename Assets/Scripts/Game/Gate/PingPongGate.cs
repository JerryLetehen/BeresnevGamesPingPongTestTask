using System;
using System.Collections.Generic;
using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong
{
    public class PingPongGate : MonoBehaviour, IGate
    {
        public event Action OnConcedeGoal;

        private Dictionary<Collider2D, PingPongBallBehavior> ballsTable = new Dictionary<Collider2D, PingPongBallBehavior>();

        private void OnTriggerExit2D(Collider2D other)
        {
            if (ballsTable.TryGetValue(other, out var ballBehavior))
            {
                InvokeConcedeGoal();
            }
            else
            {
                ballBehavior = other.GetComponent<PingPongBallBehavior>();
                if (ballBehavior != null)
                {
                    ballsTable.Add(other, ballBehavior);
                    InvokeConcedeGoal();
                }
            }
        }

        private void InvokeConcedeGoal()
        {
            OnConcedeGoal?.Invoke();
        }
    }
}