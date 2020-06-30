using UnityEngine;

public interface IDrawable
{
    Rect DrawingSpace { get; }
    void Draw();
}