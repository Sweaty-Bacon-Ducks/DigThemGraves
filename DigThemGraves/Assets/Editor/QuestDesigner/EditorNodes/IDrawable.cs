using UnityEngine;

public interface IDrawable
{
    Rect DrawingSpace { get; set; }
    void Draw();
}