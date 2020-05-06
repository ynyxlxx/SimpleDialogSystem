using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour {

    public Image speakerImage;
    public Text fullName;
    public Text dialog;

    private Character _speaker;
    public Character Speaker {
        get { return _speaker; }
        set {
            _speaker = value;
            this.speakerImage.sprite = _speaker.characterImage;
            this.fullName.text = _speaker.fullName;
        }
    }

    public string Dialog {
        get { return dialog.text; }
        set { this.dialog.text = value; }
    }

    public bool HasSpeaker() {
        return _speaker != null;
    }

    public bool SpeakerIs(Character character) {
        return _speaker == character;
    }

    public void ShowDialogBox() {
        this.gameObject.SetActive(true);
    }

    public void HideDialogBox() {
        this.gameObject.SetActive(false);
    }
}
