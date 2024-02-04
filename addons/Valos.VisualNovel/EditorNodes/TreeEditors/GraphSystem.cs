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

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    public void LoadNodes()
    {
        novelPanel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        if (novelPanel == null) return;

        AddStartNode(novelPanel.StartData);

        AddDialogueNodes(novelPanel.Dialogues.Values);

        AddResponseNodes(novelPanel.Responses.Values);

        AddLocationNodes(novelPanel.Locations.Values);

        AddConnections(novelPanel.ConnectionList.Values);
    }

    private void AddStartNode(StartData data)
    {
        StartNode node = StartPackedScene.Instantiate<StartNode>();

        node.SetModel(data);

        AddNewGraphNode(node, data.GridLocation);
    }

    private void AddDialogueNodes(IEnumerable<DialogueData> dialogues)
    {
        foreach (DialogueData data in dialogues)
        {
            DialogueNode node = (DialogueNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.DialogueNode);

            AddNewGraphNode(node, data.GridLocation);

            node.SetModel(data);
        }
    }

    private void AddResponseNodes(IEnumerable<ResponseData> dialogues)
    {
        foreach (ResponseData data in dialogues)
        {
            ResponseNode node = (ResponseNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.ResponseNode);

            AddNewGraphNode(node, data.GridLocation);

            node.SetModel(data);
        }
    }

    private void AddLocationNodes(IEnumerable<LocationData> locations)
    {
        foreach (LocationData data in locations)
        {
            LocationNode node = (LocationNode)this.GraphMenu.GetGraphNode(GraphMenuSelection.LocationNode);

            AddNewGraphNode(node, data.GridLocation);

            node.SetModel(data);
        }
    }

    private void AddConnections(IEnumerable<Connection> connections)
    {
        foreach (Connection connection in connections)
        {
            this.ConnectNode(connection.FromNode, (int)connection.FromPort, connection.ToNode, (int)connection.ToPort);
        }   
    }
    
    public void ClearNodes()
    {
        this.novelPanel = null;

        foreach (Node child in GetChildren())
        {
            RemoveChildSafe(child);
        }
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