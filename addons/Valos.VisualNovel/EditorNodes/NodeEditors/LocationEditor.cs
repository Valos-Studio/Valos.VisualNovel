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
        nameEditor = GetNode<NameEditor>("%NameEditor");
    }
    
    public void SetModel(LocationNode node)
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