#if TOOLS
using System.IO;
using Godot;

namespace Valos.Dialogue;

[Tool]
public partial class ValosDialoguePlugin : EditorPlugin
{
    private const string BasePath = "res://addons/Valos.Dialogue/";

    private const string VisualNovelEditorName = "VisualNovelEditor";
    private const string IconName = "Icon";

    private Texture2D icon;
    private EngineNode engineNode;

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
        if (engineNode != null)
        {
            engineNode.Visible = visible;
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
        string mainScenePath = GetPath(nameof(EngineNode), Extensions.Scene);

        string iconPath = GetPath(IconName, Extensions.Icon);

        icon = GD.Load<Texture2D>(iconPath);

        PackedScene mainScene = GD.Load<PackedScene>(mainScenePath);

        engineNode = mainScene.Instantiate<EngineNode>();

        EditorInterface.Singleton.GetEditorMainScreen().AddChild(engineNode);
    }

    private void RemoveEditorFromEngine()
    {
        if (engineNode != null && IsInstanceValid(engineNode) && !engineNode.IsQueuedForDeletion())
        {
            engineNode.QueueFree();
        }
    }

    private void AddCustomTypes()
    {
        string scriptPath = GetPath(nameof(VisualNovelEditor), Extensions.ScriptCs);
        string iconPath = GetPath(IconName, Extensions.Icon);

        Script script = GD.Load<Script>(scriptPath);
        Texture2D texture = GD.Load<Texture2D>(iconPath);

        AddCustomType(VisualNovelEditorName, "Node", script, texture);
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