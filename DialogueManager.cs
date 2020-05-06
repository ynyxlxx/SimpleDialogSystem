using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public DialogDisplay displayPanel;

    public event System.Action ConversationIsOver;
    public delegate void ConversationStartCallback();

    private static DialogueManager _instance;
    public static DialogueManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartConversation(string nameOfConversation, float delay = 0f) {
        displayPanel.conversation = Resources.Load("Conversations/" + nameOfConversation) as Conversation;
        if (displayPanel != null) {
            StartCoroutine(ShowTheDialogPanel(delay));
        } else {
            Debug.Log("Cannot find displayPanel...");
        }
    }

    public void StartConversation(string nameOfConversation, ConversationStartCallback startCallBack, float delay = 0f) {

    }

    private IEnumerator ShowTheDialogPanel(float delay) {
        yield return new WaitForSeconds(delay);
        displayPanel.gameObject.SetActive(true);
    }

    public void OnConversationIsOver() {
        if (ConversationIsOver != null) {
            ConversationIsOver();
        }
        Debug.Log("Conversation Is End");
    }
}
