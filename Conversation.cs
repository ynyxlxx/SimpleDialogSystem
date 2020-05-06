using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue System/Conversation")]
public class Conversation : ScriptableObject {
    public Character characterLeft;
    public Character characterRight;
    public Section[] sections;
}

[System.Serializable]
public struct Section {
    public Character character;

    [TextArea(2, 5)]
    public string text;

    public bool isOptional;
    public string[] choices;
}
