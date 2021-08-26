using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public Text Gold_Text;


    public int level;

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerManager playerManager = GetComponent<playerManager>();
        Gold_Text.text = string.Format("{0:n0}", playerManager.Gold_check);
    }
}
