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
        // Formula source : https://en.wikipedia.org/wiki/Circumscribed_circle#Circumcenter_coordinates
        int D = 2 * (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y));
        if (D == 0) D++;
        Center.x = ((Square(A.X) + Square(A.Y)) * (B.Y - C.Y) + (Square(B.X) + Square(B.Y)) * (C.Y - A.Y) + (Square(C.X) + Square(C.Y)) * (A.Y - B.Y)) / D;
        Center.y = ((Square(A.X) + Square(A.Y)) * (C.X - B.X) + (Square(B.X) + Square(B.Y)) * (A.X - C.X) + (Square(C.X) + Square(C.Y)) * (B.X - A.X)) / D;

        Circle = new Circle(Center, Vector2Int.Distance(Center, A.Coordinates));
    }

    public static int Square(int x) {
        return x * x;
    }

    public IEnumerable<HalfEdge> CompareHalfEdge(Triangle triangle) {
        foreach (var halfEdge in triangle.HalfEdges) {
            foreach (var myHalfEdge in HalfEdges) {
                if (halfEdge.A != myHalfEdge.A || halfEdge.B != myHalfEdge.A && halfEdge.A != myHalfEdge.B ||
                    halfEdge.B != myHalfEdge.B) yield return halfEdge;
            }
        }
    }

}