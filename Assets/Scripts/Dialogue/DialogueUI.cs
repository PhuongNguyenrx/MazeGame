using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textLabel;
    [SerializeField]
    DialogueObject testDialogue;

    public PlayerMovement player;

    public bool isOpen { get; private set; }

    TypewriterEffect typewriterEffect;
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        StartCoroutine(StepThroughDialogue(dialogueObject));
        
    }

    IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitForSeconds(2.25f);
        };
        if (dialogueObject.eliminate == true)
        {
            player.Eliminated(Time.time);
        }
        CloseDialogueBox(dialogueObject);
    }
    void CloseDialogueBox(DialogueObject dialogueObject)
    {;
        isOpen = false;
        textLabel.text = string.Empty;
    }
}
