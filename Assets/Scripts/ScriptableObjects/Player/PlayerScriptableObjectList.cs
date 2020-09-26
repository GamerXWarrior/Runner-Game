using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObjectList", menuName = "ScriptableObject/PlayerScriptableObjectList")]
public class PlayerScriptableObjectList : ScriptableObject
{
    public PlayerScriptableObject[] playerScriptableObject;
}
