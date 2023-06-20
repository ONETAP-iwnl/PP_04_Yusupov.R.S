using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public Animator boxAnim;
    public Animator StartAnim;

    private Queue<string> senteces;

    private void Start()
    {
        senteces = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        boxAnim.SetBool("DialogAnimator", true);
        StartAnim.SetBool("StartOpen", false);

        nameText.text = dialog.name;
        senteces.Clear();

        foreach(string sentence in dialog.sentences) 
        {
            senteces.Enqueue(sentence);
        }
        DisplayNextSentece();
    }

    public void DisplayNextSentece()
    {
        if(senteces.Count > 0) 
        {
            EndDialog();
            return;
        }
        string sentence = senteces.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    

    IEnumerator TypeSentence(string sentence) 
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        //boxAnim.SetBool("DialogAnimator", false);
    }
}
