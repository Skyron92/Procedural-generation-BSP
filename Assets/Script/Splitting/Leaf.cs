using UnityEngine;

public class Leaf : Node
{
    

    /* A B C and D correspond to the vertices
        A = Top left
        B = Bottom left
        C = Top right
        D = Bottom right
    
    Leaf's splitting correspond to create the two triangles compounding itself.*/
    public override void Split()
    {
        Triangle ABC = new Triangle(new Vector2Int(abscissa.x, ordinate.y), new Vector2Int(abscissa.x, ordinate.x), new Vector2Int(abscissa.y, ordinate.y));
        Triangle BDC = new Triangle(new Vector2Int(abscissa.x, ordinate.x),new Vector2Int(abscissa.y, ordinate.x),new Vector2Int(abscissa.y, ordinate.y));

        DataManager.Triangles.Add(ABC);
        DataManager.Triangles.Add(BDC);
    }

    
}