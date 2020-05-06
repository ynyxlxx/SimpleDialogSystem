using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesPanelUI : MonoBehaviour {
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;

    public Conversation pressButtonA;
    public Conversation pressButtonB;
    public Conversation pressButtonC;

    public void SetButtons(string textForA, string textForB, string textForC) {
        buttonA.GetComponentInChildren<Text>().text = textForA;
        buttonB.GetComponentInChildren<Text>().text = textForB;
        buttonC.GetComponentInChildren<Text>().text = textForC;
    }

    public void ShowChoicesPanel() {
        gameObject.SetActive(true);
    }

    public void HideChoicesPanel() {
        gameObject.SetActive(false);
    }
    
}
