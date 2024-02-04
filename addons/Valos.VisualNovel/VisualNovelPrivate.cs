using Godot;
using Godot.Collections;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.GameNodes;

namespace Valos.VisualNovel;

public partial class VisualNovelPlugin
{
    private const string BasePath = "res://addons/Valos.VisualNovel/";

    private const string MainPanelName = "Visual Novel Editor";
    private const string IconName = "Icon";

    private EditorSelection editorSelection;
    private MainPanel mainPanel;
    private Texture2D icon;

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
        if (Validator.IsValid(mainPanel) == true)
        {
            mainPanel.QueueFree();
        }
    }

    private void AddCustomTypes()
    {
        string scriptPath = GetBasePath("NovelPanels/" + nameof(NovelPanel), Extensions.ScriptCs);
        
        string iconPath = GetBasePath(IconName, Extensions.Icon);

        Script script = GD.Load<Script>(scriptPath);
        
        Texture2D texture = GD.Load<Texture2D>(iconPath);

        AddCustomType(nameof(NovelPanel), "Node", script, texture);
    }

    private void RemoveCustomTypes()
    {
        RemoveCustomType(nameof(NovelPanel));
    }
    
    private void AddNodeSelector()
    {
        editorSelection = EditorInterface.Singleton.GetSelection();

        editorSelection.SelectionChanged += OnSelectionChanged;
    }

    private bool IsSelectedNodeTypeNovelPanel()
    {
        Array<Node> selectedNodes = editorSelection.GetSelectedNodes();

        if (selectedNodes.Count != 1)
        {
            return false;
        }

        Node node = selectedNodes[0];
        if (node.GetType() == typeof(NovelPanel))
        {
            return true;
        }

        return false;
    }

    private static string GetBasePath(string sceneName, string extension)
    {
        return BasePath + sceneName + extension;
    }
}