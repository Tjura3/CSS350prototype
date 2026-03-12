using UnityEngine;

namespace Baqir
{
    public class AshTray : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "Recently used. The brand doesn't match the victims usual choice.";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Ash Tray interacted with!");
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
