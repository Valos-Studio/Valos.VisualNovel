using Godot;
using Valos.VisualNovel.EditorNodes.Components;
using Valos.VisualNovel.GameNodes.LocationNodes;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class LocationEditor : Control
{
    private LocationNode graphNode;
    private NameEditor nameEditor;

    public override void _Ready()
    {
        this.nameEditor = GetNode<NameEditor>("%NameEditor");
    }
    
    public void SetModel(LocationNode node)
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