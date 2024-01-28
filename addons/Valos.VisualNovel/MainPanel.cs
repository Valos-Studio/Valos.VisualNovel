using Godot;
using Valos.VisualNovel.EditorNodes.TreeEditors;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel;

[Tool]
public partial class MainPanel : Panel
{
    [Export()] public TreeEditor TreeEditor { get; set; }
    
    public void InitializePanel()
    {
        NovelPanel panel = EditorInterface.Singleton.GetEditedSceneRoot() as NovelPanel;

        if (Validator.IsValid(panel) == true)
        {
            TreeEditor.InitializeEditor();
        }
    }

    public void FinalizePanel()
    {
        TreeEditor.FinalizeEditor();
    }
}