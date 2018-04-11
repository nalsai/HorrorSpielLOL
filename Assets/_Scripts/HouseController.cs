using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour {

    public Dialogue EntranceDialogue;
    public Dialogue ScreamDialogue;
    public Dialogue DoorDialogue;
    public Dialogue TunnelDialogue;
    public Collider ScreamTrigger;
    public GameObject Flashlight;
    public GameObject DialogueBox;
    public DialogueManager DialogueM;

    void Start ()
    {
        Flashlight.SetActive(false);
        StartCoroutine(Entrance());
    }
	
	void Update ()
    {

    }

    //void OnTriggerEnter(Collider ScreamTrigger)
    //{
        //StartCoroutine(ScreamD());
    //}

    IEnumerator Entrance()
    {
        yield return new WaitForSeconds(1);
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(EntranceDialogue);
        yield return new WaitForSeconds(2);
        DialogueM.DisplayNextSentence();
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(1);
        Flashlight.SetActive(true);
    }

    IEnumerator ScreamD()
    {
        yield return new WaitForSeconds(4);
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(ScreamDialogue);
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
    }

    IEnumerator DoorD()
    {
        yield return new WaitForSeconds(1);
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(DoorDialogue);
        yield return new WaitForSeconds(2);
        DialogueM.DisplayNextSentence();
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(1);
        Flashlight.SetActive(true);
    }

    IEnumerator TunnelD()
    {
        yield return new WaitForSeconds(1);
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(TunnelDialogue);
        yield return new WaitForSeconds(2);
        DialogueM.DisplayNextSentence();
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(1);
        Flashlight.SetActive(true);
    }
}
