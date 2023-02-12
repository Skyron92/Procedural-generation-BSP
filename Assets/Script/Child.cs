using UnityEngine;

public class Child : Node
{
    public Node Parent;
    public Node[] Children = new Node[2];
    private System.Random _randomValue = new System.Random();
    

    public Child(Node parent) {
        Parent = parent;
    }
    public override void Split() {
        Node A;
        Node B;
        if (!SplitOnAbsissa) {
            if(ordinate.x + MinimumSize > ordinate.y - MinimumSize) return;
            //SplitValue = Random.Range(ordinate.x + MinimumSize, ordinate.y - MinimumSize);
            SplitValue = _randomValue.Next(ordinate.x + MinimumSize, ordinate.y - MinimumSize);
            if (SplitValue - ordinate.x > MinimumSize) A = new Child(this);
            else {
                A = new Leaf();
                Rooms.Add(A);
            }
            if (ordinate.y - SplitValue > MinimumSize) B = new Child(this);
            else {
                B = new Leaf();
                Rooms.Add(B);
            }
            A.Square[0] = abscissa;
            A.Square[1] = new Vector2Int(ordinate.x, SplitValue);
            B.Square[0] = abscissa;
            B.Square[1] = new Vector2Int(SplitValue, ordinate.y);
        }
        else {
            if(abscissa.x + MinimumSize > abscissa.y - MinimumSize) return;
            //SplitValue = Random.Range(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
            SplitValue = _randomValue.Next(abscissa.x + MinimumSize, abscissa.y - MinimumSize);
            if (SplitValue - abscissa.x > MinimumSize) A = new Child(this);
            else {
                A = new Leaf();
                Rooms.Add(A);
            }
            if (abscissa.y - SplitValue > MinimumSize) B = new Child(this);
            else {
                B = new Leaf();
                Rooms.Add(B);
            }
            A.Square[0] = new Vector2Int(abscissa.x, SplitValue);
            A.Square[1] = ordinate;
            B.Square[0] = new Vector2Int(SplitValue, abscissa.y);
            B.Square[1] = ordinate;
        }
        Children = new[] { A, B };
        Debug.Log(abscissa  + " " + ordinate + " has been split to " + SplitValue);
        foreach (Node child in Children) {
            if (child.GetType() == typeof(Leaf)) {
                Debug.Log(child.abscissa + " " + child.ordinate + " is a LEAF");
                continue;
            }
            child.SplitOnAbsissa = !SplitOnAbsissa;
            child.Split();
        }
    }

}