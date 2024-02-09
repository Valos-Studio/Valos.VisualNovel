using Godot;
using Valos.VisualNovel.EditorNodes.Components;
using Valos.VisualNovel.GameNodes.DialogueNodes;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class DialogueEditor : Control
{
    private DialogueNode graphNode;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        this.nameEditor = GetNode<NameEditor>("%NameEditor");
    }

    public void SetModel(DialogueNode node)
    {
        this.graphNode = node;

        this.nameEditor.SetModel(node.Model);
    }

    public void ClearEditor()
    {
        this.nameEditor.Clear();

        this.graphNode = null;
    }
}