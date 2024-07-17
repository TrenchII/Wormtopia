
using UnityEngine;

public class Death : MonoBehaviour
{
    public static float alpha;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
    }


    void Update()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
    }
}
