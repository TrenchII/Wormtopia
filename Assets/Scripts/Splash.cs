using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }
    public void DestroyMe() {
        if(anim.GetBool("water")) {
            Destroy(gameObject);
        }
    }
}
