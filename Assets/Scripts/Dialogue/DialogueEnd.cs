using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueEnd : MonoBehaviour
{
    [SerializeField]TMP_Text textLabel;
    [SerializeField] [TextArea] List<string> endDialogue = new List<string>();
    TypewriterEffect typewriterEffect;
    public AudioSource gunshotAudio;
    public bool isOpen { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        endDialogue.Add("You're like me. We both have too much time on our hands, mm, " + Environment.UserName);
        typewriterEffect = GetComponent<TypewriterEffect>();
            isOpen = true;
            StartCoroutine(StepThroughDialogue());
    }
    IEnumerator StepThroughDialogue()
    {
        foreach (string dialogue in endDialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitForSeconds(5.5f);
        };
        gunshotAudio.Play();
        yield return new WaitForSeconds(0.5f);
        CloseDialogueBox();
    }
    void CloseDialogueBox()
    {
        isOpen = false;
        textLabel.text = string.Empty;
        Application.Quit();
    }
}
