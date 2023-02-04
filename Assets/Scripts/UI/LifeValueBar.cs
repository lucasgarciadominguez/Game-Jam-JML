using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeValueBar : MonoBehaviour
{
    public Image barLife;
    public float lifeValueBar;
    public float lifeValueMax;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        barLife.fillAmount = lifeValueBar/lifeValueMax;
    }
}
