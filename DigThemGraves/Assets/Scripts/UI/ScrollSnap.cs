using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using DigThemGraves;

public class ScrollSnap : MonoBehaviour
{
    public RectTransform ContainerToScroll;
    public float SwipeAcceleration;
    [Range(0.5f, 1f)]
    public float ScreenPercentageToSnap;

    private List<RectTransform> containerChildren;
    private GridLayoutGroup containerGrid;
    private float cellWidth;
    private int currentCell = 0;
    private int firstCell;
    private int lastCell;
    private float interpolationFactor = 0;
    private float currentOffset = 0f;
    private float targetOffset = 0f;
    private float oldOffset = 0f;
    private float minOffset;
    private float maxOffset;
    private Vector2 translationBuffer = Vector2.zero;
    private UserSwipe userSwipe = UserSwipe.Create();
    private InputClick userClick = InputClick.Create();
    private float changeCellToRightOffsetBoundary;
    private float changeCellToLeftOffsetBoundary;

    private void OnValidate()
    {
        ContainerToScroll.gameObject.TryGetComponent(out containerGrid);
    }

    private void Awake()
    {
        ContainerToScroll.gameObject.TryGetComponent(out containerGrid);
        containerChildren = ChildrenOf<RectTransform>(ContainerToScroll.gameObject);
    }

    private void Start()
    {
        cellWidth = containerGrid.cellSize.x;
        firstCell = 0;
        lastCell = containerChildren.Count - 1;
        minOffset = 0f;
        maxOffset = lastCell * cellWidth;
    }

    private List<T> ChildrenOf<T>(GameObject obj)
    {
        var result = new List<T>();
        foreach (T item in obj.transform)
        {
            result.Add(item);
        }
        return result;
    }

    private void Update()
    {
        changeCellToLeftOffsetBoundary = ComputeOffsetBoundary(cellWidth, currentCell - 1, ScreenPercentageToSnap);
        changeCellToRightOffsetBoundary = ComputeOffsetBoundary(cellWidth, currentCell, ScreenPercentageToSnap);
        if (userSwipe.WasSwiped)
        {
            interpolationFactor = 0;
            int direction = GetSwipeXDirection();
            float offset = SwipeAcceleration * direction;
            currentOffset += offset;
        }

        if (currentOffset >= changeCellToRightOffsetBoundary)
        {
            interpolationFactor = 0;
            currentCell++;
        }
        else if (currentOffset <= changeCellToLeftOffsetBoundary)
        {
            interpolationFactor = 0;
            currentCell--;
        }
        currentCell = SanitizeCellValue(currentCell, firstCell, lastCell);
        targetOffset = currentCell * cellWidth;

        if (!userClick.WasClicked)
        {
            interpolationFactor = Mathf.Clamp01(interpolationFactor + Time.deltaTime);
            currentOffset = Mathf.Lerp(currentOffset, targetOffset, interpolationFactor);
            interpolationFactor = interpolationFactor == 1 ? 0 : interpolationFactor;
        }

        currentOffset = SanitazeOffset(currentOffset, minOffset, maxOffset);
        translationBuffer.x = oldOffset - currentOffset;
        ContainerToScroll.anchoredPosition += translationBuffer;
        //ContainerToScroll.Translate(translationBuffer);
        oldOffset = currentOffset;
    }

    private float ComputeOffsetBoundary(float cellSize, int cellIndex, float cellPercentageToChange = 0.5f)
    {
        return cellSize * (cellIndex + cellPercentageToChange);
    }

    private int GetSwipeXDirection() { return userSwipe.Direction.x > 0 ? 1 : -1; }

    private int SanitizeCellValue(int cellIndex, int minValue, int maxValue)
    {
        return Mathf.Clamp(cellIndex, minValue, maxValue);
    }

    private float SanitazeOffset(float offset, float minValue, float maxValue)
    {
        return Mathf.Clamp(offset, minValue, maxValue);
    }
}
