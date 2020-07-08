using UnityEngine;

namespace PingPong
{
    public class VerticalWall : WallBase
    {
        protected override void SetSize(Vector2 areaSize)
        {
            boxCollider.size = new Vector2(boxCollider.size.x, areaSize.y);
        }
    }
}