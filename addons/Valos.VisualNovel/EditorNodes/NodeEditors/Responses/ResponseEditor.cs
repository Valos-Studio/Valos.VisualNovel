using Godot;
using Valos.VisualNovel.EditorNodes.Components;
using Valos.VisualNovel.GameNodes.ResponseNodes;

namespace Valos.VisualNovel.EditorNodes.Responses.NodeEditors;

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
       
        this.nameEditor.SetModel(node.Model);
    }

    public void ClearEditor()
    {
        this.nameEditor.Clear();

        this.graphNode = null;
    }
}