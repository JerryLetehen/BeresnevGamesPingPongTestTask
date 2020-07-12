using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public abstract class PadMover
    {
        protected float scaleFactor;
        private PadBehavior pad;

        public PadMover(PadBehavior pad, float scaleFactor)
        {
            this.pad = pad;
            this.scaleFactor = scaleFactor;
        }

        public abstract void OnDrag(PointerEventData eventData);

        protected void MovePad(float delta)
        {
            pad.Move(delta);
        }
    }
}