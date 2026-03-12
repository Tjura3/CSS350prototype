using UnityEngine;

namespace Baqir
{
    public class Bookshelf : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "The books are slightly out of place, as if someone recently searched here...";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Bookshelf interacted with!");
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
