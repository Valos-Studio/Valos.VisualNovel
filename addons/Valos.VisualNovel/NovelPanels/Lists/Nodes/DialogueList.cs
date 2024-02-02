using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
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

    public DialogueList()
    {
        this.list = new Dictionary<string, DialogueData>();
    }

    public bool TryAdd(DialogueData dialogueData)
    {
        if (this.list.ContainsKey(dialogueData.NodeName) == true) return false;

        this.list.Add(dialogueData.NodeName, dialogueData);
        
        this.AddChildDeferred(dialogueData, dialogueData.NodeName);

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