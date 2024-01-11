using Godot;
using Valos.VisualNovel.EditorNodes.Menus;
using Godot.Collections;

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
        // node.Owner = EditorInterface.Singleton.GetEditedSceneRoot();
        node.Owner = this;

        this.AddChild(node, true);


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