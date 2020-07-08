using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public abstract class PadMover
    {
        protected Canvas canvas;
        private PadBehavior pad;

        public PadMover(PadBehavior pad, Canvas canvas)
        {
            this.pad = pad;
            this.canvas = canvas;
        }

        public abstract void OnDrag(PointerEventData eventData);

        protected void MovePad(float delta)
        {
            pad.Move(delta);
        }
    }
}