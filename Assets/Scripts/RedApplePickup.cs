using UnityEngine;

public class ApplePickup : MonoBehaviour
{
    [SerializeField] public float increase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        if(playerScript) {
            playerScript.speed += increase;
            gameObject.GetComponent<AppleCount>().countUp();
            Destroy(gameObject);
        }

    }
}
