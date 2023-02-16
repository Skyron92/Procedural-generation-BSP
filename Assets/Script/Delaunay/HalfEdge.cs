using System.Collections.Generic;
using UnityEngine;

public class HalfEdge {
    
    public Vector2Int[] Vertices = new Vector2Int[2];
    public Vector2 Edge => new Vector2(Vertices[1].x - Vertices[0].x, Vertices[1].y - Vertices[0].y);
    public Vector2 OppositeEdge => new Vector2(Vertices[0].x - Vertices[1].x, Vertices[0].y - Vertices[1].y);
    public List<Triangle> Triangles = new List<Triangle>();

    public HalfEdge(Triangle triangle, Vector2Int VertexOrigin, Vector2Int VertexDestination) {
        Triangles.Add(triangle);
        Vertices[0] = VertexOrigin;
        Vertices[1] = VertexDestination;
    }
}