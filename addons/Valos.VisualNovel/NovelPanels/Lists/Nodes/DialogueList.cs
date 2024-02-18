using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.Extensions;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
public partial class DialogueList : Node
{
    public ICollection<DialogueData> Values
    {
        get => this.list.Values;
    }

    public ICollection<string> Keys
    {
        get => this.list.Keys;
    }

    public DialogueData this[string key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<string, DialogueData> list;

    private Node parent;

    public DialogueList()
    {
        this.list = new Dictionary<string, DialogueData>();
    }

    public override void _Ready()
    {
        parent = GetParent();

        ChildEnteredTree += OnChildEnteredTree;

        ChildExitingTree += OnChildExitingTree;

        foreach (Node child in GetChildren())
        {
            OnChildEnteredTree(child);
        }
    }

    public void OnChildEnteredTree(Node node)
    {
        if (node is DialogueData data)
        {
            if (this.list.ContainsKey(data.Name) == true) return;

            this.list.Add(data.Name, data);
        }
        else
        {
            RemoveChild(node);
        }
    }

    public void OnChildExitingTree(Node node)
    {
        if (node is DialogueData data)
        {
            if (list.ContainsKey(data.Name) == false) return;

            this.list.Remove(data.Name);
        }
    }

    public bool TryAddChild(DialogueData dialogueData)
    {
        if (this.list.ContainsKey(dialogueData.Name) == true) return false;

        this.AddChildDeferred(dialogueData, parent.Owner, dialogueData.Name);

        return true;
    }

    public bool TryRemoveChild(string name)
    {
        if (this.list.ContainsKey(name) == false) return false;

        this.RemoveChild(this.list[name]);

        return true;
    }

    public IEnumerator<KeyValuePair<string, DialogueData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}