using Quintessential;
using System;
using System.Runtime;
using B = Brimstone.API;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using FalseAether;

namespace LibraicElements;

public class LibraicElements : QuintessentialMod
{


    public static QuintessentialMod self;
    public override Type SettingsType => typeof(TheSettings);

    private static readonly string logPrefix = "Libraic Elements: ";
    private bool FalseAetherWasLoaded = false;

    internal bool AffectFalseAether = false;
    internal bool HasLoaded = false;
    internal LocString InquisOriginalDesc;
    
    public override void Load()
    {
        self = this;
        Settings = new TheSettings();

        Logger.Log(logPrefix + "I have awoken.");
        if (B.IsModLoaded("FalseAether"))
        {
            Logger.Log(logPrefix + "You wish to play with divinity, to defy the natural order? So be it.");
            Logger.Log("(Libraic Elements will interact with False Aether)");
            FalseAetherWasLoaded = true;
            AffectFalseAether = true;
        }
    }
    
    public override void ApplySettings()
    {
        base.ApplySettings();
        TheSettings THE = (TheSettings)Settings;
        LibraParts.AffectFalseAether = THE.FACompat && FalseAetherWasLoaded;
        if (HasLoaded) //just in case
        {
            if (FalseAetherWasLoaded) {
                if (THE.FACompat)
                {
                    FalseAether.Glyphs.Inquisition.field_1530 = class_134.method_253("The glyph of inquisition graces one salt, and makes the other fall.\n_You truly wish to toy with divinity? If you must, but know, everything has a cost._\nThe Glyph of Inquisition can also grace and corrupt Libraic atoms, and grace Carbon should a Libraic fall in its place.", string.Empty);
                } else
                {
                    FalseAether.Glyphs.Inquisition.field_1530 = InquisOriginalDesc;
                }
            }
            if (THE.FACompat)
            {
                LibraParts.Infliction.field_1530 = class_134.method_253("The Glyph of Infliction drains charge from an atom of Anymae, returning it to salt, to convert a Libraic atom to an adjacent form.", string.Empty);
            }
            else
            {
                LibraParts.Infliction.field_1530 = class_134.method_253("The Glyph of Infliction drains charge from an Animismus atom, returning it to salt, to Vitalise or Mortify a Libraic atom.", string.Empty);
            }
        }
    }

    public override void PostLoad()
    {

    }

    public override void LoadPuzzleContent() 
    {
        Logger.Log(logPrefix + "Ashes to ashes...");
        LibraAtoms.AddAtoms();
        LibraParts.AddGlyphs();
        API.LoadData();
        QApi.AddPuzzlePermission("Libraic:Infliction", "Glyph of Infliction", "Libraic Elements");
        QApi.AddPuzzlePermission("Libraic:Divinity", "Glyph of Divininty", "Libraic Elements");
        QApi.AddPuzzlePermission("Libraic:Mimickery", "Glyph of Mimickery", "Libraic Elements");
        QApi.AddPuzzlePermission("Libraic:Desolation", "Glyph of Desolation", "Libraic Elements");
        QApi.AddPuzzlePermission("Libraic:Hubris", "Glyph of Hubris", "Libraic Elements");
        if (B.IsModLoaded("FalseAether"))
        {
            InquisOriginalDesc = FalseAether.Glyphs.Inquisition.field_1530;
            FalseAether.Glyphs.Inquisition.field_1530 = class_134.method_253("The glyph of inquisition graces one salt, and makes the other fall.\n_You truly wish to toy with divinity? If you must, but know, everything has a cost._\nThe Glyph of Inquisition can also grace and corrupt Libraic atoms, and grace Carbon should a Libraic fall in its place.", string.Empty);
        }
        Logger.Log(logPrefix + "...Dust to dust.");
        HasLoaded = true;
    }
    public override void Unload()
    {
        if (FalseAetherWasLoaded)
        {
            Logger.Log(logPrefix + "And the heavens shall rest, 'till you return.");
        } else
        {
            Logger.Log(logPrefix + "Farewell.");
        }
    }
}