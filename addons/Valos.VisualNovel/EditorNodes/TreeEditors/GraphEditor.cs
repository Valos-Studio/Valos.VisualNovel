using System;
using System.Threading.Tasks;
using Godot;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes.BaseNodes;
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

    public async void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        GraphNode result = await ShowPopup(releasePosition);
        
        if (result != null)
        {
            OnConnectionRequest(fromNode, fromPort, result.Name, result.GetInputPortSlot(0));
        }
    }

    public async void OnPopupRequest(Vector2 position)
    {
        await ShowPopup(position);
    }

    public void OnDeleteNodesRequest(Array nodeNames)
    {
        foreach (StringName name in nodeNames)
        {
            DeleteNode(name);
        }
    }

    public void ClearNodes()
    {
    }

    private void DeleteNode(StringName nodeName)
    {
        try
        {
            BaseNode node = GetNode<BaseNode>(nodeName.ToString());

            if (Validator.IsValid(node) == true)
            {
                node.OnDeleteRequest();

                RemoveChild(node);
            }
        }
        catch (Exception e)
        {
            GD.PrintErr(e);
        }
    }

    private async Task<GraphNode> ShowPopup(Vector2 gridPosition)
    {
        this.GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        this.GraphMenu.Show();

        Variant[] result = await ToSignal(this.GraphMenu, nameof(GraphMenu.AddNode));

        if (result.Length > 0)
        {
            return AddSelectionNode((long)result[0].Obj, gridPosition);
        }

        return null;
    }

    private GraphNode AddSelectionNode(long selection, Vector2 gridPosition)
    {
        GraphNode node = this.GraphMenu.GetGraphNode((GraphMenuSelection)selection);

        AddNewGraphNode(node, gridPosition);

        return node;
    }

    public void AddNewGraphNode(GraphNode graphNode, Vector2 gridPosition)
    {
        this.AddChild(graphNode, true);

        graphNode.Owner = this.Owner;

        graphNode.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
    }
}