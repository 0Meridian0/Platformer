using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeedControl = 3f;

    private void Update()
    {
        Vector3 position = player.position;
        position.z = -10f;

        //TODO: Убрать магические числа
        
        Vector3 cameraPosition = Player.Initiate.isSpriteFlipped ?
                                 position + new Vector3(-2, 0, 0) :
                                 position + new Vector3(2, 0, 0);

        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * cameraSpeedControl);
    }
}
