using UnityEngine;

namespace Baqir
{
    public class Telephone : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "A more new model, nothing immediately stands out looking at this.";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Telephone interacted with!");
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
