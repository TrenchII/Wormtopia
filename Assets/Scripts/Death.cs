
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float delay;
    public static bool dead;
    private float alpha;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        alpha = 0;
        timer = 0;
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
    }


    void Update()
    {
        if(dead) {
            float curAlpha = gameObject.GetComponent<CanvasRenderer>().GetAlpha();
            if(curAlpha != (float)255)
            {
                if(timer >= delay) {
                alpha += ((Time.deltaTime * fadeSpeed));
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0,alpha, fadeSpeed));
                }
                else {
                    timer += Time.deltaTime;
                }
            }
        }
    }
}
