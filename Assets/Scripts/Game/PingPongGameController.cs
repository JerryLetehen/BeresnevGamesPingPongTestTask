using PingPong.Core.Providers;
using PingPong.Datas;
using PingPong.Game;
using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong
{
    public class PingPongGameController : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private PingPongGameField gameField;
        [SerializeField] private PingPongBallBehavior ballBehavior;
        [SerializeField] private PingPongBallKicker ballKicker;
        [SerializeField] private PadBehavior[] pads;
        [SerializeField] private UpdateProvider updateProvider;
        [SerializeField] private TouchListener touchListener;

        private IProvidersContainer providersContainer = new ProvidersContainer();
        private IGame game;

        private void Start()
        {
            providersContainer.AddProvider(updateProvider as IUpdateProvider);

            gameField.Init(providersContainer);

            game = new PingPongGame().Init(new PingPongGameData(gameField.Gates, ballBehavior, gameField.FieldInfo, ballKicker));
            game.Start();

            InitPads();

            InitTouchListener();
        }

        private void InitPads()
        {
            foreach (var pad in pads)
            {
                pad.Init(providersContainer);
            }
        }

        private void InitTouchListener()
        {
            var padMovers = new PadMover[pads.Length];
            float scaleFactor = canvas.scaleFactor;
            padMovers[0] = new PlayerPadMover(pads[0], scaleFactor);
            padMovers[1] = new EnemyPadMover(pads[1], scaleFactor);
            touchListener.Init(padMovers);
        }
    }
    
    // TODO: 
}