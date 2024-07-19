 using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jheight;
    [SerializeField] public GameObject splash;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool side;
    private void Awake() {
        //Grab reference for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 1;
    }

    private void Update() {
        //Apply left-right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
        //Flip character left and right depending on movement direction
        if(horizontalInput > 0.01f) transform.localScale = new Vector3(1,1,1);
        else if (horizontalInput < -0.01f) transform.localScale = new Vector3(-1,1,1);
        //Allow character to jump
        if(Input.GetKey(KeyCode.Space) && grounded && !side) {
            Jump();
        }
        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    private void Jump() {
        body.velocity = new Vector2(body.velocity.x,jheight);
        anim.SetTrigger("jump");
        grounded=false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground")  {
        grounded = true;
        body.velocity = new Vector2(body.velocity.x,0);
        side = false;
        }
        if(collision.gameObject.tag == "bugus" || collision.gameObject.tag == "water") {
            gameObject.SetActive(false);
            if (collision.gameObject.tag == "water") {
                GameObject splashObj = Instantiate(splash,body.position,Quaternion.identity);
                Animator splashanim = splashObj.GetComponent<Animator>();
                splashanim.SetBool("water",true);
            }
            Death.dead = true;
        }
        if(collision.gameObject.tag == "side") {
            side = true;
            grounded = false;
        }
    }
}
