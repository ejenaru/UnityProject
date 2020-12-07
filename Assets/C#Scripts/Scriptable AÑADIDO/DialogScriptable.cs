using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogScriptable : ScriptableObject
{
    public Sprite characterFace;
    public string characterName;
    [TextArea(3,5)]
    public string[] dialogText;
}
