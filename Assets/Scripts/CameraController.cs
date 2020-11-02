using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public Player player;
    public Vector3 cameraDistanceOffset;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + cameraDistanceOffset.x, 0, player.transform.position.z + cameraDistanceOffset.z);
    }
}
