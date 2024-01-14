#if TOOLS
using Godot;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel;

[Tool]
public partial class VisualNovelPlugin : EditorPlugin
{
    public override void _EnterTree()
    {
        AddEditorToEngine();

        AddCustomTypes();

        AddNodeSelector();

        _MakeVisible(false);
    }

    public override void _ExitTree()
    {
        RemoveNodeSelector();
        
        RemoveEditorFromEngine();

        RemoveCustomTypes();
    }

    public override bool _Handles(GodotObject godotObject)
    {
        if (godotObject.GetType() == typeof(NovelPanel))
        {
            return true;
        }

        return false;
    }

    public override bool _HasMainScreen()
    {
        return true;
    }

    public override void _MakeVisible(bool visible)
    {
        if (visible)
        {
            mainPanel.Show();
        }
        else
        {
            mainPanel.Hide();
        }
    }

    public override string _GetPluginName()
    {
        return MainPanelName;
    }

    public override Texture2D _GetPluginIcon()
    {
        return icon;
    }

    public void OnSelectionChanged()
    {
        _MakeVisible(IsSelectedNodeTypeNovelPanel());
    }
}
#endif