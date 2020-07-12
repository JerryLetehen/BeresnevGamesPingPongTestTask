using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public class PlayerPadMover : PadMover
    {
        public PlayerPadMover(PadBehavior pad, float scaleFactor) : base(pad, scaleFactor)
        {
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (eventData.pressPosition.y <= Screen.height / 2f)
            {
                var delta = eventData.delta / scaleFactor;
                MovePad(delta.x);
            }
        }
    }
}