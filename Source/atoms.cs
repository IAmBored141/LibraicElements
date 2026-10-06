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

public class LibraAtoms
{
    public static AtomType Carbon, Equilix;
    public static AtomType AA, AB, AC, AD;
    public static AtomType BA, BB, BC, BD;
    public static AtomType CA, CB, CC, CD;
    public static AtomType Charcoal;
    public static void AddAtoms()
    {
        Carbon = B.CreateNormalAtom(
            ID: 75,
            modName: "LibraicElements",
            name: "Carbon",
            pathToSymbol: "textures/atoms/Libraic/carbon_symbol",
            pathToDiffuse: "textures/atoms/Libraic/carbon_diffuse",
            pathToShade: "textures/atoms/Libraic/carbon_shade"
        );

        AA = B.CreateNormalAtom(
            ID: 76,
            modName: "LibraicElements",
            name: "Ortus",
            pathToSymbol: "textures/atoms/Libraic/AA_symbol",
            pathToDiffuse: "textures/atoms/Libraic/mors_light_diffuse",
            pathToShade: "textures/atoms/Libraic/mors_light_shade"
        );
        AB = B.CreateNormalAtom(
            ID: 77,
            modName: "LibraicElements",
            name: "Vetero",
            pathToSymbol: "textures/atoms/Libraic/AB_symbol",
            pathToDiffuse: "textures/atoms/vitae_diffuse",
            pathToShade: "textures/atoms/vitae_shade"
        );

        AC = B.CreateNormalAtom(
            ID: 78,
            modName: "LibraicElements",
            name: "Serus",
            pathToSymbol: "textures/atoms/Libraic/AC_symbol",
            pathToDiffuse: "textures/atoms/Libraic/vitae_dark_diffuse",
            pathToShade: "textures/atoms/Libraic/vitae_dark_shade"
        );
        AD = B.CreateNormalAtom(
            ID: 79,
            modName: "LibraicElements",
            name: "Libitina",
            pathToSymbol: "textures/atoms/Libraic/AD_symbol",
            pathToDiffuse: "textures/atoms/mors_diffuse",
            pathToShade: "textures/atoms/mors_shade"
        );
        BA = B.CreateNormalAtom(
            ID: 80,
            modName: "LibraicElements",
            name: "Aurora",
            pathToSymbol: "textures/atoms/Libraic/BA_symbol",
            pathToDiffuse: "textures/atoms/Libraic/mors_light_diffuse",
            pathToShade: "textures/atoms/Libraic/mors_light_shade"
        );
        BB = B.CreateNormalAtom(
            ID: 81,
            modName: "LibraicElements",
            name: "Lumen",
            pathToSymbol: "textures/atoms/Libraic/BB_symbol",
            pathToDiffuse: "textures/atoms/vitae_diffuse",
            pathToShade: "textures/atoms/vitae_shade"
        );
        BC = B.CreateNormalAtom(
            ID: 82,
            modName: "LibraicElements",
            name: "Umbra",
            pathToSymbol: "textures/atoms/Libraic/BC_symbol",
            pathToDiffuse: "textures/atoms/Libraic/vitae_dark_diffuse",
            pathToShade: "textures/atoms/Libraic/vitae_dark_shade"
        );
        BD = B.CreateNormalAtom(
            ID: 83,
            modName: "LibraicElements",
            name: "Nox",
            pathToSymbol: "textures/atoms/Libraic/BD_symbol",
            pathToDiffuse: "textures/atoms/mors_diffuse",
            pathToShade: "textures/atoms/mors_shade"
        );
        CA = B.CreateNormalAtom(
            ID: 84,
            modName: "LibraicElements",
            name: "Septrino",
            pathToSymbol: "textures/atoms/Libraic/CA_symbol",
            pathToDiffuse: "textures/atoms/Libraic/mors_light_diffuse",
            pathToShade: "textures/atoms/Libraic/mors_light_shade"
        );
        CB = B.CreateNormalAtom(
            ID: 85,
            modName: "LibraicElements",
            name: "Oriens",
            pathToSymbol: "textures/atoms/Libraic/CB_symbol",
            pathToDiffuse: "textures/atoms/vitae_diffuse",
            pathToShade: "textures/atoms/vitae_shade"
        );
        CC = B.CreateNormalAtom(
            ID: 86,
            modName: "LibraicElements",
            name: "Meridies",
            pathToSymbol: "textures/atoms/Libraic/CC_symbol",
            pathToDiffuse: "textures/atoms/Libraic/vitae_dark_diffuse",
            pathToShade: "textures/atoms/Libraic/vitae_dark_shade"
        );
        CD = B.CreateNormalAtom(
            ID: 87,
            modName: "LibraicElements",
            name: "Occidens",
            pathToSymbol: "textures/atoms/Libraic/CD_symbol",
            pathToDiffuse: "textures/atoms/mors_diffuse",
            pathToShade: "textures/atoms/mors_shade"
        );
        Equilix = B.CreateQuintessenceAtom(
            ID: 88,
            modName: "LibraicElements",
            name: "Equilix",
            pathToSymbol: "textures/atoms/Libraic/equilix/symbol",
            pathToBase: "textures/atoms/Libraic/equilix/base",
            pathToColors: "textures/atoms/Libraic/equilix/colours",
            pathToRimlight: "textures/atoms/Libraic/equilix/base2",
            pathToShadow: "textures/atoms/Libraic/equilix/shadow"
        );
        Charcoal = B.CreateNormalAtom(
            ID: 74,
            modName: "LibraicElementsXFalseAether",
            name: "Charcoal",
            pathToSymbol: "textures/atoms/Libraic/charcoal_symbol",
            pathToDiffuse: "textures/atoms/Libraic/charcoal_diffuse",
            pathToShade: "textures/atoms/Libraic/charcoal_shade"
        );

        QApi.AddAtomType(Equilix);
        QApi.AddAtomType(Carbon);
        if (B.IsModLoaded("FalseAether"))
        {
            QApi.AddAtomType(Charcoal);
        }
        QApi.AddAtomType(AA);
        QApi.AddAtomType(AB);
        QApi.AddAtomType(AC);
        QApi.AddAtomType(AD);
        QApi.AddAtomType(BA);
        QApi.AddAtomType(BB);
        QApi.AddAtomType(BC);
        QApi.AddAtomType(BD);
        QApi.AddAtomType(CA);
        QApi.AddAtomType(CB);
        QApi.AddAtomType(CC);
        QApi.AddAtomType(CD);


    }
}
