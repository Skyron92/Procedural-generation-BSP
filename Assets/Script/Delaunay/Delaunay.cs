using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Delaunay {

    public static List<Vector2Int> PointList = new List<Vector2Int>();
    public static List<Triangle> Triangulation = new List<Triangle>();

    // Link to the algorithm : https://en.wikipedia.org/wiki/Bowyer%E2%80%93Watson_algorithm
    public static void BowyerWatson(List<Vector2Int> pointList) {
        Triangulation.Clear();
        Triangle SuperTriangle = new Triangle(DataManager.Lenght, DataManager.Base, DataManager.Height);
        Triangulation.Add(SuperTriangle);
        foreach (Vector2Int point in pointList) {
            List<Triangle> badTriangles = new List<Triangle>();
            foreach (Triangle triangles in Triangulation) {
                triangles.Circumcenter();
                if (Vector2Int.Distance(triangles.Center, point) < triangles.Circle.Ray)
                {
                    badTriangles.Add(triangles);
                }
            }

            List<HalfEdge> polygon = new List<HalfEdge>();
            foreach (Triangle triangles in badTriangles) {
                triangles.SetHalfEdges();
                foreach (HalfEdge halfEdge in triangles.HalfEdges) {
                    foreach (var tr in badTriangles) {
                        foreach (var he in tr.HalfEdges) {
                            if(halfEdge.Edge == he.Edge || halfEdge.OppositeEdge == he.Edge) polygon.Add(halfEdge);
                        }
                    }
                }
            }

            foreach (Triangle triangles in badTriangles) {
                Triangulation.Remove(triangles);
            }

            foreach (HalfEdge halfEdge in polygon) {
                Triangle newTri = new Triangle(halfEdge.Vertices[0], halfEdge.Vertices[1], point);
                Triangulation.Add(newTri);
            }
            
            foreach (Triangle triangles in Triangulation.ToList()) {
                foreach (Vector2Int vertex in triangles.vertices) {
                    if (vertex == SuperTriangle.A || vertex == SuperTriangle.B || vertex == SuperTriangle.C)
                        Triangulation.Remove(triangles);
                }
            }
        }
        
    }
}