using UnityEngine;

public class DataManager : MonoBehaviour {
    [Tooltip("X coordinates.")] [SerializeField] private Vector2Int MapLength;
    [Tooltip("Y coordinates.")] [SerializeField] private Vector2Int MapHeight;
    public void Test() {
        Origin origin = new Origin(MapLength, MapHeight);
        origin.Split();
        
    }
}