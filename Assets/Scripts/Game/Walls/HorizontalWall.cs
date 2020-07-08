using UnityEngine;

namespace PingPong
{
    public class HorizontalWall : WallBase
    {
        protected override void SetSize(Vector2 areaSize)
        {
            boxCollider.size = new Vector2(areaSize.x, boxCollider.size.y);
        }
    }
}