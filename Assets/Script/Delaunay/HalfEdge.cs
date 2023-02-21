using System.Collections.Generic;
using UnityEngine;

public class HalfEdge {
    
    public int Weight => Mathf.FloorToInt(Mathf.Sqrt(Triangle.Square(B.X - A.X) + Triangle.Square(B.Y - A.Y)));
    public Point A;
    public Point B;

    public HalfEdge(Point VertexOrigin, Point VertexDestination) {
        A = VertexOrigin;
        B = VertexDestination;
    }
}