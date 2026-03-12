using UnityEngine;

namespace Baqir
{
    public class PoliticalPapers : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "A stack of political correspondence. Nothing here directly explains the death.";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Political Papers interacted with!");
            if (DialogueManager.Instance != null)
            {
                if (DialogueManager.Instance.IsActive())
                {
                    DialogueManager.Instance.HideDialogue();
                }
                else
                {
                    DialogueManager.Instance.ShowDialogue(dialogueText);
                }
            }
            else
            {
                Debug.LogWarning("DialogueManager Instance not found!");
            }
        }

        public string GetInteractText()
        {
            return "Press E to Inspect";
        }
    }
}
