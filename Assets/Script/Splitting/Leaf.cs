using UnityEngine;

public class Leaf : Node
{
  
    
    //Leaf's splitting correspond to create the center of itself.
    public override void Split() {
        Point center = new Point(new Vector2Int((abscissa.x + abscissa.y)/2, (ordinate.x + ordinate.y)/2));
        DataManager.PointList.Add(center);
    }

    
}