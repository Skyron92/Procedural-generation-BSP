using UnityEngine;

public class DataManager : MonoBehaviour {
    
    [Header("MAP SETTINGS")]
    [Tooltip("X coordinates.")] [SerializeField] private Vector2Int MapLength;
    [Tooltip("Y coordinates.")] [SerializeField] private Vector2Int MapHeight;

    [Tooltip(
        "True will make map in a square. False will constraint room's coordinate as int and will shift room out of the initial square.")]
    [SerializeField]
    private bool SquareTheMap;

    [Header("SPRITE")] [SerializeField] private GameObject _squarePrefab;

    public void Test() {
        Origin origin = new Origin(MapLength, MapHeight);
        origin.Split();

        foreach (Node leaf in Node.Rooms) {
            DisplayRooms(leaf);
        }
    }

    public void DisplayRooms(Node room) {
        GameObject instance = Instantiate(_squarePrefab);
        if(!SquareTheMap) instance.transform.position = new Vector3((room.abscissa.x + room.abscissa.y) / 2, (room.ordinate.x + room.ordinate.y) / 2, 0);
        else instance.transform.position = new Vector3((room.abscissa.x + room.abscissa.y) / 2f, (room.ordinate.x + room.ordinate.y) / 2f, 0);
        instance.transform.localScale = new Vector3(room.abscissa.y - room.abscissa.x, room.ordinate.y - room.ordinate.x, 1);
        instance.name = room.abscissa + " " + room.ordinate;
        SpriteRenderer spriteRenderer = instance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV();
    }
}