using UnityEngine;

public class Leaf : Node
{
    private Triangle ABC = new Triangle();
    private Triangle BDC = new Triangle();

    /* A B C and D correspond to the vertices
        A = Top left
        B = Bottom left
        C = Top right
        D = Bottom right
    
    Leaf's splitting correspond to create the two triangles compounding itself.*/
    public override void Split()
    {
        //ABC triangles*
        // A
        ABC.vertices[0] = new Vector2Int(abscissa.x, ordinate.y);
        // B
        ABC.vertices[1] = new Vector2Int(abscissa.x, ordinate.x);
        // C
        ABC.vertices[2] = new Vector2Int(abscissa.y, ordinate.y);
        
        //BDC triangles
        // B
        BDC.vertices[0] = new Vector2Int(abscissa.x, ordinate.x);
        // D
        BDC.vertices[1] = new Vector2Int(abscissa.y, ordinate.x);
        // C
        BDC.vertices[2] = new Vector2Int(abscissa.y, ordinate.y);
    }

    
}