using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedFrames : MonoBehaviour
{
    // Start is called before the first frame update
    public string fillAmount;
    public float maxAmount;

    [SerializeField]
    public Text information;
    
    public void text2(string i)
    {
        information.text = i;
    }
   public void setText(string i)
    {
        fillAmount = i;
        string Temp = fillAmount + " / " + maxAmount;
        information.text=Temp;
    }
}
