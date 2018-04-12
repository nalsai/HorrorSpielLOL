using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideController : MonoBehaviour
{

    public GameObject Tutorial;
    public GameObject WASD;
    public GameObject E;
    public GameObject Shift;
    public GameObject WaterWell;
    public GameObject Player;
    public GameObject DialogueBox;
    public DialogueManager DialogueM;
    public bool ScreamHappened;
    public Dialogue ScreamHappenedDialogue;
    public Dialogue StartDialogue;

    void Start()
    {
        StartCoroutine(AStart());
    }

    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.W))
        {
            WASD.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StopCoroutine("ShiftToRun");
            Shift.SetActive(false);
        }
        RaycastHit hit;
        if (ScreamHappened == false && Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, 10) && hit.transform.name == "WaterWellGFX")
        {
            E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                StartCoroutine(ScreamHappenedD());
            }
        }
        else
        {
            E.SetActive(false);
        }
        if (ScreamHappened == true && Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, 10) && hit.transform.name == "House")
        {
            E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ChangeScene());
            }
        }

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("house");
    }

    IEnumerator ScreamHappenedD()
    {
        ScreamHappened = true;
        DialogueBox.SetActive(true);
        yield return new WaitForSeconds(2);
        FindObjectOfType<DialogueManager>().StartDialogue(ScreamHappenedDialogue);
        yield return new WaitForSeconds(2);
        DialogueM.DisplayNextSentence();
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(1);
        Shift.SetActive(true);
    }

    IEnumerator AStart()
    {
        yield return new WaitForSeconds(1);
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(StartDialogue);
        yield return new WaitForSeconds(3);
        DialogueM.DisplayNextSentence();
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(1);
        WASD.SetActive(true);
    }
}
