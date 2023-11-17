using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private bool isTyping = false;
    bool isShowing = false;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isShowing)
            StartD();

        if (isShowing == false)
            return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                isTyping = false;
                dialogueText.text = dialogueLines[currentLine];
            }
            else
            {
                // Move to the next line
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    StartCoroutine(TypeDialogue());
                }
                else
                {
                    // End dialogue
                    Debug.Log("End of dialogue");
                    end();
                }
            }
        }
    }

    IEnumerator TypeDialogue()
    {
        isTyping = true;
        if(dialogueText != null)
            dialogueText.gameObject.SetActive(true);

        if (currentLine < dialogueLines.Length && dialogueText != null)
        {
            dialogueText.text = "";

            foreach (char letter in dialogueLines[currentLine].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        isTyping = false;
    }

    void end()
    {
        if (dialogueText == null)
            return;
        dialogueText.gameObject.SetActive(false);
        currentLine = 0;
    }

    void StartD()
    {
        if (isTyping == true)
            return;
        StartCoroutine(TypeDialogue());
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.transform.tag == "NPC")
            isShowing = true;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.transform.tag == "NPC")
            isShowing = false;
    }

}
