using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataManager : MonoBehaviour {
    
    [Header("MAP SETTINGS")]
    [Tooltip("X coordinates.")] [SerializeField] private Vector2Int MapLength;
    [Tooltip("Y coordinates.")] [SerializeField] private Vector2Int MapHeight;

    public static Vector2Int Lenght;
    public static Vector2Int Height;
    public static Vector2Int Base;

    [Tooltip(
        "True will make map in a square. False will constraint room's coordinate as int and will shift room out of the initial square.")]
    [SerializeField]
    private bool SquareTheMap;

    [Header("SPRITE")] [SerializeField] private GameObject _squarePrefab;
    
    
    public static List<Point> PointList = new List<Point>();

    private bool isTriangulated;

    //Split and selection
    public void GenerateMap()
    {
        Lenght = new Vector2Int(MapLength.y * 2, MapLength.x);
        Height = MapHeight * 2;
        Base = new Vector2Int(MapLength.x, MapHeight.x);
        Origin origin = new Origin(MapLength, MapHeight);
        origin.Split();
        foreach (Node leaf in Node.Leafs) {
            leaf.Split();
            DisplayRooms(leaf);
        }
        DelaunayTriangulation();
    }

    public void DelaunayTriangulation() {
        Delaunay.BowyerWatson(PointList);
        isTriangulated = true;
        Delaunay.Kruskal(PointList);
    }

    private void OnDrawGizmos() {
        if(!isTriangulated) return;
        Gizmos.color = Color.blue;
        foreach (var triangle in Delaunay.Triangulation) {
            foreach (var halfEdge in triangle.HalfEdges) {
                Gizmos.DrawLine(new Vector3(halfEdge.A.X, halfEdge.A.Y, 0), new Vector3(halfEdge.B.X, halfEdge.B.Y, 0)); 
            }
        }
        isTriangulated = false;
    }

    public void DisplayRooms(Node room) {
        GameObject instance = Instantiate(_squarePrefab);
        instance.transform.position = !SquareTheMap ? new Vector3((room.abscissa.x + room.abscissa.y) / 2, (room.ordinate.x + room.ordinate.y) / 2, 0) : new Vector3((room.abscissa.x + room.abscissa.y) / 2f, (room.ordinate.x + room.ordinate.y) / 2f, 0);
        instance.transform.localScale = new Vector3(room.abscissa.y - room.abscissa.x, room.ordinate.y - room.ordinate.x, 1);
        instance.name = room.abscissa + " " + room.ordinate;
        SpriteRenderer spriteRenderer = instance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV();
    }
}