using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprite; //Crea arreglo para seleccionar los sprites

    public Image HeartUI;

    public Stats stats;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        HeartUI.sprite = HeartSprite[stats.currentHearts];
    }
}
