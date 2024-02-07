using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.Components;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class ResponseEditor : Control
{
    private ResponseData data;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }
    
    public void SetModel(ResponseData data)
    {
        this.data = data;
    }
}