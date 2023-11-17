using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] npcDialogueLines;
    public DM dialogueManager;

    private bool playerInRange = false;
    public bool canAbleToTalk = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        if (!canAbleToTalk)
            return;
        if (dialogueManager != null)
        {
            
            dialogueManager.StartDialogue(npcDialogueLines);
        }
        else
        {
            Debug.LogWarning("Dialogue manager not assigned to NPC: " + gameObject.name);
        }
        canAbleToTalk=false;
    }
}
