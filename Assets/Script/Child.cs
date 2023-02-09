using UnityEngine;

public class Child : Node
{
    public Node Parent;
    public Node[] Children = new Node[2];
    

    public Child(Node parent) {
        Parent = parent;
    }
    public override void Split() {
        Node A;
        Node B;
        if (!SplitOnAbsissa) {
            SplitValue = Random.Range(ordinate.x + MinimumSize, ordinate.y - MinimumSize);
            if (SplitValue - ordinate.x > MinimumSize) A = new Child(this);
            else A = new Leaf();
            if (ordinate.y - SplitValue > MinimumSize) B = new Child(this);
            else B = new Leaf();
            A.Square[0] = abscissa;
            A.Square[1] = new Vector2Int(ordinate.x, SplitValue);
            B.Square[0] = abscissa;
            B.Square[1] = new Vector2Int(SplitValue, ordinate.y);
        }
        else {
            SplitValue = Random.Range(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
            if (SplitValue - abscissa.x > MinimumSize) A = new Child(this);
            else A = new Leaf();
            if (abscissa.y - SplitValue > MinimumSize) B = new Child(this);
            else B = new Leaf();
            A.Square[0] = new Vector2Int(abscissa.x, SplitValue);
            A.Square[1] = ordinate;
            B.Square[0] = new Vector2Int(SplitValue, abscissa.y);
            B.Square[1] = ordinate;
        }
        Children = new[] { A, B };
        Debug.Log("I'm a child of " + Parent + " and my coordinates are " + abscissa + " on X and " + ordinate + " on Y.");
        Debug.Log("My children's coordinates are " + A.abscissa + " on X and " + A.ordinate + " on Y for the first one, and " + B.abscissa + " on X and " + B.ordinate + " for the second.");
        foreach (Node child in Children) {
            if(child.GetType() == typeof(Leaf)) continue;
            child.SplitOnAbsissa = !SplitOnAbsissa;
            child.Split();
        }
    }

}