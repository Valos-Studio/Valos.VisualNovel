using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.Components;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class LocationEditor : Control
{
    private LocationData data;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }
    
    public void SetModel(LocationData data)
    {
        this.data = data;
    }
}