using UnityEngine;
using TMPro;
using System.Collections;

namespace Baqir
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private float typingSpeed = 0.05f;

        private Coroutine typingCoroutine;
        private bool isTyping;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);
        }

        public void ShowDialogue(string text)
        {
            if (dialoguePanel == null || dialogueText == null) return;

            dialoguePanel.SetActive(true);
            
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                isTyping = false;
            }
            
            typingCoroutine = StartCoroutine(TypeText(text));
        }

        public void HideDialogue()
        {
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
                isTyping = false;
            }
        }

        private IEnumerator TypeText(string text)
        {
            isTyping = true;
            dialogueText.text = "";
            foreach (char letter in text.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            isTyping = false;
        }

        public bool IsTyping()
        {
            return isTyping;
        }

        public bool IsActive()
        {
            return dialoguePanel != null && dialoguePanel.activeSelf;
        }
    }
}
