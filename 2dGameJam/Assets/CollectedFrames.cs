using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedFrames : MonoBehaviour
{
    // Start is called before the first frame update
    public int fillAmount;
    public int maxAmount;

    [SerializeField]
    public Text information;

   public void setText(int i)
    {
        fillAmount = i;
        string Temp = fillAmount + " / " + maxAmount;
        information.text=Temp;
    }
}
