using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class Delaunay
{

    public static List<Point> PointList = new List<Point>();
    public static List<HalfEdge> Edges = new List<HalfEdge>();
    public static List<Triangle> Triangulation = new List<Triangle>();

    // Link to the algorithm : https://en.wikipedia.org/wiki/Bowyer%E2%80%93Watson_algorithm
    public static void BowyerWatson(List<Point> pointList)
    {
        Triangulation.Clear();
        Triangle SuperTriangle = new Triangle(new Point(DataManager.Lenght), new Point(DataManager.Base), new Point(DataManager.Height));
        Triangulation.Add(SuperTriangle);
        foreach (Point point in PointList)
        {
            List<Triangle> badTriangles = new List<Triangle>();
            foreach (Triangle triangles in Triangulation)
            {
                triangles.Circumcenter();
                if (Vector2Int.Distance(triangles.Center, point.Coordinates) < triangles.Circle.Ray)
                {
                    badTriangles.Add(triangles);
                }
            }

            List<HalfEdge> polygon = new List<HalfEdge>();
            foreach (Triangle triangles in badTriangles)
            {
                triangles.SetHalfEdges();
                foreach (HalfEdge halfEdge in triangles.HalfEdges)
                {
                    foreach (var tr in badTriangles)
                    {
                        foreach (var he in tr.HalfEdges)
                        {
                            if (halfEdge.Edge == he.Edge || halfEdge.OppositeEdge == he.Edge) polygon.Add(halfEdge);
                        }
                    }
                }
            }

            foreach (Triangle triangles in badTriangles)
            {
                Triangulation.Remove(triangles);
            }

            foreach (HalfEdge halfEdge in polygon)
            {
                Triangle newTri = new Triangle(halfEdge.A, halfEdge.B, point);
                Triangulation.Add(newTri);
            }

            foreach (Triangle triangles in Triangulation.ToList())
            {
                triangles.SetHalfEdges();
                foreach (Point vertex in triangles.Vertices)
                {
                    if (vertex == SuperTriangle.A || vertex == SuperTriangle.B || vertex == SuperTriangle.C)
                        Triangulation.Remove(triangles);
                }

                foreach (HalfEdge halfEdge in triangles.HalfEdges) {
                    if (Edges.Contains(halfEdge))continue;
                    Edges.Add(halfEdge);
                }
            }
        }

    }

    public static List<HalfEdge> Kruskal(List<Point> G) {
        List<HalfEdge> A = new List<HalfEdge>();
        foreach (Point V in G) {
            MakeSet(V);
            ClassifyByGrowingOrder(Edges);
            foreach (HalfEdge halfEdge in Edges) {
                if(halfEdge.A == V || halfEdge.B != V) continue;
                if (Find(halfEdge.A) != Find(V)) {
                    A.Add(halfEdge);
                    Union(halfEdge.A, V);
                }
            }
        }

        foreach (var VARIABLE in A) {
            Debug.Log("Edge : " + VARIABLE.A.Coordinates + " " + VARIABLE.B.Coordinates + " has been created");
        }
        return A;
    }

    private static void Union(Point u, Point v) {
        u.Root = Find(u);
        v.Root = Find(v);
        if (u.Root != v.Root) {
            if (u.Root.Rank < v.Root.Rank) {
                u.Root.parent = v.Root;
            }
            else {
                v.Root.parent = u.Root;
                if (u.Root.Rank == v.Root.Rank) {
                    u.Root.Rank++;
                }
            }
        }
    }

    private static Point Find(Point v) {
        if (v.parent != v) {
            v.parent = Find(v.parent);
        }
        return v.parent;
        
    }

    private static void MakeSet(Point v) {
        v.parent = v;
        v.Rank = 0;
    }

    private static void ClassifyByGrowingOrder(List<HalfEdge> list) {
        list = new List<HalfEdge>(list.OrderBy(edge => edge.Weight));
    }
}