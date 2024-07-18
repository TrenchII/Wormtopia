using UnityEngine;
public class CloudDissappear : MonoBehaviour
{
    private Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            anim.SetBool("steppedon",true);
        }
    }
    public void DestroyMe() {
        Destroy(gameObject);
    }
} 