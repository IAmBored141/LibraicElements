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
using FA = FalseAether.Atoms;
using Vanilla = Brimstone.API.VanillaAtoms;

namespace LibraicElements;

public class API
{
    // there's a very clear better way to do this
    // just store orientation and ring layer
    // i, however, am too lazy to change it at this point
    public static readonly Dictionary<AtomType, AtomType> VitaliseResult = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> MortifyResult = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> GraceResult = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> FallResult = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> Orientation = new Dictionary<AtomType, AtomType>();

    public static readonly Dictionary<AtomType, Tuple<int, int>> AnimismusCharge = new Dictionary<AtomType, Tuple<int, int>>();

    public static readonly Dictionary<AtomType, AtomType> GraceFalseAether = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> FallFalseAether = new Dictionary<AtomType, AtomType>();
    public static readonly Dictionary<AtomType, AtomType> FArentation = new Dictionary<AtomType, AtomType>();


    public static readonly List<AtomType> isLibraicAtom = new List<AtomType>();

    public static void AddVitaMortiResult(AtomType A, AtomType B) //for quicker to fill out
    {
        VitaliseResult.Add(A, B);
        MortifyResult.Add(B, A);
    }

    public static void AddGraceFallResult(AtomType A, AtomType B) //for quicker to fill out
    {
        GraceResult.Add(A, B);
        FallResult.Add(B, A);
    }
    public static void LoadData()
    {
        AddVitaMortiResult(LibraAtoms.AA, LibraAtoms.AB);
        AddVitaMortiResult(LibraAtoms.AB, LibraAtoms.AC);
        AddVitaMortiResult(LibraAtoms.AC, LibraAtoms.AD);
        AddVitaMortiResult(LibraAtoms.AD, LibraAtoms.AA);
        AddVitaMortiResult(LibraAtoms.BA, LibraAtoms.BB);
        AddVitaMortiResult(LibraAtoms.BB, LibraAtoms.BC);
        AddVitaMortiResult(LibraAtoms.BC, LibraAtoms.BD);
        AddVitaMortiResult(LibraAtoms.BD, LibraAtoms.BA);
        AddVitaMortiResult(LibraAtoms.CA, LibraAtoms.CB);
        AddVitaMortiResult(LibraAtoms.CB, LibraAtoms.CC);
        AddVitaMortiResult(LibraAtoms.CC, LibraAtoms.CD);
        AddVitaMortiResult(LibraAtoms.CD, LibraAtoms.CA);

        AddGraceFallResult(LibraAtoms.AA, LibraAtoms.BA);
        AddGraceFallResult(LibraAtoms.AB, LibraAtoms.BB);
        AddGraceFallResult(LibraAtoms.AC, LibraAtoms.BC);
        AddGraceFallResult(LibraAtoms.AD, LibraAtoms.BD);
        AddGraceFallResult(LibraAtoms.BA, LibraAtoms.CA);
        AddGraceFallResult(LibraAtoms.BB, LibraAtoms.CB);
        AddGraceFallResult(LibraAtoms.BC, LibraAtoms.CC);
        AddGraceFallResult(LibraAtoms.BD, LibraAtoms.CD);
        GraceResult.Add(LibraAtoms.CA, LibraAtoms.Carbon);
        GraceResult.Add(LibraAtoms.CB, LibraAtoms.Carbon);
        GraceResult.Add(LibraAtoms.CC, LibraAtoms.Carbon);
        GraceResult.Add(LibraAtoms.CD, LibraAtoms.Carbon);

        AddGraceFallResult(LibraAtoms.Carbon, LibraAtoms.Carbon);

        FallResult.Add(LibraAtoms.AA, LibraAtoms.Carbon);
        FallResult.Add(LibraAtoms.AB, LibraAtoms.Carbon);
        FallResult.Add(LibraAtoms.AC, LibraAtoms.Carbon);
        FallResult.Add(LibraAtoms.AD, LibraAtoms.Carbon);

        isLibraicAtom.Add(LibraAtoms.AA);
        isLibraicAtom.Add(LibraAtoms.AB);
        isLibraicAtom.Add(LibraAtoms.AC);
        isLibraicAtom.Add(LibraAtoms.AD);
        isLibraicAtom.Add(LibraAtoms.BA);
        isLibraicAtom.Add(LibraAtoms.BB);
        isLibraicAtom.Add(LibraAtoms.BC);
        isLibraicAtom.Add(LibraAtoms.BD);
        isLibraicAtom.Add(LibraAtoms.CA);
        isLibraicAtom.Add(LibraAtoms.CB);
        isLibraicAtom.Add(LibraAtoms.CC);
        isLibraicAtom.Add(LibraAtoms.CD);

        Orientation.Add(LibraAtoms.AA, LibraAtoms.AA);
        Orientation.Add(LibraAtoms.AB, LibraAtoms.AB);
        Orientation.Add(LibraAtoms.AC, LibraAtoms.AC);
        Orientation.Add(LibraAtoms.AD, LibraAtoms.AD);
        Orientation.Add(LibraAtoms.BA, LibraAtoms.AA);
        Orientation.Add(LibraAtoms.BB, LibraAtoms.AB);
        Orientation.Add(LibraAtoms.BC, LibraAtoms.AC);
        Orientation.Add(LibraAtoms.BD, LibraAtoms.AD);
        Orientation.Add(LibraAtoms.CA, LibraAtoms.AA);
        Orientation.Add(LibraAtoms.CB, LibraAtoms.AB);
        Orientation.Add(LibraAtoms.CC, LibraAtoms.AC);
        Orientation.Add(LibraAtoms.CD, LibraAtoms.AD);
        
        AnimismusCharge.Add(Vanilla.vitae, new(1, 0));
        AnimismusCharge.Add(Vanilla.mors, new(-1, 0));

        if (B.IsModLoaded("FalseAether"))
        {
            GraceFalseAether.Add(Vanilla.vitae, FA.Inops);
            GraceFalseAether.Add(Vanilla.salt, FA.Illustra);
            GraceFalseAether.Add(Vanilla.mors, FA.Capax);
            GraceFalseAether.Add(FA.Aegero, Vanilla.mors);
            GraceFalseAether.Add(FA.Turpis, Vanilla.salt);
            GraceFalseAether.Add(FA.Phasmus, Vanilla.vitae);
            GraceFalseAether.Add(FA.Inops, LibraAtoms.Charcoal);
            GraceFalseAether.Add(FA.Illustra, LibraAtoms.Charcoal);
            GraceFalseAether.Add(FA.Capax, LibraAtoms.Charcoal);

            FallFalseAether.Add(Vanilla.vitae, FA.Aegero);
            FallFalseAether.Add(Vanilla.salt, FA.Turpis);
            FallFalseAether.Add(Vanilla.mors, FA.Phasmus);
            FallFalseAether.Add(FA.Inops, Vanilla.mors);
            FallFalseAether.Add(FA.Illustra, Vanilla.salt);
            FallFalseAether.Add(FA.Capax, Vanilla.vitae);
            FallFalseAether.Add(FA.Aegero, LibraAtoms.Charcoal);
            FallFalseAether.Add(FA.Turpis, LibraAtoms.Charcoal);
            FallFalseAether.Add(FA.Phasmus, LibraAtoms.Charcoal);

            AnimismusCharge.Add(FA.Inops, new(1, 1));
            AnimismusCharge.Add(FA.Illustra, new(0, 1));
            AnimismusCharge.Add(FA.Capax, new(-1, 1));
            AnimismusCharge.Add(FA.Aegero, new(1, -1));
            AnimismusCharge.Add(FA.Turpis, new(0, -1));
            AnimismusCharge.Add(FA.Phasmus, new(-1, -1));

            FArentation.Add(FA.Aegero, FA.Aegero);
            FArentation.Add(FA.Turpis, FA.Turpis);
            FArentation.Add(FA.Phasmus, FA.Phasmus);
            FArentation.Add(Vanilla.vitae, FA.Aegero);
            FArentation.Add(Vanilla.salt, FA.Turpis);
            FArentation.Add(Vanilla.mors, FA.Phasmus);
            FArentation.Add(FA.Inops, FA.Aegero);
            FArentation.Add(FA.Illustra, FA.Turpis);
            FArentation.Add(FA.Capax, FA.Phasmus);
        }
    }
}
