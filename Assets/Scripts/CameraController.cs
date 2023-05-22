using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 position;

    private void Awake()
    {
        if(!player)
            player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        position = player.position;
        position.z = -10f;
        Vector3 cameraPosition = Player.Instance.isFlipped ? position + new Vector3(-1,3,0) : position + new Vector3(1,3,0);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * 5);
    }
}
