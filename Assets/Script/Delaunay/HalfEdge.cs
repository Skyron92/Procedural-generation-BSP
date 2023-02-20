using System.Collections.Generic;
using UnityEngine;

public class HalfEdge {
    
    public Vector2Int Edge => new Vector2Int(B.X - A.X, B.Y - A.Y);
    public int Weight => Mathf.FloorToInt(Mathf.Sqrt(Triangle.Square(Edge.x) + Triangle.Square(Edge.y)));
    public Point A;
    public Point B;

    public HalfEdge(Point VertexOrigin, Point VertexDestination) {
        A = VertexOrigin;
        B = VertexDestination;
    }
}