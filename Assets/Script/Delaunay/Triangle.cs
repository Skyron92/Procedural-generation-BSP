using UnityEngine;

public class Triangle
{
    public Triangle(Vector2Int a, Vector2Int b, Vector2Int c)
    {
        vertices[0] = a;
        vertices[1] = b;
        vertices[2] = c;
    }
    public Vector2Int[] vertices = new Vector2Int[3];

    public Vector2Int A => vertices[0];
    public Vector2Int B => vertices[1];
    public Vector2Int C => vertices[2];
    // Order of HalfEdges is always A -> B -> C
    public HalfEdge[] HalfEdges = new HalfEdge[3];
    public Vector2Int Center;
    public Circle Circle;

    public void SetHalfEdges() {
        // A to B
        HalfEdges[0] = new HalfEdge(this, A, B);
        // B to C
        HalfEdges[1] = new HalfEdge(this, B, C);
        // C to D
        HalfEdges[2] = new HalfEdge(this, C, A);
    }

    public void Circumcenter() {
        // Formula source : https://en.wikipedia.org/wiki/Circumscribed_circle#Circumcenter_coordinates
        int D = 2 * (A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y));
        Center.x = ((Square(A.x) + Square(A.y)) * (B.y - C.y) + (Square(B.x) + Square(B.y)) * (C.y - A.y) + (Square(C.x) + Square(C.y)) * (A.y - B.y)) / D;
        Center.y = ((Square(A.x) + Square(A.y)) * (C.x - B.x) + (Square(B.x) + Square(B.y)) * (A.x - C.x) + (Square(C.x) + Square(C.y)) * (B.x - A.x)) / D;

        Circle = new Circle(Center, Vector2Int.Distance(Center, A));
    }

    public int Square(int x) {
        return x * x;
    }
    
}