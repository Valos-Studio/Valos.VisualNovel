using Godot;
using Valos.VisualNovel.EditorNodes.Components;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class DialogueEditor : Control
{
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }
}