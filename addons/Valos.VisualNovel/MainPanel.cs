using Godot;
using Valos.VisualNovel.EditorNodes.TreeEditors;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel;

[Tool]
public partial class MainPanel : Panel
{
    [Export()] public TreeEditor TreeEditor { get; set; }
    
    public void LoadNodes()
    {
        NovelPanel panel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        if (Validator.IsValid(panel) == true)
        {
            TreeEditor.AddStartNode(panel.StartData);
        }
    }

    public void ClearNodes()
    {
        TreeEditor.ClearNodes();
    }
}