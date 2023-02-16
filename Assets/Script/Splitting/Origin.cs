using UnityEngine;

public class Origin : Node {
    public Origin(Vector2Int absissa, Vector2Int ordinate) {
        Square[0] = absissa;
        Square[1] = ordinate;
    }

    private System.Random _randomValue = new System.Random();
    public Node[] Children = new Node[2];

    public override void Split() {
        //SplitValue = Random.Range(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
        SplitValue = _randomValue.Next(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
        Node A = new Child(this);
        Node B = new Child(this);
        A.Square[0] = new Vector2Int(abscissa.x, SplitValue);
        A.Square[1] = ordinate;
        B.Square[0] = new Vector2Int(SplitValue, abscissa.y);
        B.Square[1] = ordinate;
        Children = new []{ A, B };
        foreach (Node child in Children) {
            child.Split();
        }
    }
}