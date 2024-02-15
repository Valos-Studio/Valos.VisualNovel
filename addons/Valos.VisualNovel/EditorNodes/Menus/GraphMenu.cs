using Godot;

namespace Valos.VisualNovel.EditorNodes.Menus;

[Tool]
public partial class GraphMenu : PopupMenu
{
    [Signal]
    public delegate void AddNodeEventHandler(GraphMenuSelection selection);

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

    public GraphNode GetGraphNode(GraphMenuSelection selection)
    {
        switch (selection)
        {
            // case GraphMenuSelection.DialogueNode:
            //     return DialogueNode.Instantiate<GraphNode>();
            // case GraphMenuSelection.ResponseNode:
            //     return ResponseNode.Instantiate<GraphNode>();
            case GraphMenuSelection.LocationNode:
                return LocationNode.Instantiate<GraphNode>();
            default:
                return null;
        }
    }
}