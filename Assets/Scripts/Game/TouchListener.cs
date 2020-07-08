using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public class TouchListener : MonoBehaviour, IDragHandler
    {
        private PadMover[] padMovers;

        public void Init(PadMover[] padMovers)
        {
            this.padMovers = padMovers;
        }

        public void OnDrag(PointerEventData eventData)
        {
            foreach (var padMover in padMovers)
            {
                padMover.OnDrag(eventData);
            }
        }
    }
}