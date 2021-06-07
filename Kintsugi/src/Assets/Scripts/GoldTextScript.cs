using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldTextScript : MonoBehaviour
{
    Text text;
    public static int goldAmount;
    public Stats stats;
    void Start()
    {
        text = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stats.currentGold.ToString();
    }
}
