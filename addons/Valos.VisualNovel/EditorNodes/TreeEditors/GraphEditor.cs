using Godot;
using Valos.VisualNovel.EditorNodes.Menus;
using Array = Godot.Collections.Array;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public GraphMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        PopupRequest += OnPopupRequest;

        ConnectionToEmpty += OnConnectionToEmpty;

        DeleteNodesRequest += OnDeleteNodesRequest;
    }

    public void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        ShowPopup(releasePosition);
    }

    public void OnPopupRequest(Vector2 position)
    {
        ShowPopup(position);
    }

    public void OnAddNode(GraphNode node, Vector2 gridPosition)
    {
        this.AddChild(node, true);

        node.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
    }

    void OnDeleteNodesRequest(Array nodes)
    {
        GD.PrintErr($"Delete pressed {nodes.Count}");
        foreach (Node node in nodes)
        {
            DeleteNode(node);
        }
    }

    private void DeleteNode(Node node)
    {
        this.RemoveChild(node);

        // node.QueueFree();
    }

    private void ShowPopup(Vector2 gridPosition)
    {
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.StartSelection(gridPosition);
    }
}