using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    [SerializeField] private RectTransform canvas;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private bool matchWidth;

    // Update is called once per frame
    void Update()
    {
        var mySize = boxCollider.size;
        if (matchWidth)
        {
            mySize = new Vector2(canvas.rect.width, mySize.y);
        }
        else
        {
            mySize = new Vector2(mySize.x, canvas.rect.height);
        }

        boxCollider.size = mySize;
    }
}