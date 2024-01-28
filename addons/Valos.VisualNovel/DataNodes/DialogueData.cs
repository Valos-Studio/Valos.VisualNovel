﻿using Godot;

namespace Valos.VisualNovel.DataNodes;

[Tool]
[GodotClassName(nameof(DialogueData))]
public partial class DialogueData : DataNode
{
    [Export()] public PackedScene Scene { get; set; }
}