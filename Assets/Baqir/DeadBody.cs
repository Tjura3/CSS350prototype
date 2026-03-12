using UnityEngine;

namespace Baqir
{
    public class DeadBody : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "A lifeless body... looks like foul play.";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Dead Body interacted with!");
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
            return "Press E to Inspect Body";
        }
    }
}
