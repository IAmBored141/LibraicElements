using Quintessential;
using Quintessential.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using B = Brimstone.API;
using FA = FalseAether.Atoms;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using Vanilla = Brimstone.API.VanillaAtoms;

namespace LibraicElements;

public class TheSettings
{
    public static TheSettings Instance => LibraicElements.self.Settings as TheSettings;

    [SettingsLabel("False Aether Integration")]
    public bool FACompat = true;
}
