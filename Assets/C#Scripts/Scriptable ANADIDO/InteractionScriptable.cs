using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Interaction", menuName = "ObjectInteraction")]
public class InteractionScriptable : ScriptableObject
{
    [TextArea(3,5)]
    public string[] interaction;
    public Sprite characterFace;
    public string characterName;
}
