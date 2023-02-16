using UnityEngine;

public class HalfEdge {
    
    public Vector2[] Vertices = new Vector2[2];
    public Vector2 Edge => new Vector2(Vertices[1].x - Vertices[0].x, Vertices[1].y - Vertices[0].y);
    public Vector2 Middle => new Vector2(Edge.x / 2, Edge.y / 2);
    public Triangle Triangle;

    public HalfEdge(Triangle triangle, Vector2 VertexOrigin, Vector2 VertexDestination) {
        Triangle = triangle;
        Vertices[0] = VertexOrigin;
        Vertices[1] = VertexDestination;
    }
}