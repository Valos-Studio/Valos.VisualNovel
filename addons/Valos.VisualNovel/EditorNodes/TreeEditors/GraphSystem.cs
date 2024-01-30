using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes;
using Valos.VisualNovel.GameNodes.StartNodes;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    public void LoadNodes()
    {
        novelPanel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;
        
        if(novelPanel == null) return;

        AddStartNode(novelPanel.StartData);
    }

    private void AddStartNode(StartData data)
    {
        StartNode node = StartPackedScene.Instantiate<StartNode>();

        node.Model = data;

        AddNewGraphNode(node, data.GridLocation);
    }

    public void ClearNodes()
    {
        novelPanel = null;
    }
}