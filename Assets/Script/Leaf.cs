using UnityEngine;

public class Leaf : Node {
    
    //Leaf can't split
    public override void Split() {
        Display();
    }
    

    public void Display() {
        Debug.Log("Create square");
        GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}