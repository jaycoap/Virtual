using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ButtonEvent : MonoBehaviour
{

    TowerSpawner tower;
    Button Buildbutton;

    // Start is called before the first frame update
    void Start()
    {
        Buildbutton = this.transform.GetComponent<Button>();
        Buildbutton.onClick.AddListener(Onclick);
        tower = GetComponent<TowerSpawner>();
    }

    // Update is called once per frame
    void Onclick()
    {
        
    }
}
