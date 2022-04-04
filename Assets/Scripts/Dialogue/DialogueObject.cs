
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] string[] dialogue;
    public bool eliminate;

    public string[] Dialogue => dialogue;
}
