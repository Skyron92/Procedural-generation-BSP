using UnityEngine;

public class Origin : Node {
    public Node[] Children = new Node[2];

    public override Node[] Split() {
        SplitValue = Random.Range(abscissa.x, abscissa.y);
        Node A = new Child();
        Node B = new Child();

        A.Square[0] = new Vector2Int(abscissa.x, SplitValue);
        A.Square[1] = ordinate;

        B.Square[0] = new Vector2Int(SplitValue, abscissa.y);
        B.Square[1] = ordinate;

        Node[] childs = {A, B};
        return childs;
    }
}