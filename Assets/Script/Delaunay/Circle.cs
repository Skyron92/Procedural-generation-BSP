using System.Collections.Generic;
using UnityEngine;

public class Circle
{
    public Vector2 Center;
    public float Ray;
    public List<Vector2> Vertices;

    public Circle(Vector2 center, float ray)
    {
        Center = center;
        Ray = ray;
    }
}