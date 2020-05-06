using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Dialogue System/Character")]
public class Character : ScriptableObject {
    public string fullName;
    public Sprite characterImage;
}
