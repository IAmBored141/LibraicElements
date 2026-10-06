using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quintessential;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using B = Brimstone.API;

namespace LibraicElements;

public class Textures
{
    public static Texture inflict_base = B.GetTexture("textures/parts/Libraic/infliction/base");
    public static Texture divine_base = B.GetTexture("textures/parts/Libraic/divinity/base");
    public static Texture mimic_base = B.GetTexture("textures/parts/Libraic/mimickery/base");
    public static Texture desolate_base = B.GetTexture("textures/parts/Libraic/desolation/base");

    public static Texture divine_connectors = B.GetTexture("textures/parts/Libraic/divinity/connectors");

    public static Texture input_hole = B.GetTexture("textures/parts/projection_glyph/quicksilver_input");
    public static Texture metal_bowl = B.GetTexture("textures/parts/projection_glyph/metal_bowl");
    public static Texture calc_bowl = B.GetTexture("textures/parts/calcinator_bowl");
    public static Texture bond_bowl = B.GetTexture("textures/parts/bonder_ring");

    public static Texture dupe_bond = B.GetTexture("textures/parts/duplicator_bond");

    public static Texture proj_base = B.GetTexture("textures/parts/projection_glyph/base");
    public static Texture proj_bond = B.GetTexture("textures/parts/projection_glyph/bond");

    public static Texture proj_gloss_mask = B.GetTexture("textures/parts/projection_glyph/gloss_mask");
    public static Texture gloss = B.GetTexture("textures/parts/input_gloss");
}
