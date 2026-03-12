using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

namespace Baqir
{
    public class PlayerInteraction : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float interactionDistance = 5f;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private Camera playerCamera;

        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI interactText;
        [SerializeField] private GameObject interactPromptPanel;

        private void Start()
        {
            if (playerCamera == null) playerCamera = Camera.main;
            if (interactPromptPanel != null) interactPromptPanel.SetActive(false);
        }

        private void Update()
        {
            UpdateInteractionUI();

            if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                PerformInteraction();
            }
        }

        private void UpdateInteractionUI()
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    if (interactPromptPanel != null) interactPromptPanel.SetActive(true);
                    if (interactText != null) interactText.text = interactable.GetInteractText();
                    return;
                }
            }

            // If we are here, we are NOT looking at an interactable
            if (interactPromptPanel != null) interactPromptPanel.SetActive(false);

            // Hide dialogue if looking away AND it's done typing
            if (DialogueManager.Instance != null && 
                DialogueManager.Instance.IsActive() && 
                !DialogueManager.Instance.IsTyping())
            {
                DialogueManager.Instance.HideDialogue();
            }
        }

        private void PerformInteraction()
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    Debug.Log("Interacting with: " + hit.collider.name);
                    interactable.Interact();
                }
            }
        }
    }
}
