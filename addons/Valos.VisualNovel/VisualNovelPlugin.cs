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

    /// <summary>
    /// Block users from seeing this view if they select wrong stuff
    /// </summary>
    /// <param name="visible">Does nothing, plugin decides when you can see main panel</param>
    public override void _MakeVisible(bool visible)
    {
        if (IsSelectedNodeTypeNovelPanel())
        {
            mainPanel.Show();

            mainPanel.LoadNodes();
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
        mainPanel.ClearNodes();
        
        _MakeVisible(true);
    }
}
#endif