using System.Collections.Generic;
using UnityEngine;

public class Triangle
{
    public Triangle(Point a, Point b, Point c)
    {
        Vertices[0] = a;
        Vertices[1] = b;
        Vertices[2] = c;
    }
    
    public Point A => Vertices[0];
    public Point B => Vertices[1];
    public Point C => Vertices[2];

    public Point[] Vertices = new Point[3];
    
    // Order of HalfEdges is always A -> B -> C
    public HalfEdge[] HalfEdges = new HalfEdge[3];
    public Vector2Int Center;
    public Circle Circle;

    public void SetHalfEdges() {
        // A to B
        HalfEdges[0] = new HalfEdge(A, B);
        // B to C
        HalfEdges[1] = new HalfEdge(B, C);
        // C to D
        HalfEdges[2] = new HalfEdge(C, A);
    }

    public void Circumcenter() {
        Center.x = (A.X + B.X + C.X) / 3;
        Center.y = (A.Y + B.Y + C.Y) / 3;

        Circle = new Circle(Center, Vector2Int.Distance(Center, A.Coordinates));
    }

    public static int Square(int x) {
        return x * x;
    }

    public bool IsTheSameTriangle(Triangle triangle) {
        return (A == triangle.A && (B == triangle.B && C == triangle.C) || (B == triangle.C && C == triangle.B)) || ((A == triangle.B) && (B == triangle.A && C == triangle.C) || (B == triangle.C && C == triangle.A)) || (A == triangle.C&& (B == triangle.A && C == triangle.B) || (B == triangle.B && C == triangle.A));
    }

}