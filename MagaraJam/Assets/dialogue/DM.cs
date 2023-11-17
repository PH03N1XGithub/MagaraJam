using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DM : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private bool isTyping = false;
    //public bool isEnd;

    public NPC npc;

    void Start()
    {
        StartCoroutine(TypeDialogue());
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                isTyping = false;
                dialogueText.text = dialogueLines[currentLine];
            }
            else
            {
                
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    StartCoroutine(TypeDialogue());
                }
                else
                {
                    
                    Debug.Log("End of dialogue");
                    End();
                }
            }
        }
    }

    IEnumerator TypeDialogue()
    {
        isTyping = true;

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

    public void StartDialogue(string[] lines)
    {
        dialogueText.gameObject.SetActive(true);
        dialogueLines = lines;
        currentLine = 0;
        StartCoroutine(TypeDialogue());
        
    }

    void End()
    {
        if (dialogueText == null)
            return;
        dialogueText.gameObject.SetActive(false);
        currentLine = 0;
        //isEnd = true;
        //npc.isEnd = true;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npc = other.GetComponent<NPC>();

        }
    }
}
