using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public class PlayerPadMover : PadMover
    {
        public PlayerPadMover(PadBehavior pad, Canvas canvas) : base(pad, canvas)
        {
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (eventData.pressPosition.y <= Screen.height / 2f)
            {
                var delta = eventData.delta / canvas.scaleFactor;
                MovePad(delta.x);
            }
        }
    }
}