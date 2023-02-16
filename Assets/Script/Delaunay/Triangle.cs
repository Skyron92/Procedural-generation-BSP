using UnityEngine;

public class Triangle
{
    public Vector2[] vertices = new Vector2[3];

    public Vector2 A => vertices[0];
    public Vector2 B => vertices[1];
    public Vector2 C => vertices[2];
    // Order of HalfEdges is always A -> B -> C
    public HalfEdge[] HalfEdges = new HalfEdge[3];
    public Vector2 Center;

    public void SetHalfEdges() {
        // A to B
        HalfEdges[0] = new HalfEdge(this, A, B);
        // B to C
        HalfEdges[1] = new HalfEdge(this, B, C);
        // C to D
        HalfEdges[2] = new HalfEdge(this, C, A);
    }

    public void SetCenter()
    {
        /*Vector2 MidAB = new Vector2(vertices[2].x - HalfEdges[0].Middle.x, vertices[2].y - HalfEdges[0].Middle.y);
        Vector2 MidBC = new Vector2(vertices[0].x - HalfEdges[1].Middle.x, vertices[0].y - HalfEdges[1].Middle.y);
        Vector2 MidCA = new Vector2(vertices[1].x - HalfEdges[2].Middle.x, vertices[1].y - HalfEdges[2].Middle.y);*/
        
        // Formula source : https://www.omnicalculator.com/math/circumcenter-of-a-triangle
        float t = Square(A.x) + Square(A.y) - Square(B.x) - Square(B.y);
        float u = Square(A.x) + Square(A.y) - Square(C.x) - Square(C.y);
        float J = (A.x - B.x) * (A.y - C.y) - (A.x - C.x) * (A.y - B.y);
        Center.x = (-(A.y - B.y) * u + (A.y - C.y) * t) / (2 * J);
        Center.y = ((A.x - B.x) * u - (A.x - C.x) * t) / (2 * J);
    }

    public float Square(float x) {
        return x + x;
    }

    public void SetCircle() {
        float r = Vector2.Distance(Center, A);
        if (r == Vector2.Distance(Center, B) && r == Vector2.Distance(Center, C)) {
            
        } 
    }

}