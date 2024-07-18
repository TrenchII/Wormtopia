
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float yOffset;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, (player.position.y + yOffset), transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead,(aheadDistance * transform.localScale.x), Time.deltaTime *cameraSpeed);
    }
}
