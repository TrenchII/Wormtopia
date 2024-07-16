using UnityEngine;
using TMPro;
public class AppleCount : MonoBehaviour
{
public static int count = 0;
public TextMeshProUGUI mainText;   
    void Start() {
        mainText.text ="x " + count;
    }
    public void countUp() {
        count++;
        mainText.text ="x " + count;
    }
}
