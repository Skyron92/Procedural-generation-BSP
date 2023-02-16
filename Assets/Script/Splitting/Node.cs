using System.Collections.Generic;
using UnityEngine;

public abstract class Node {
    public Vector2Int[] Square = new Vector2Int[2];
    public static List<Node> Rooms = new List<Node>();
    public Vector2Int abscissa => Square[0];
    public Vector2Int ordinate => Square[1];
    public int SplitValue;
    protected int MinimumSize = 2;
    public bool SplitOnAbsissa;

    public abstract void Split();
}