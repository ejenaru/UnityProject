using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelDos : MonoBehaviour
{

    public DialogManagement dialogManagement;
    public DialogScriptable dialog;
    public GameObject dialogPrefab;


    private void Start()
    {
        dialogPrefab.SetActive(false);
        StartCoroutine(LoadDialog());
    }

    public void NextScene()
    {
        if (dialogManagement.dialogIndex == dialog.dialogText.Length)
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator LoadDialog()
    {
        yield return new WaitForSeconds(3);
        dialogPrefab.SetActive(true);
    }
}
