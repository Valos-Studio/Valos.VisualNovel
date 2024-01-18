using System;
using Godot;
using Godot.Collections;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes;
using Array = Godot.Collections.Array;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public GraphMenu GraphMenu { get; set; }

    private Array<Node> nodeList;

    public GraphEditor()
    {
        nodeList = new Array<Node>();
    }

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
        foreach (Node node in nodeList)
        {
            RemoveChild(node);

            node.QueueFree();
        }

        nodeList.Clear();
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
        GraphMenu.Position = (Vector2I)GetGlobalMousePosition() + GetWindow().Position;

        GraphMenu.Show();
        
        Variant[] result = await ToSignal(GraphMenu, nameof(GraphMenu.AddNode));
        
        GD.PrintErr($"awaited result {result}");

        // if (node != null)
        // {
        //     this.AddChild(node, true);
        //
        //     node.Owner = Owner;
        //
        //     node.PositionOffset = (gridPosition + this.ScrollOffset) / this.Zoom;
        //
        //     nodeList.Add(node);
        // }
    }
    
    // public void AddNode()
}