using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanelController : MonoBehaviour
{
    public Image headImage;
    public Text headName;
    public Text dialogText;

    public Sprite[] headImages;
    public string[] headNames;
    public string[] dialogTexts;

    public bool isDialogState = false;

    public int dialogPosition = 0;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */


    // Update is called once per frame
    void Update()
    {
        if (isDialogState && Input.GetKeyDown(KeyCode.E))
        {
            headImage.sprite = headImages[dialogPosition];
            headName.text = headNames[dialogPosition];
            dialogText.text = dialogTexts[dialogPosition];
            dialogPosition++;
           
        }
    }


}
