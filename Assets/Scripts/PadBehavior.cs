using System;
using UnityEngine;

public class PadBehavior : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform area;

    private float minX;
    private float maxX;
    private Vector3[] padCorners = new Vector3[4];
    private float halfWidth;
    private Transform tr;

    private void Start()
    {
        tr = rectTransform.transform;
        var areaCorners = new Vector3[4];
        area.GetWorldCorners(areaCorners);
        minX = areaCorners[0].x;
        maxX = areaCorners[3].x;
        rectTransform.GetWorldCorners(padCorners);
        halfWidth = (padCorners[3].x - padCorners[0].x) / 2f;
    }

    public void Move(float xDelta)
    {
        var newPos = rectTransform.anchoredPosition;
        newPos.x += xDelta;
        rectTransform.anchoredPosition = newPos;
    }

    private void LateUpdate()
    {
        rectTransform.GetWorldCorners(padCorners);
        var currentPos = tr.position;
        if (padCorners[0].x < minX)
        {
            tr.position = new Vector3(minX + halfWidth, currentPos.y, currentPos.z);
        }
        else if (padCorners[3].x > maxX)
        {
            tr.position = new Vector3(maxX - halfWidth, currentPos.y, currentPos.z);
        }
    }
}