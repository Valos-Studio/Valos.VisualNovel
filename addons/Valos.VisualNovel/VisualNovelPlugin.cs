#if TOOLS
using Godot;

namespace Valos.VisualNovel;

[Tool]
public partial class VisualNovelPlugin : EditorPlugin
{
    private const string BasePath = "res://addons/Valos.VisualNovel/";

    private const string VisualNovelEditorName = "VisualNovelEditor";
    private const string IconName = "Icon";

    private MainPanel mainPanel;
    private Texture2D icon;

    public override void _EnterTree()
    {
        // AddCustomTypes();

        AddEditorToEngine();

        _MakeVisible(true);
    }

    public override void _ExitTree()
    {
        // RemoveCustomTypes();

        RemoveEditorFromEngine();

        _MakeVisible(false);
    }

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
        return VisualNovelEditorName;
    }

    public override Texture2D _GetPluginIcon()
    {
        return icon;
    }


    private void AddEditorToEngine()
    {
        string mainScenePath = GetPath(nameof(MainPanel), Extensions.Scene);

        string iconPath = GetPath(IconName, Extensions.Icon);

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
        // string scriptPath = GetPath(nameof(VisualNovelEditor), Extensions.ScriptCs);
        // string iconPath = GetPath(IconName, Extensions.Icon);
        //
        // Script script = GD.Load<Script>(scriptPath);
        // Texture2D texture = GD.Load<Texture2D>(iconPath);
        //
        // AddCustomType(VisualNovelEditorName, "Node", script, texture);
    }

    private void RemoveCustomTypes()
    {
        RemoveCustomType(VisualNovelEditorName);
    }

    private static string GetPath(string sceneName, string extension)
    {
        return BasePath + sceneName + extension;
    }
}
#endif