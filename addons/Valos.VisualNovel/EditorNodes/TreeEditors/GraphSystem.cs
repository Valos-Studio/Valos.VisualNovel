using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes;
using Valos.VisualNovel.GameNodes.BaseNodes;
using Valos.VisualNovel.GameNodes.StartNodes;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    public void LoadNodes()
    {
        novelPanel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        if (novelPanel == null) return;

        AddStartNode(novelPanel.StartData);
    }

    private void AddStartNode(StartData data)
    {
        StartNode node = StartPackedScene.Instantiate<StartNode>();

        node.SetModel(data);
        
        AddNewGraphNode(node, data.GridLocation);
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