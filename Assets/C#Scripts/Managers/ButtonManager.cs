using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void RestartButton()
    {
        GameManager.manager.RestartFromSavePoint();
    }
}
