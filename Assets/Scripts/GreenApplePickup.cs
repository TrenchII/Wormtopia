using UnityEngine;
public class GreenApplePickup : MonoBehaviour
{
    [SerializeField] public float increase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();

        if(playerScript) {
            playerScript.jheight += increase;
            gameObject.GetComponent<AppleCount>().countUp();
            Destroy(gameObject);
        }

    }
}
