using Godot;

namespace Valos.VisualNovel.EditorNodes.Menus;

[Tool]
public partial class GraphMenu : PopupMenu
{
    [Signal]
    public delegate void AddNodeEventHandler(LocationTreeSelection selection);

    // [Export()] public PackedScene DialogueNode { get; set; }
    // [Export()] public PackedScene ResponseNode { get; set; }
    [Export()] public PackedScene LocationNode { get; set; }


    public override void _Ready()
    {
        IdPressed += OnIdPressed;
    }

    public void OnIdPressed(long id)
    {
        EmitSignal(nameof(AddNode), id);
    }

    public GraphNode GetGraphNode(LocationTreeSelection selection)
    {
        switch (selection)
        {
            // case LocationTreeSelection.DialogueNode:
            //     return DialogueNode.Instantiate<GraphNode>();
            // case LocationTreeSelection.ResponseNode:
            //     return ResponseNode.Instantiate<GraphNode>();
            case LocationTreeSelection.LocationNode:
                return LocationNode.Instantiate<GraphNode>();
            default:
                return null;
        }
    }
}