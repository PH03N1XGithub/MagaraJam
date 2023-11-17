using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] npcDialogueLines;
    public DM dialogueManager;

    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Display a prompt or handle UI feedback if needed.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Hide the prompt or UI feedback if needed.
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Start the dialogue when the player presses 'E'.
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        // Ensure the dialogue manager is assigned.
        if (dialogueManager != null)
        {
            // Start the dialogue with the NPC's specific lines.
            dialogueManager.StartDialogue(npcDialogueLines);
        }
        else
        {
            Debug.LogWarning("Dialogue manager not assigned to NPC: " + gameObject.name);
        }
    }
}
