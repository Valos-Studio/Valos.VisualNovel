using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.Menus;
using Valos.VisualNovel.GameNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.DialogueNodes;
using Valos.VisualNovel.GameNodes.LocationNodes;
using Valos.VisualNovel.GameNodes.ResponseNodes;
using Valos.VisualNovel.GameNodes.StartNodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

// ReSharper disable PossibleNullReferenceException

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    public async void LoadNodes()
    {
        novelPanel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        if (Validator.IsValid(novelPanel) == false) return;

        AddStartNode(novelPanel.StartNode);
        
        AddDialogueNodes(novelPanel.Dialogues.Values);

        AddResponseNodes(novelPanel.Responses.Values);

        AddLocationNodes(novelPanel.Locations.Values);

        await ToSignal(GetTree(), "process_frame");

        AddConnections(novelPanel.Connections.Values);
    }

    private void AddStartNode(StartData data)
    {
        StartNode node = StartPackedScene.Instantiate<StartNode>();

        this.AddChildDeferred(node, this.Owner, data.Name);

        node.SetModel(data);
    }

    private void AddDialogueNodes(IEnumerable<DialogueData> dialogues)
    {
        foreach (DialogueData data in dialogues)
        {
            DialogueNode node = (DialogueNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.DialogueNode);

            this.AddChildDeferred(node, this.Owner, data.Name);

            node.SetModel(data);
        }
    }

    private void AddResponseNodes(IEnumerable<ResponseData> dialogues)
    {
        foreach (ResponseData data in dialogues)
        {
            ResponseNode node = (ResponseNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.ResponseNode);

            this.AddChildDeferred(node, this.Owner, data.Name);

            node.SetModel(data);
        }
    }

    private void AddLocationNodes(IEnumerable<LocationData> locations)
    {
        foreach (LocationData data in locations)
        {
            LocationNode node = (LocationNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.LocationNode);

            this.AddChildDeferred(node, this.Owner, data.Name);

            node.SetModel(data);
        }
    }

    private void AddConnections(IEnumerable<Connection> connections)
    {
        foreach (Connection connection in connections)
        {
            CallDeferred(GraphEdit.MethodName.ConnectNode, connection.FromNode, (int)connection.FromPort,
                connection.ToNode, (int)connection.ToPort);
        }
    }

    public void ClearNodes()
    {
        if (Validator.IsValid(novelPanel) == true)
        {
            foreach (Connection connection in novelPanel.Connections.Values)
            {
                this.DisconnectNode(connection.FromNode, (int)connection.FromPort, connection.ToNode,
                    (int)connection.ToPort);
            }
        }

        foreach (Node child in GetChildren())
        {
            RemoveChildSafe(child);
        }

        this.novelPanel = null;
    }

    private void RemoveChildSafe(Node child)
    {
        if (child is ICleanable cleanable)
        {
            cleanable.Clean();

            RemoveChild(child);
        }
    }
}