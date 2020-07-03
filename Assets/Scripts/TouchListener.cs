using UnityEngine;
using UnityEngine.EventSystems;

public class TouchListener : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private PadBehavior myPad;
    [SerializeField] private PadBehavior enemyPad;

    public void OnDrag(PointerEventData eventData)
    {

        if (eventData.pressPosition.y > Screen.height / 2f)
        {
            // enemy
            var delta = eventData.delta / canvas.scaleFactor;
            enemyPad.Move(delta.x);
        }
        else
        {
            // my
            var delta = eventData.delta / canvas.scaleFactor;
            myPad.Move(delta.x);
        }
    }
}