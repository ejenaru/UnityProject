using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    //public Canvas dialogFather;
    private Transform myCanvas;
    public GameObject[] dialogs;
    private int dialogIndex;

    private void Awake()
    {
        myCanvas = GetComponent<Transform>(); // GetComponent<Canvas>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateDialog();
        }       
    }




    public void UpdateDialog()
    {
        GameObject tempDialog = Instantiate(dialogs[dialogIndex], myCanvas) as GameObject;
        dialogIndex++;
    }


}
