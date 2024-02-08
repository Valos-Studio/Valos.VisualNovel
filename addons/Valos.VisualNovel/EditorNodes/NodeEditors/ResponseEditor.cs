using Godot;
using Valos.VisualNovel.EditorNodes.Components;
using Valos.VisualNovel.GameNodes.ResponseNodes;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class ResponseEditor : Control
{
    private ResponseNode graphNode;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }
    
    public void SetModel(ResponseNode node)
    {
        this.graphNode = node;

        nameEditor.NameValue = node.Model.Name;
    }

    public void ClearEditor()
    {
        nameEditor.NameValue = null;

        graphNode = null;
    }
}