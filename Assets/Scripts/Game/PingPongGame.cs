using System;
using PingPong.Game.Interfaces;

namespace PingPong.Game
{
    public class PingPongGame : IGame
    {
        private IGameData gameData;
        private IBallSettings ballSettings;

        public IGame Init(IGameData data)
        {
            gameData = data;
            ballSettings = new BallSettings(data.GameFieldInfo.BallStartPosition);
            SubscribeToGates();
            return this;
        }

        public IGame Start()
        {
            KickBallFromStartPosition();
            return this;
        }

        private void SubscribeToGates()
        {
            SubscribeToGate(gameData.Gates.Item1, OnGoalHandler);
            SubscribeToGate(gameData.Gates.Item2, OnGoalHandler);
        }

        private void OnGoalHandler()
        {
            KickBallFromStartPosition();
        }

        private void KickBallFromStartPosition()
        {
            gameData.BallKicker.KickBall(gameData.Ball.Place(ballSettings));
        }

        private void SubscribeToGate(IGate gate, Action callback)
        {
            gate.OnConcedeGoal += callback;
        }
    }
}