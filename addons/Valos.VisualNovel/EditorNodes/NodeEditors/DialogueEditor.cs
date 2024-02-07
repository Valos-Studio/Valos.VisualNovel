using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.Components;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class DialogueEditor : Control
{
    private DialogueData data;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }

    public void SetModel(DialogueData data)
    {
        this.data = data;
    }
}