using System;
using Godot;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes;
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

    public void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        ShowPopup(releasePosition);
    }

    public void OnPopupRequest(Vector2 position)
    {
        ShowPopup(position);
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

    private async void ShowPopup(Vector2 gridPosition)
    {
        this.GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        this.GraphMenu.Show();

        Variant[] result = await ToSignal(this.GraphMenu, nameof(GraphMenu.AddNode));

        if (result.Length > 0)
        {
            
            AddNewNode((long)result[0].Obj, gridPosition);
        }
    }

    public void AddNewNode(long selection, Vector2 gridPosition)
    {
        GraphNode node = this.GraphMenu.GetGraphNode((GraphMenuSelection)selection);

        this.AddChild(node, true);

        node.Owner = this.Owner;

        node.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
    }
}