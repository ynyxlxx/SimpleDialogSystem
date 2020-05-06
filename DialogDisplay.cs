using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour {
    public Conversation conversation;

    public SpeakerUI speakerUILeft;
    public SpeakerUI speakerUIRight;
    public ChoicesPanelUI choicePanel;

    private bool choiceA = false;
    private bool choiceB = false;
    private bool choiceC = false;

    private int dialogIndex;

    private void Start() {
        speakerUILeft.Speaker = conversation.characterLeft;
        speakerUIRight.Speaker = conversation.characterRight;
        choicePanel.gameObject.SetActive(false);
        SetOnButtonListener();
    }

    private void OnEnable() {
        dialogIndex = 0;
        speakerUILeft.Speaker = conversation.characterLeft;
        speakerUIRight.Speaker = conversation.characterRight;
        choicePanel.gameObject.SetActive(false);

        GameInfoManager.instance.PauseTheGame();
        AdvanceConversation();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameInfoManager.instance.PauseTheGame();
            AdvanceConversation();
        }

        if (choiceA) {
            ResetAllTheFlag();
            StartNewConversation(choicePanel.pressButtonA);
        }else if (choiceB) {
            ResetAllTheFlag();
            StartNewConversation(choicePanel.pressButtonB);
        } else if (choiceC){
            ResetAllTheFlag();
            StartNewConversation(choicePanel.pressButtonC);
        }
    }

    private void AdvanceConversation() {
        if (dialogIndex < conversation.sections.Length) {
            
            if (conversation.sections[dialogIndex].isOptional) {
                DisplayTheChoices();
                return;
            }

            if (speakerUIRight.Speaker != conversation.sections[dialogIndex].character) {
                speakerUIRight.Speaker = conversation.sections[dialogIndex].character;
            }

            DisplayThisLine();
            dialogIndex++;

        } else {
            speakerUILeft.HideDialogBox();
            speakerUIRight.HideDialogBox();
            gameObject.SetActive(false);
            DialogueManager.Instance.OnConversationIsOver();
            GameInfoManager.instance.ResumeTheGame();
        }
    }

    private void DisplayThisLine() {
        Section section = conversation.sections[dialogIndex];
        Character activeCharacter = section.character;

        if (speakerUILeft.SpeakerIs(activeCharacter)) {
            SetDialog(speakerUILeft, speakerUIRight, section.text);
        } else {
            SetDialog(speakerUIRight, speakerUILeft, section.text);
        }

    }

    private void DisplayTheChoices() {
        speakerUILeft.HideDialogBox();
        speakerUIRight.HideDialogBox();

        Section section = conversation.sections[dialogIndex];
        choicePanel.SetButtons(section.choices[0], section.choices[1], section.choices[2]);
        choicePanel.ShowChoicesPanel();
    }

    private void SetDialog(SpeakerUI activeSpeaker, SpeakerUI inactiveSpeaker, string text) {
        StartCoroutine(TypeSentence(text, activeSpeaker));
        activeSpeaker.ShowDialogBox();
        inactiveSpeaker.HideDialogBox();
    }

    private void SetOnButtonListener() {
        choicePanel.buttonA.onClick.AddListener(() => { SetTheButtonFlag(ref choiceA);});
        choicePanel.buttonB.onClick.AddListener(() => { SetTheButtonFlag(ref choiceB);});
        choicePanel.buttonC.onClick.AddListener(() => { SetTheButtonFlag(ref choiceC);});
    }

    private void SetTheButtonFlag(ref bool choice) {
        choice = !choice;
    }

    private void StartNewConversation(Conversation newConversation) {
        conversation = newConversation;
        speakerUILeft.Speaker = newConversation.characterLeft;
        speakerUIRight.Speaker = newConversation.characterRight;
        choicePanel.gameObject.SetActive(false);
        dialogIndex = 0 ;
        AdvanceConversation();
    }

    private void ResetAllTheFlag() {
        choiceA = false;
        choiceB = false;
        choiceC = false;
    }
    
    private IEnumerator TypeSentence(string sentence, SpeakerUI speaker) {
        speaker.Dialog = "";
        foreach(char letter in sentence) {
            speaker.Dialog += letter;
            yield return null;
        }
    } 
}
