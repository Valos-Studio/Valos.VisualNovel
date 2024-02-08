using Godot;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.DialogueNodes;

namespace Valos.VisualNovel.EditorNodes.NodeEditors;

[Tool]
public partial class NodeEditor : TabContainer
{
    public DialogueEditor DialogueEditor { get; private set; }
    public ResponseEditor ResponseEditor { get; private set; }
    public LocationEditor LocationEditor { get; private set; }
    
    public override void _Ready()
    {
        this.DialogueEditor = GetNode<DialogueEditor>(nameof(DialogueEditor));
        
        this.ResponseEditor = GetNode<ResponseEditor>(nameof(ResponseEditor));
        
        this.LocationEditor = GetNode<LocationEditor>(nameof(LocationEditor));
    }

    public void ClearEditors()
    {
        DialogueEditor.ClearEditor();
        
        ResponseEditor.ClearEditor();
        
        LocationEditor.ClearEditor();
    }
}