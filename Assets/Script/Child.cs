using UnityEngine;

public class Child : Node
{
    public Node Parent;

    public override Node[] Split()
    {
        throw new System.NotImplementedException();
    }

}