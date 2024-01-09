#if TOOLS
using Godot;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel;

[Tool]
public partial class VisualNovelPlugin : EditorPlugin
{
    private const string BasePath = "res://addons/Valos.VisualNovel/";

    private const string MainPanelName = "Visual Novel Editor";
    private const string IconName = "Icon";

    private MainPanel mainPanel;
    private Texture2D icon;

    public override void _EnterTree()
    {
        AddEditorToEngine();

        AddCustomTypes();

        _MakeVisible(false);
    }

    public override void _ExitTree()
    {
        RemoveEditorFromEngine();

        RemoveCustomTypes();
    }

    // public override bool _Handles(GodotObject @object)
    // {
    //     return @object.GetClass() == nameof(NovelPanel);
    // }

    public override bool _HasMainScreen()
    {
        return true;
    }

    public override void _MakeVisible(bool visible)
    {
        if (mainPanel != null)
        {
            mainPanel.Visible = visible;
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

    private void AddEditorToEngine()
    {
        string mainScenePath = GetBasePath(nameof(MainPanel), Extensions.Scene);

        string iconPath = GetBasePath(IconName, Extensions.Icon);

        icon = GD.Load<Texture2D>(iconPath);

        PackedScene mainScene = GD.Load<PackedScene>(mainScenePath);

        mainPanel = mainScene.Instantiate<MainPanel>();

        EditorInterface.Singleton.GetEditorMainScreen().AddChild(mainPanel);
    }

    private void RemoveEditorFromEngine()
    {
        if (mainPanel != null && IsInstanceValid(mainPanel) && !mainPanel.IsQueuedForDeletion())
        {
            mainPanel.QueueFree();
        }
    }

    private void AddCustomTypes()
    {
        string scriptPath = GetBasePath("GameNodes/" + nameof(NovelPanel), Extensions.ScriptCs);
        string iconPath = GetBasePath(IconName, Extensions.Icon);

        Script script = GD.Load<Script>(scriptPath);
        Texture2D texture = GD.Load<Texture2D>(iconPath);

        AddCustomType(nameof(NovelPanel), "Node", script, texture);
    }

    private void RemoveCustomTypes()
    {
        RemoveCustomType(nameof(NovelPanel));
    }

    private static string GetBasePath(string sceneName, string extension)
    {
        return BasePath + sceneName + extension;
    }
}
#endif