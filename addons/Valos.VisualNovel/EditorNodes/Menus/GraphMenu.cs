using Godot;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel.EditorNodes.Menus;

[Tool]
public partial class GraphMenu : PopupMenu
{
    [Signal]
    public delegate void AddNodeEventHandler(GraphNode node, Vector2 gridPosition);

    [Export()] public PackedScene DialogueNode { get; set; }
    [Export()] public PackedScene ResponseNode { get; set; }
    [Export()] public PackedScene LocationNode { get; set; }

    private Vector2 gridPosition;

    public override void _Ready()
    {
        IdPressed += OnIdPressed;
    }

    public void OnIdPressed(long id)
    {
        switch (id)
        {
            case 1:
                SendNode(DialogueNode);
                break;
            case 2:
                SendNode(ResponseNode);
                break;
            default:
                SendNode(LocationNode);
                break;
        }
    }

    public void StartSelection(Vector2 gridPosition)
    {
        this.gridPosition = gridPosition;

        this.Show();
    }

    private void SendNode(PackedScene packedScene)
    {
        GraphNode node = packedScene.Instantiate<GraphNode>();

        EmitSignal(nameof(AddNode), node, gridPosition);
    }
}