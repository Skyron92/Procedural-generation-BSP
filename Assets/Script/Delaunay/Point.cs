using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Point parent;
    public Vector2Int Coordinates;
    public int Rank;
    public Point Root;

    public int X => Coordinates.x;
    public int Y => Coordinates.y;

    public Point(Vector2Int coordinates) {
        Coordinates = coordinates;
    }
}