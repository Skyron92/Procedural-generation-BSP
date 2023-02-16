using System.Collections.Generic;
using UnityEngine;

public abstract class Node {
    public Vector2Int[] Square = new Vector2Int[2];
    public static List<Node> Leafs = new List<Node>();
    public static List<Node> AllNodes = new List<Node>();
    public Vector2Int abscissa => Square[0];
    public Vector2Int ordinate => Square[1];
    public int SplitValue;
    protected int MinimumSize = 2;
    public bool SplitOnAbsissa;

    public Node() {
        AllNodes.Add(this);
    }

    public abstract void Split();
}