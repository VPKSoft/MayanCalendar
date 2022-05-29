#region License
/*
MIT License

Copyright(c) 2022 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion


using System.ComponentModel;
// ReSharper disable InconsistentNaming, These really need to keep their case.
// ReSharper disable CommentTypo, People and institution, etc. names. Shouldn't be typos.
// ReSharper disable IdentifierTypo, People and institution, etc. names. Shouldn't be typos.

namespace VPKSoft.MayanCalendar.Enumerations;

/// <summary>
/// An enumeration of different variations of Julian Day Number (JDN)
/// <para/>corrections used for conversion from Mayan calendar date to Gregorian calendar date.
/// </summary>
public enum MayanCorrection : uint
{
    /// <summary>
    /// A "Bowditch" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Bowditch")]
    Bowditch = 394483,

    /// <summary>
    /// A "Willson" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Willson")]
    Willson = 438906,

    /// <summary>
    /// A "Smiley" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Smiley")]
    Smiley = 482699,

    /// <summary>
    /// A "Makemson" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Makemson")]
    Makemson = 489138,

    /// <summary>
    /// A "Modified Spinden" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Modified Spinden")]
    ModifiedSpinden = 489383,

    /// <summary>
    /// A "Spinden" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Spinden")]
    Spinden = 489384,

    /// <summary>
    /// A "Teeple" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Teeple")]
    Teeple = 492622,

    /// <summary>
    /// A "Dinsmoor" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Dinsmoor")]
    Dinsmoor = 497879,

    /// <summary>
    /// A "−4CR" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("−4CR")]
    Minus4CR = 508363,

    /// <summary>
    /// A "−2CR" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("−2CR")]
    Minus2CR = 546323,

    /// <summary>
    /// A "Stock" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Stock")]
    Stock = 556408,

    /// <summary>
    /// A "Goodman" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Goodman")]
    Goodman = 584280,

    /// <summary>
    /// A "Martinez–Hernandez" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Martinez–Hernandez")]
    Martinez_Hernandez = 584281,

    /// <summary>
    /// A "GMT" JDN correction for Gregorian calendar conversion. This is used by default by the MayanDate class.
    /// </summary>
    [Description("GMT")]
    GMT = 584283,

    /// <summary>
    /// A "Modified Thompson 1" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Modified Thompson 1")]
    ModifiedThompson1 = 584284,

    /// <summary>
    /// A "Thompson (Lounsbury)" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Thompson (Lounsbury)")]
    ThompsonOrLounsbury = 584285,

    /// <summary>
    /// A "Pogo" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Pogo")]
    Pogo = 588626,

    /// <summary>
    /// A "+2CR" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("+2CR")]
    Plus2CR = 622243,

    /// <summary>
    /// A "Böhm &amp; Böhm" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Böhm & Böhm")]
    BöhmAndBöhm = 622261,

    /// <summary>
    /// A "Kreichgauer" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Kreichgauer")]
    Kreichgauer = 626927,

    /// <summary>
    /// A "+4CR" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("+4CR")]
    Plus4CR = 660203,

    /// <summary>
    /// A "Fuls, et al." JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Fuls, et al.")]
    Fuls_et_al = 660208,

    /// <summary>
    /// A "Hochleitner" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Hochleitner")]
    Hochleitner = 674265,

    /// <summary>
    /// A "Schultz" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Schultz")]
    Schultz = 677723,

    /// <summary>
    /// A "Escalona–Ramos" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Escalona–Ramos")]
    Escalona_Ramos = 679108,

    /// <summary>
    /// A "Vaillant" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Vaillant")]
    Vaillant = 679183,

    /// <summary>
    /// A "Weitzel" JDN correction for Gregorian calendar conversion.
    /// </summary>
    [Description("Weitzel")]
    Weitzel = 774078
}