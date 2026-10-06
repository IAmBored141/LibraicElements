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
using System.Text.RegularExpressions;

namespace LibraicElements;

public class Helpers
{
    public static bool InflictCharge(AtomType target, AtomType source, out AtomType output)
    {
        output = target;
        AtomType medium;
        if (!API.AnimismusCharge.TryGetValue(source, out Tuple<int,int> value))
        {
            return false;
        }
        switch (value.Item1)
        {
            case 1:
                if (!API.VitaliseResult.TryGetValue(target, out medium)) {
                return false;
                }
                break;
            case -1:
                if (!API.MortifyResult.TryGetValue(target, out medium))
                {
                    return false;
                }
                break;
            default:
                medium = target;
                break;
        }
        switch (value.Item2)
        {
            case 1:
                if (!API.GraceResult.TryGetValue(medium, out output))
                {
                    return false;
                }
                break;
            case -1:
                if (!API.FallResult.TryGetValue(medium, out output))
                {
                    return false;
                }
                break;
            default:
                output = medium;
                break;
        }
        if (output == target) //nothing happened
        {
            return false;
        } else
        {
            return true;
        }

    }
}
