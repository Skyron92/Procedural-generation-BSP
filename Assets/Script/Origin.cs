using UnityEngine;

public class Origin : Node {
    public Origin(Vector2Int absissa, Vector2Int ordinate) {
        Square[0] = absissa;
        Square[1] = ordinate;
    }
    public Node[] Children = new Node[2];

    public override void Split() {
        SplitValue = Random.Range(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
        Node A = new Child(this);
        Node B = new Child(this);
        A.Square[0] = new Vector2Int(abscissa.x, SplitValue);
        A.Square[1] = ordinate;
        B.Square[0] = new Vector2Int(SplitValue, abscissa.y);
        B.Square[1] = ordinate;
        Children = new []{ A, B };
        Debug.Log("Origin's coordinate are " + abscissa + " for X and " + ordinate + " for Y.");
        Debug.Log("Origin has been split to " + SplitValue);
        Debug.Log(Children.Length + " children was born.");
        Debug.Log("The first one's coordinate are " + Children[0].abscissa + " for X and " + Children[0].ordinate + " for Y.");
        Debug.Log("The second one's coordinate are " + Children[1].abscissa + " for X and " + Children[1].ordinate + " for Y.");
        foreach (Node child in Children) {
            child.Split();
        }
    }
}