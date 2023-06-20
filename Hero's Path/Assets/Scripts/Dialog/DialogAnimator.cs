using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimator : MonoBehaviour
{
    public Animator StartDialog;
    public DialogManager dm;

    private void Start()
    {
        //StartDialog = GetComponent<Animator>(); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialog.SetBool("keep", true);
        //StartDialog.SetBool("StartOpen", true);
        //Keepjack.SetBool("keep_jack", true);

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StartDialog.SetBool("keep", false);
        //SetBool("StartOpen", false);
        //Keepjack.SetBool("keep_jack", false);
        dm.EndDialog();
    }
}
