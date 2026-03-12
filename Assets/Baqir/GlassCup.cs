using UnityEngine;

namespace Baqir
{
    public class GlassCup : MonoBehaviour, IInteractable
    {
        [SerializeField] private string dialogueText = "The glass smells faintly bitter. Could this be the cause of death?";
        [SerializeField] private float interactRange = 3f;

        public void Interact()
        {
            Debug.Log("Glass Cup interacted with!");
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
