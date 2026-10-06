using Mono.Cecil;
using Quintessential;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FalseAether.Textures;
using B = Brimstone.API;
using FA = FalseAether.Atoms;
using FG = FalseAether.Glyphs;
using PartDataWrapper = class_236;
using PartRenderHelper = class_195;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using Vanilla = Brimstone.API.VanillaAtoms;

namespace LibraicElements;

public class LibraParts
{
    public static PartType Infliction, Divinity, Mimickery, Desolation, Hubris;

    public static readonly HexIndex inflictInput = new (0, 0);
    public static readonly HexIndex inflictAnim = new (1, 0);

    public static readonly HexIndex divinityOutput = new (0, 0);
    public static readonly HexIndex divineInA = new (1, 0);
    public static readonly HexIndex divineInB = new (-1, 1);

    public static readonly HexIndex mimicInput = new (0, 0);
    public static readonly HexIndex mimicSource = new (1, 0);

    public static readonly HexIndex desolateA = new (-1, 0);
    public static readonly HexIndex desolateB = new (0, 0);
    public static readonly HexIndex desolateOut = new (1, 0);

    internal static bool AffectFalseAether = false;
    internal enum InquisTypes
    {
        Salt,
        Libraic,
        Carbon,
        Charcoal
    }

    public static void AddGlyphs()
    {
        string InflictDescription;
        if (AffectFalseAether)
        {
            InflictDescription = "The Glyph of Infliction drains charge from an atom of Anymae, returning it to salt, to convert a Libraic atom to an adjacent form.";
        }
        else
        {
            InflictDescription = "The Glyph of Infliction drains charge from an Animismus atom, returning it to salt, to Vitalise or Mortify a Libraic atom.";
        }
        Infliction = B.CreateSimpleGlyph(
            ID: "libraic-elements-infliction",
            name: "Glyph of Infliction",
            description: InflictDescription,
            cost: 15,
            glow: B.GetTexture("textures/parts/Libraic/infliction/glow"),
            stroke: B.GetTexture("textures/parts/Libraic/infliction/stroke"),
            icon: B.GetTexture(),
            hoveredIcon: B.GetTexture(),
            usedHexes: new HexIndex[] { inflictAnim, inflictInput },
            customPermission: "Libraic:Infliction");
        Divinity = B.CreateSimpleGlyph(
            ID: "libraic-elements-divinity",
            name: "Glyph of Divinity",
            description: "The Glyph of Divinity combines two identical Libraic atoms to create one of higher grace, or combines 2 carbon into Equilix.",
            cost: 15,
            glow: B.GetTexture("textures/parts/Libraic/divinity/glow"),
            stroke: B.GetTexture("textures/parts/Libraic/divinity/stroke"),
            icon: B.GetTexture(),
            hoveredIcon: B.GetTexture(),
            usedHexes: new HexIndex[] { divineInA, divineInB, divinityOutput },
            customPermission: "Libraic:Divinity");
        Mimickery = B.CreateSimpleGlyph(
            ID: "libraic-elements-mimickery",
            name: "Glyph of Mimickery",
            description: "The Glyph of Mimickery wastefully converts Equilix into any Libraic atom.",
            cost: 20,
            glow: B.GetTexture("textures/parts/Libraic/mimickery/glow"),
            stroke: B.GetTexture("textures/parts/Libraic/mimickery/stroke"),
            icon: B.GetTexture(),
            hoveredIcon: B.GetTexture(),
            usedHexes: new HexIndex[] { mimicInput, mimicSource },
            customPermission: "Libraic:Mimickery");
        Desolation = B.CreateSimpleGlyph(
            ID: "libraic-elements-desolation",
            name: "Glyph of Desolation",
            description: "The Glyph of Desolation uses Equilix and a Libraic atom to create 3 Libraic atoms, of lower grace than the source Libraic.",
            cost: 25,
            glow: B.GetTexture("textures/parts/Libraic/desolation/glow"),
            stroke: B.GetTexture("textures/parts/Libraic/desolation/stroke"),
            icon: B.GetTexture(),
            hoveredIcon: B.GetTexture(),
            usedHexes: new HexIndex[] { desolateA, desolateB, desolateOut },
            customPermission: "Libraic:Desolation");
        Hubris = B.CreateSimpleGlyph(
            ID: "libraic-elements-hubris",
            name: "Glyph of Hubris",
            description: "The Glyph of Hubris returns a libraic to carbon.",
            cost: 25,
            glow: B.GetTexture("textures/parts/Libraic/hubris/glow"),
            stroke: B.GetTexture("textures/parts/Libraic/hubris/stroke"),
            icon: B.GetTexture(),
            hoveredIcon: B.GetTexture(),
            usedHexes: new HexIndex[] { new (0,0)},
            customPermission: "Libraic:Hubris");

        QApi.AddPartTypeToPanel(Infliction, false);
        QApi.AddPartTypeToPanel(Divinity, false);
        QApi.AddPartTypeToPanel(Mimickery, false);
        QApi.AddPartTypeToPanel(Desolation, false);
        QApi.AddPartTypeToPanel(Hubris, false);

        QApi.AddPartType(Infliction, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.inflict_base, Vector2.Zero, new Vector2(123f, 48f), 0);
            renderer.method_528(Textures.calc_bowl, inflictAnim, Vector2.Zero);
            renderer.method_528(Textures.bond_bowl, inflictInput, Vector2.Zero);
        });

        QApi.AddPartType(Divinity, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.divine_base, Vector2.Zero, new Vector2(123f, 116f), 0);
            B.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time); 
            renderer.method_528(Textures.input_hole, divineInA, Vector2.Zero);
            renderer.method_528(Textures.input_hole, divineInB, Vector2.Zero);
            B.DrawIris(renderer, pdw, divinityOutput, time, pss.field_2743 ? B.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            renderer.method_523(Textures.divine_connectors, Vector2.Zero, new Vector2(123f, 116f), 0);
            
        });

        QApi.AddPartType(Mimickery, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.mimic_base, Vector2.Zero, new Vector2(123f, 48f), 0);
            renderer.method_528(Textures.metal_bowl, mimicInput, Vector2.Zero);
            renderer.method_528(Textures.bond_bowl, mimicSource, Vector2.Zero);
        });

        QApi.AddPartType(Desolation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.desolate_base, Vector2.Zero, new Vector2(125f, 48f), 0);
            B.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            renderer.method_528(Textures.metal_bowl, desolateA, Vector2.Zero);
            renderer.method_528(Textures.bond_bowl, desolateB, Vector2.Zero);
            B.DrawIris(renderer, pdw, desolateOut, time, pss.field_2743 ? B.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
        });
        QApi.AddPartType(Hubris, static (part, pos, editor, renderer) =>
        {
            //renderer.method_523(Textures.hubris_base, Vector2.Zero, new Vector2(41f, 48f), 0);
            renderer.method_528(Textures.bond_bowl, new HexIndex(0,0), Vector2.Zero);
        });

        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase SEB = sim.field_3818;
            List<Part> parts = SEB.method_502().field_3919;
            PartType type = part.method_1159();
            if (type == Infliction)
            {
                if (!sim.FindAtomRelative(part, inflictInput).method_99(out AtomReference inputAtom))
                {
                    return;
                }
                if (!sim.FindAtomRelative(part, inflictAnim).method_99(out AtomReference animAtom))
                {
                    return;
                }
                if (animAtom.field_2280 != Vanilla.mors && animAtom.field_2280 != Vanilla.vitae && !AffectFalseAether)
                {
                    return;
                }
                if (!Helpers.InflictCharge(inputAtom.field_2280, animAtom.field_2280, out AtomType output))
                {
                    return;
                }
                B.ChangeAtom(animAtom, Vanilla.salt);
                B.ChangeAtom(inputAtom, output);
                animAtom.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, animAtom.field_2280, class_238.field_1989.field_81.field_614, 30f);
                inputAtom.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, inputAtom.field_2280, class_238.field_1989.field_81.field_614, 30f);

            }
            else if (type == Divinity)
            {
                if (first)
                {
                    AtomType output;
                    if (!sim.FindAtomRelative(part, divineInA).method_99(out AtomReference divineA))
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, divineInB).method_99(out AtomReference divineB))
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, divinityOutput).method_1085())
                    {
                        return;
                    }
                    if (divineA.field_2281 || divineA.field_2282)
                    {
                        return;
                    }
                    if (divineB.field_2281 || divineB.field_2282)
                    {
                        return;
                    }
                    if (divineA.field_2280 != divineB.field_2280)
                    {
                        return;
                    }
                    if (divineA.field_2280 == LibraAtoms.Carbon)
                    {
                        output = LibraAtoms.Equilix;
                    }
                    else
                    {
                        if (!API.GraceResult.TryGetValue(divineA.field_2280, out output))
                        {
                            if (AffectFalseAether)
                            {
                                bool hasTrueSight = sim.field_3818.method_502().field_3919.Any(x => x.method_1159() == FG.TrueSight); //yoink
                                if (hasTrueSight)
                                {
                                    if (!API.GraceFalseAether.TryGetValue(divineA.field_2280, out output))
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    B.RemoveAtom(divineA);
                    B.RemoveAtom(divineB);
                    B.DrawFallingAtom(SEB, divineA);
                    B.DrawFallingAtom(SEB, divineB);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { output };
                    B.AddSmallCollider(sim, part, divinityOutput);
                }
                else if (pss.field_2743)
                {
                    B.AddAtom(sim, part, divinityOutput, pss.field_2744[0]);
                }
            }
            else if (type == Mimickery)
            {
                if (!sim.FindAtomRelative(part, mimicInput).method_99(out AtomReference target))
                {
                    return;
                }
                if (!sim.FindAtomRelative(part, mimicSource).method_99(out AtomReference source))
                {
                    return;
                }
                if (target.field_2280 != LibraAtoms.Equilix)
                {
                    return;
                }
                if (!API.isLibraicAtom.Contains(source.field_2280)) { return; }
                B.ChangeAtom(target, source.field_2280);
                target.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, target.field_2280, class_238.field_1989.field_81.field_614, 30f);
            }
            else if (type == Desolation)
            {
                if (first)
                {
                    if (!sim.FindAtomRelative(part, desolateA).method_99(out AtomReference target))
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, desolateB).method_99(out AtomReference buffer))
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, desolateOut).method_1085())
                    {
                        return;
                    }
                    if (target.field_2280 != LibraAtoms.Equilix)
                    {
                        return;
                    }
                    if (!API.FallResult.TryGetValue(buffer.field_2280, out AtomType output))
                    {
                        return;
                    }
                    B.ChangeAtom(target, output);
                    B.ChangeAtom(buffer, output);
                    target.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, target.field_2280, class_238.field_1989.field_81.field_614, 30f);
                    buffer.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, buffer.field_2280, class_238.field_1989.field_81.field_614, 30f);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { output };
                    B.AddSmallCollider(sim, part, desolateOut);
                }
                else if (pss.field_2743)
                {
                    B.AddAtom(sim, part, desolateOut, pss.field_2744[0]);
                }
            }
            else if (type == Hubris)
            {
                HexIndex hex = new(0, 0);
                if (!sim.FindAtomRelative(part, hex).method_99(out AtomReference bowl))
                {
                    return;
                }
                if (API.isLibraicAtom.Contains(bowl.field_2280))
                {
                    B.ChangeAtom(bowl, LibraAtoms.Carbon);
                } else if (AffectFalseAether)
                {
                    
                    bool hasTrueSight = sim.field_3818.method_502().field_3919.Any(x => x.method_1159() == FG.TrueSight); //yoink
                    if (hasTrueSight)
                    {
                        if (API.AnimismusCharge.TryGetValue(bowl.field_2280, out _))
                        {
                            B.ChangeAtom(bowl, LibraAtoms.Charcoal);
                        } else
                        {
                            return;
                        }
                    } else
                    {
                        return;
                    }
                } else
                {
                    return;
                }
                bowl.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, bowl.field_2280, class_238.field_1989.field_81.field_614, 30f);
            }
            else if (AffectFalseAether)
            {
                if (type == FG.Inquisition)
                {
                    if (!(sim.FindAtomRelative(part, FG.InquisitionMagisBowl).method_99(out AtomReference HighSubject) && sim.FindAtomRelative(part, FG.InquisitionDaedrumBowl).method_99(out AtomReference LowSubject)))
                    {
                        return;
                    }
                    InquisTypes HighType;
                    InquisTypes LowType;
                    AtomType HighOut;
                    AtomType LowOut;
                    if (HighSubject.field_2280 == Vanilla.salt)
                    {
                        HighType = InquisTypes.Salt;
                    }
                    else if (API.isLibraicAtom.Contains(HighSubject.field_2280))
                    {
                        HighType = InquisTypes.Libraic;
                    }
                    else if (HighSubject.field_2280 == LibraAtoms.Carbon)
                    {
                        HighType = InquisTypes.Carbon;
                    }
                    else if (HighSubject.field_2280 == LibraAtoms.Charcoal)
                    {
                        HighType = InquisTypes.Charcoal;
                    }
                    else
                    {
                        return;
                    }
                    if (LowSubject.field_2280 == Vanilla.salt)
                    {
                        LowType = InquisTypes.Salt;
                    }
                    else if (API.isLibraicAtom.Contains(LowSubject.field_2280))
                    {
                        LowType = InquisTypes.Libraic;
                    }
                    else //carbon can not fall
                    {
                        return;
                    }
                    switch (HighType)
                    {
                        case InquisTypes.Salt:
                            if (LowType == InquisTypes.Salt)
                            {
                                return; //base behaviour
                            }
                            else
                            {
                                HighOut = FA.Magis;
                                API.FallResult.TryGetValue(LowSubject.field_2280, out LowOut);
                            }
                            break;
                        case InquisTypes.Libraic:
                            if (LowType == InquisTypes.Salt)
                            {
                                API.GraceResult.TryGetValue(HighSubject.field_2280, out HighOut);
                                LowOut = FA.Daedrum;
                            }
                            else if (!first)
                            {
                                API.GraceResult.TryGetValue(HighSubject.field_2280, out HighOut);
                                API.FallResult.TryGetValue(LowSubject.field_2280, out LowOut);
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case InquisTypes.Carbon:
                            if (LowType == InquisTypes.Salt)
                            {
                                return;
                            }
                            else if (!first)
                            {
                                API.Orientation.TryGetValue(LowSubject.field_2280, out HighOut);
                                API.FallResult.TryGetValue(LowSubject.field_2280, out LowOut);
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case InquisTypes.Charcoal:
                            if (LowType == InquisTypes.Libraic)
                            {
                                return;
                            }
                            else if (!first)
                            {
                                API.FArentation.TryGetValue(LowSubject.field_2280, out HighOut);
                                API.FallResult.TryGetValue(LowSubject.field_2280, out LowOut);
                            }
                            else
                            {
                                return;
                            }
                            break;
                        default:
                            return; //how did you even
                    }
                    B.ChangeAtom(HighSubject, HighOut);
                    B.ChangeAtom(LowSubject, LowOut);
                    //copy-pasted
                    HighSubject.field_2279.field_2276 = new class_168
                    (
                        SEB,
                        (enum_7)0,
                        (enum_132)0,
                        HighSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );
                    LowSubject.field_2279.field_2276 = new class_168
                    (
                        SEB,
                        (enum_7)0,
                        (enum_132)0,
                        LowSubject.field_2280,
                        class_238.field_1989.field_81.field_611,
                        30
                    );

                }
            }
        });
    }
}
