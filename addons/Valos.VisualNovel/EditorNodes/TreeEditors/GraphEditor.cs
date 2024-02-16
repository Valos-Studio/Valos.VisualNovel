using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.DialogueNodes;
using Valos.VisualNovel.GameNodes.LocationNodes;
using Valos.VisualNovel.GameNodes.ResponseNodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

[Tool]
public partial class GraphEditor : GraphEdit
{
    [Export()] public PackedScene StartPackedScene { get; set; }
    [Export()] public GraphMenu GraphMenu { get; set; }

    private NovelPanel novelPanel;

    public override void _Ready()
    {
        InitializeSignals();
    }

    private void DeleteNode(StringName nodeName)
    {
        try
        {
            BaseNode node = GetNode<BaseNode>(nodeName.ToString());

            if (Validator.IsValid(node) == true)
            {
                IEnumerable<Connection> connections = novelPanel.Connections.GetListWhereName(nodeName);

                foreach (Connection connection in connections)
                {
                    OnDisconnectionRequest(connection.FromNode, connection.FromPort,
                        connection.ToNode, connection.ToPort);
                }

                // if (node is DialogueNode)
                // {
                //     novelPanel.Dialogues.TryRemoveChild(nodeName.ToString());
                // }
                // else if (node is ResponseNode)
                // {
                //     novelPanel.Responses.TryRemoveChild(nodeName.ToString());
                // }
                // else
                if (node is LocationNode)
                {
                    novelPanel.Locations.TryRemoveChild(nodeName.ToString());
                }

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
            return await AddSelectionNode((long)result[0].Obj, gridPosition);
        }

        return null;
    }

    private async Task<GraphNode> AddSelectionNode(long selection, Vector2 gridPosition)
    {
        GraphNode graphNode = this.GraphMenu.GetGraphNode((LocationTreeSelection)selection);

        this.AddChildDeferred(graphNode, this.Owner);
        
        await ToSignal(GetTree(), "process_frame");

        gridPosition = (gridPosition + this.ScrollOffset) / this.Zoom;

        // if (graphNode is DialogueNode dialogueNode)
        // {
        //     AddDialogueModel(dialogueNode, gridPosition);
        // }
        //
        // if (graphNode is ResponseNode responseNode)
        // {
        //     AddResponseModel(responseNode, gridPosition);
        // }

        if (graphNode is LocationNode locationNode)
        {
            AddLocationModel(locationNode, gridPosition);
        }

        return graphNode;
    }

    // private void AddDialogueModel(DialogueNode node, Vector2 gridPosition)
    // {
    //     DialogueData dialogueData = new DialogueData() { GridLocation = gridPosition };
    //
    //     dialogueData.Name = node.Name;
    //
    //     novelPanel.Dialogues.TryAddChild(dialogueData);
    //
    //     node.SetModel(dialogueData);
    // }
    //
    // private void AddResponseModel(ResponseNode node, Vector2 gridPosition)
    // {
    //     ResponseData responseData = new ResponseData() { GridLocation = gridPosition };
    //
    //     responseData.Name = node.Name;
    //
    //     novelPanel.Responses.TryAddChild(responseData);
    //
    //     node.SetModel(responseData);
    // }

    private void AddLocationModel(LocationNode node, Vector2 gridPosition)
    {
        LocationData locationData = new LocationData() { GridLocation = gridPosition };

        locationData.Name = node.Name;

        novelPanel.Locations.TryAddChild(locationData);

        node.SetModel(locationData);
    }
}