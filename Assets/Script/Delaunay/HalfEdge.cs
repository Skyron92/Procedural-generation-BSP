using System.Collections.Generic;
using UnityEngine;

public class HalfEdge {
    
    public Vector2Int[] Vertices = new Vector2Int[2];
    public Vector2Int Edge => new Vector2Int(B.X - A.X, B.Y - A.Y);
    public Vector2Int OppositeEdge => new Vector2Int(A.X - B.X, A.Y - B.Y);
    public List<Triangle> Triangles = new List<Triangle>();
    public int Weight => Mathf.FloorToInt(Mathf.Sqrt(Triangle.Square(Edge.x) + Triangle.Square(Edge.y)));
    public Point A;
    public Point B;

    public HalfEdge(Triangle triangle, Point VertexOrigin, Point VertexDestination) {
        Triangles.Add(triangle);
        A = VertexOrigin;
        B = VertexDestination;
    }
}