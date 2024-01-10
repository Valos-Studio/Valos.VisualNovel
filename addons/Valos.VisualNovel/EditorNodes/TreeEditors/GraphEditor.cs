using Godot;
using Valos.VisualNovel.EditorNodes.Menus;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public GraphMenu GraphMenu { get; set; }

    public override void _Ready()
    {
        PopupRequest += OnPopupRequest;

        ConnectionToEmpty += OnConnectionToEmpty;
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
        AddChild(node);

        node.Position = gridPosition;
        
        Callable callable = Callable.From(() => BaseNodeOnDeleteRequest(node));
        
        // node.Connect(GraphElement.SignalName.DeleteRequest, callable);
    }

    public void BaseNodeOnDeleteRequest(GraphNode node)
    {
        this.RemoveChild(node);
        
        node.QueueFree();
    }

    private void ShowPopup(Vector2 gridPosition)
    {
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.StartSelection(gridPosition);
    }
}