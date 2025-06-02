using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueDataSO myDialogue;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
        {
            Debug.LogError("���̾�α׸Ŵ����� �����ϴ�.");
        }
    }

    void OnMouseDown()
    {
        if (dialogueManager == null) return;
        if (dialogueManager.IsDialogueActive()) return;
        if (myDialogue == null) return;
        dialogueManager.StartDialogue(myDialogue);
    }
}
