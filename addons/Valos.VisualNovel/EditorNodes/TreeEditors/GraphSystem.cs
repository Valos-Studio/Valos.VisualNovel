using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes;
using Valos.VisualNovel.GameNodes.StartNodes;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    public void LoadNodes()
    {
        NovelPanel panel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        AddStartNode(panel.StartData);
    }

    private void AddStartNode(StartData data)
    {
        StartNode node = StartPackedScene.Instantiate<StartNode>();

        node.Model = data;

        AddNewGraphNode(node, data.GridLocation);
    }

    public void ClearNodes()
    {
    }
}