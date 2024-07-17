
using UnityEngine;

public class buguspatrol : MonoBehaviour
{
    [Header ("Patrol points")]
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;

    [Header ("Enemy")]
    [SerializeField] private Transform bugus;

    [Header ("Movement Params")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Awake() {
        initScale = bugus.localScale;
    }
    private void Update() {
        if (movingLeft){
            if(bugus.position.x >= left.position.x) moveDirn(-1);
            else dirnChange();
        }
        else {
            if(bugus.position.x <= right.position.x) moveDirn(1);
            else dirnChange();
        }
    }
    private void dirnChange() {
        anim.SetBool("moving",false);
        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration) {
            movingLeft = !movingLeft;
        }
    }
    private void moveDirn(int _dirn) {
        idleTimer = 0;
        anim.SetBool("moving",true);
        //turn in direction
        bugus.localScale = new Vector3(Mathf.Abs(initScale.x) * _dirn * -1, initScale.y, initScale.z);
        //move in direction
        bugus.position = new Vector3(bugus.position.x + (Time.deltaTime * _dirn *  speed), bugus.position.y, bugus.position.z);
    }
}
