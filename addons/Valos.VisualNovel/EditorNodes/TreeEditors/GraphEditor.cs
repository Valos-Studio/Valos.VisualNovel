using Godot;
using Godot.Collections;
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

        DeleteNodesRequest += OnDeleteNodesRequest;

        ConnectionRequest += OnConnectionRequest;

        DisconnectionRequest += OnDisconnectionRequest;
    }

    public void OnDisconnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.DisconnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
    }

    public void OnConnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.ConnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
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
        var root = EditorInterface.Singleton.GetEditedSceneRoot();
        
        // EditorSelection
        GD.PrintErr(root.Name);

        this.AddChild(node, true);

        node.SetDeferred(Node.PropertyName.Owner, EditorInterface.Singleton.GetEditedSceneRoot());

        // node.Owner =;


        node.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
    }

    public void OnDeleteNodesRequest(Array nodes)
    {
        foreach (Node node in nodes)
        {
            DeleteNode(node);
        }
    }

    private void DeleteNode(Node node)
    {
        // if(node.IsClass(nameof(StartNode)) == true) return;

        this.RemoveChild(node);

        // node.QueueFree();
    }

    private void ShowPopup(Vector2 gridPosition)
    {
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.StartSelection(gridPosition);
    }
}