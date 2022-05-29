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

using System;
using System.Collections.Generic;
using VPKSoft.MayanCalendar.Classes;
using VPKSoft.MayanCalendar.Enumerations;
using VPKSoft.MayanCalendar.Helpers;

namespace VPKSoft.MayanCalendar;

/// <summary>
/// A class for Mayan/Gregorian calendar conversions.
/// </summary>
public class MayanDate
{
    /// <summary>
    /// Mayan Tzolk'in calendar day names. The "Ajaw" is the last one but for convinience the "Ajaw" is set as first day name.
    /// </summary>
    private static readonly string[] tzolkinDayNames = { "Ajaw", "Imix'", "Ik'", "Ak'b'al", "K'an", "Chikchan", "Kimi", "Manik'", "Lamat", "Muluk", "Ok", "Chuwen", "Eb'", "B'en", "Ix", "Men", "K'ib'", "Kab'an", "Etz'nab'", "Kawak" };

    /// <summary>
    /// Mayan Haab' month names in their occurrence order.
    /// </summary>
    private static readonly string[] haabMonthNames = { "Pop", "Wo'", "Sip", "Sotz'", "Sek", "Xul", "Yaxk'in'", "Mol", "Ch'en", "Yax", "Sak'", "Keh", "Mak", "K'ank'in", "Muwan'", "Pax", "K'ayab", "Kumk'u", "Wayeb'" };

    /// <summary>
    /// The names of the date parts of the Mayan long count in rising order.
    /// </summary>
    private static readonly string[] datePartNames = { "K'in", "Winal", "Uinal", "Tun", "K'atun", "B'ak'tun", "Piktun", "Kalabtun", "K'inchiltun", "Alautun" };

    /// <summary>
    /// Gets a list of Mayan Tzolk'in calendar day names.
    /// </summary>
    public static List<string> TzolkinDayNames
    {
        get
        {
            var nameArray = new List<string>();
            for (var i = 1; i < tzolkinDayNames.Length; i++)
            {
                nameArray.Add(tzolkinDayNames[i]);
            }
            nameArray.Add(tzolkinDayNames[0]);
            return nameArray;
        }
    }

    /// <summary>
    /// Gets a list of Mayan Haab' month names.
    /// </summary>
    public static List<string> HaabMonthNames => new(haabMonthNames);

    /// <summary>
    /// Gets a list of date part names.
    /// </summary>
    /// <param name="uinal">Whether to use Winal or Uinal as the name of the day part name 1.</param>
    /// <returns>A list of date part names.</returns>
    public static List<string> DatePartNames(bool uinal = false)
    {
        var names = new List<string>();
        for (var i = 0; i < datePartNames.Length; i++)
        {
            if (i == 1 && uinal)
            {
                i++;
                continue;
            }
            names.Add(datePartNames[i]);
        }
        return names;
    }

    /// <summary>
    /// Integers to hold the Mayan long count calendar date parts.
    /// </summary>
    private int alautun, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin;

    /// <summary>
    /// A Julian day correction to be used for Gregorian to Mayan to Gregorian conversion.
    /// </summary>
    private double cJDNMayaStart = 584283; // Julian day GMT correction

    /// <summary>
    /// Gets a Juliand Day Number (JDN) correction name that is currently used.
    /// </summary>
    public string JDNCorrectionName
    {
        get
        {
            try
            {
                return ((MayanCorrection)((int)cJDNMayaStart)).GetAttributeDescription();
            }
            catch
            {
                return string.Format(System.Globalization.CultureInfo.InvariantCulture, "Custom ({0:F1})", cJDNMayaStart);
            }
        }
    }

    /// <summary>
    /// Sets a Julian day correction to be used for Gregorian to Mayan to Gregorian conversion.
    /// </summary>
    /// <param name="correction">A MayanCorrection enumeration which includes all JDN corrections from Wikipedia (dated 08.04.2016).</param>
    public void SetJDNCorrection(MayanCorrection correction)
    {
        cJDNMayaStart = Math.Truncate((double)correction);
    }

    /// <summary>
    /// Sets a Julian day correction to be used for Gregorian to Mayan to Gregorian conversion.
    /// </summary>
    /// <param name="correction">An amount of Julian days (JDN) to be used for Gregorian to Mayan to Gregorian conversion.</param>
    public void SetJDNCorrection(double correction)
    {
        cJDNMayaStart = Math.Truncate(correction);
    }

    /// <summary>
    /// An empty constructor for to be used to enable "new MayanDate { foo = bar }" syntax..
    /// </summary>
    public MayanDate()
    {
        // an empty constructor to enable "new MayanDate { foo = bar }" syntax
    }

    /// <summary>
    /// Gets an instance of MayanDate with a given Julian day number (JDN).
    /// </summary>
    /// <param name="days">A number of days (JDN) to calculate the MayanDate instance from.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>An instance of MayanDate with a given Julian day number (JDN).</returns>
    public static MayanDate FromDayCount(double days, MayanCorrection mc)
    {
        return FromDayCount(days, (double)mc);
    }

    /// <summary>
    /// Gets an instance of MayanDate with a given Julian day number (JDN).
    /// </summary>
    /// <param name="days">A number of days (JDN) to calculate the MayanDate instance from.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>An instance of MayanDate with a given Julian day number (JDN).</returns>
    public static MayanDate FromDayCount(double days, double JDNCorrection)
    {
        var JDN = days;
        if (JDN < 0)
        {
            return GetBeforeTime();
        }

        var alautun = JDN / 23040000000.0;
        var daysLeft = JDN - Math.Floor(alautun) * 23040000000.0;

        var kinchiltun = daysLeft / 1152000000.0;
        daysLeft = daysLeft - Math.Floor(kinchiltun) * 1152000000.0;

        var kalabtun = daysLeft / 57600000.0;
        daysLeft = daysLeft - Math.Floor(kalabtun) * 57600000.0;

        var pictun = daysLeft / 2880000.0;
        daysLeft = daysLeft - Math.Floor(pictun) * 2880000.0;
        var baktun = daysLeft / 144000.0;
        daysLeft = daysLeft - Math.Floor(baktun) * 144000.0;
        var katun = daysLeft / 7200.0;
        daysLeft = daysLeft - Math.Floor(katun) * 7200.0;
        var tun = daysLeft / 360.0;
        daysLeft = daysLeft - Math.Floor(tun) * 360.0;
        var winal = daysLeft / 20.0;
        daysLeft = daysLeft - Math.Floor(winal) * 20.0;
        var kin = Math.Floor(daysLeft);

        var md = new
            MayanDate
        {
            Alautun = (int)alautun,
            Kinchiltun = (int)kinchiltun,
            Kalabtun = (int)kalabtun,
            Piktun = (int)pictun,
            Baktun = (int)baktun,
            Katun = (int)katun,
            Tun = (int)tun,
            Winal = (int)winal,
            Uinal = (int)winal,
            Kin = (int)kin,
        };

        md.SetJDNCorrection(JDNCorrection);

        return md;
    }


    /// <summary>
    /// Gets an instance of MayanDate with a given Julian day number (JDN).
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="days">A number of days (JDN) to calculate the MayanDate instance from.</param>
    /// <returns>An instance of MayanDate with a given Julian day number (JDN).</returns>
    public static MayanDate FromDayCount(double days)
    {
        return FromDayCount(days, MayanCorrection.GMT);
    }

    /// <summary>
    /// Gets a Mayan date as a string representation with largest number being the B'ak'tun separated by dots.
    /// </summary>
    /// <returns>Returns a Mayan date as a string representation with largest number being the B'ak'tun separated by dots.</returns>
    public override string ToString()
    {
        return Baktun + "." + Katun + "." + Tun + "." + Winal + "." + Kin;
    }

    /// <summary>
    /// Gets a Mayan date as a string representation with largest number being the Alautun separated by dots.
    /// <para/>Do note that such date representation propably lasts longer than the universe.
    /// </summary>
    /// <returns>Gets a Mayan date as a string representation with largest number being the Alautun separated by dots.</returns>
    public string ToStringLong()
    {
        return Alautun + "." + Kinchiltun + "." + Piktun + "." + Kalabtun + "." + Baktun + "." + Katun + "." + Tun + "." + Winal + "." + Kin;

    }

    #region NumericCostructors
    /// <summary>
    /// Sets the Mayan date with given integer numbers. A helper method for all the numeric constructors.
    /// </summary>
    /// <param name="alautun">The Alautun number of the date.</param>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    internal void SetMayanDate(int alautun, int kinchiltun, int kalabtun, int piktun, int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        Alautun = alautun;
        Kinchiltun = kinchiltun;
        Piktun = piktun;
        Kalabtun = kalabtun;
        Baktun = baktun;
        Katun = katun;
        Tun = tun;
        Winal = winal;
        Kin = kin;
        SetJDNCorrection(JDNCorrection);
    }

    /// <summary>
    /// Sets the Mayan date with given integer numbers. A helper method for all the numeric constructors.
    /// </summary>
    /// <param name="alautun">The Alautun number of the date.</param>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    internal void SetMayanDate(int alautun, int kinchiltun, int kalabtun, int piktun, int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        Alautun = alautun;
        Kinchiltun = kinchiltun;
        Piktun = piktun;
        Kalabtun = kalabtun;
        Baktun = baktun;
        Katun = katun;
        Tun = tun;
        Winal = winal;
        Kin = kin;
        SetJDNCorrection(mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with B'ak'tun.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    public MayanDate(int baktun, int katun, int tun, int winal, int kin)
    {
        SetMayanDate(0, 0, 0, 0, baktun, katun, tun, winal, kin, MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Kalabtun.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    public MayanDate(int kalabtun, int baktun, int katun, int tun, int winal, int kin)
    {
        SetMayanDate(0, 0, 0, kalabtun, baktun, katun, tun, winal, kin, MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Piktun.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    public MayanDate(int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin)
    {
        SetMayanDate(0, 0, piktun, kalabtun, baktun, katun, tun, winal, kin, MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using largest number of the long count with K'inchiltun.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    public MayanDate(int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin)
    {
        SetMayanDate(0, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Alautun.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="alautun">The Alautun number of the date.</param>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    public MayanDate(int alautun, int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin)
    {
        SetMayanDate(alautun, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using largest number of the long count with B'ak'tun.
    /// </summary>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        SetMayanDate(0, 0, 0, 0, baktun, katun, tun, winal, kin, mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Kalabtun.
    /// </summary>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int kalabtun, int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        SetMayanDate(0, 0, 0, kalabtun, baktun, katun, tun, winal, kin, mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Piktun.
    /// </summary>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        SetMayanDate(0, 0, piktun, kalabtun, baktun, katun, tun, winal, kin, mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with K'inchiltun.
    /// </summary>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        SetMayanDate(0, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Alautun.
    /// </summary>
    /// <param name="alautun">The Alautun number of the date.</param>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int alautun, int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, MayanCorrection mc)
    {
        SetMayanDate(alautun, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, mc);
    }

    /// <summary>
    /// A constructor using largest number of the long count with B'ak'tun.
    /// </summary>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        SetMayanDate(0, 0, 0, 0, baktun, katun, tun, winal, kin, JDNCorrection);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Kalabtun.
    /// </summary>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int kalabtun, int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        SetMayanDate(0, 0, 0, kalabtun, baktun, katun, tun, winal, kin, JDNCorrection);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Piktun.
    /// </summary>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        SetMayanDate(0, 0, piktun, kalabtun, baktun, katun, tun, winal, kin, JDNCorrection);
    }

    /// <summary>
    /// A constructor using largest number of the long count with K'inchiltun.
    /// </summary>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        SetMayanDate(0, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, JDNCorrection);
    }

    /// <summary>
    /// A constructor using largest number of the long count with Alautun.
    /// </summary>
    /// <param name="alautun">The Alautun number of the date.</param>
    /// <param name="kinchiltun">The K'inchiltun number of the date.</param>
    /// <param name="piktun">The Piktun number of the date.</param>
    /// <param name="kalabtun">The Kalabtun number of the date.</param>
    /// <param name="baktun">The B'ak'tun number of the date.</param>
    /// <param name="katun">The K'atun number of the date.</param>
    /// <param name="tun">The Tun number of the date.</param>
    /// <param name="winal">The Winal/Uinal number of the date.</param>
    /// <param name="kin">The K'in number of the date.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(int alautun, int kinchiltun, int piktun, int kalabtun, int baktun, int katun, int tun, int winal, int kin, double JDNCorrection)
    {
        SetMayanDate(alautun, kinchiltun, piktun, kalabtun, baktun, katun, tun, winal, kin, JDNCorrection);
    }
    #endregion

    /// <summary>
    /// A constructor using a string representation of a date.
    /// <para/>At least B'ak'tun to K'in numbers must be given.
    /// </summary>
    /// <param name="date">A string representation of a Mayan date (e.g. 9.12.2.0.16).</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(string date, MayanCorrection mc)
    {
        StringDateHelper(date, (double)mc);
    }

    /// <summary>
    /// A constructor using a string representation of a date.
    /// <para/>At least B'ak'tun to K'in numbers must be given.
    /// </summary>
    /// <param name="date">A string representation of a Mayan date (e.g. 9.12.2.0.16).
    /// <para/>A GMT JDN correction is used as correction to the date.</param>
    public MayanDate(string date)
    {
        StringDateHelper(date, (double)MayanCorrection.GMT);
    }

    /// <summary>
    /// A constructor using a string representation of a date.
    /// <para/>At least B'ak'tun to K'in numbers must be given.
    /// </summary>
    /// <param name="date">A string representation of a Mayan date (e.g. 9.12.2.0.16).</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    public MayanDate(string date, double JDNCorrection)
    {
        StringDateHelper(date, JDNCorrection);
    }

    /// <summary>
    /// A base method for all the string based constructors.
    /// </summary>
    /// <param name="date">A string representation of a Mayan date (e.g. 9.12.2.0.16).</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    internal void StringDateHelper(string date, double JDNCorrection)
    {
        if (date.Split('.').Length < 5)
        {
            throw new MayanDateException("A date string must consist of at least 5 numbers.");
        }
        while (date.Split('.').Length < 9)
        {
            date = "0." + date;
        }
        try
        {
            var dateParts = date.Split('.');
            SetMayanDate(int.Parse(dateParts[0]),
                         int.Parse(dateParts[1]),
                         int.Parse(dateParts[2]),
                         int.Parse(dateParts[3]),
                         int.Parse(dateParts[4]),
                         int.Parse(dateParts[5]),
                         int.Parse(dateParts[6]),
                         int.Parse(dateParts[7]),
                         int.Parse(dateParts[8]), JDNCorrection);
        }
        catch
        {
            throw new MayanDateException("Invalid date string ('" + date + "').");
        }
        SetJDNCorrection(JDNCorrection);
    }


    /// <summary>
    /// Constructs a MayanDate instance from a given Gregorian calendar date.
    /// </summary>
    /// <param name="year">A year in the Gregorian calendar.</param>
    /// <param name="month">A month in the Gregorian calendar.</param>
    /// <param name="day">A day in the Gregorian calendar.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>A MayanDate class instance constructed from a given Gregorian calendar date.</returns>
    public static MayanDate FromYearMonthDay(int year, int month, int day, MayanCorrection mc)
    {
        var days = (int)(JDNg(year, month, day) - (double)mc);
        var md = FromDayCount(days);
        md.SetJDNCorrection((double)mc);
        return md;
    }

    /// <summary>
    /// Constructs a MayanDate instance from a given Gregorian calendar date.
    /// </summary>
    /// <param name="year">A year in the Gregorian calendar.</param>
    /// <param name="month">A month in the Gregorian calendar.</param>
    /// <param name="day">A day in the Gregorian calendar.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>A MayanDate class instance constructed from a given Gregorian calendar date.</returns>
    public static MayanDate FromYearMonthDay(int year, int month, int day, double JDNCorrection)
    {
        var days = (int)(JDNg(year, month, day) - JDNCorrection);
        var md = FromDayCount(days);
        md.SetJDNCorrection(JDNCorrection);
        return md;
    }

    /// <summary>
    /// Constructs a MayanDate instance from a given Gregorian calendar date.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="year">A year in the Gregorian calendar.</param>
    /// <param name="month">A month in the Gregorian calendar.</param>
    /// <param name="day">A day in the Gregorian calendar.</param>
    /// <returns>A MayanDate class instance constructed from a given Gregorian calendar date.</returns>
    public static MayanDate FromYearMonthDay(int year, int month, int day)
    {
        var days = (int)(JDNg(year, month, day) - (double)MayanCorrection.GMT);
        var md = FromDayCount(days);
        md.SetJDNCorrection((double)MayanCorrection.GMT);
        return md;
    }

    /// <summary>
    /// Constructs a MayanDate instance from a given DateTime class instance.
    /// </summary>
    /// <param name="dt">A DateTime class instance.</param>
    /// <param name="mc">MayanCorrection enumeration which indicates A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>A MayanDate class instance constructed from a given DateTime class instance.</returns>
    public static MayanDate FromDateTime(DateTime dt, MayanCorrection mc)
    {
        var days = (int)(JDNg(dt.Year, dt.Month, dt.Day) - (double)mc);
        var md = FromDayCount(days);
        md.SetJDNCorrection((double)mc);
        return md;
    }

    /// <summary>
    /// Constructs a MayanDate instance from a given DateTime class instance.
    /// </summary>
    /// <param name="dt">A DateTime class instance.</param>
    /// <param name="JDNCorrection">A JDN (Julian Day Number) correction to the date.</param>
    /// <returns>A MayanDate class instance constructed from a given DateTime class instance.</returns>
    public static MayanDate FromDateTime(DateTime dt, double JDNCorrection)
    {
        var days = (int)(JDNg(dt.Year, dt.Month, dt.Day) - JDNCorrection);
        var md = FromDayCount(days);
        md.SetJDNCorrection(JDNCorrection);
        return md;
    }

    /// <summary>
    /// Constructs a MayanDate instance from a given DateTime class instance.
    /// <para/>A GMT JDN correction is used as correction to the date.
    /// </summary>
    /// <param name="dt">A DateTime class instance.</param>
    /// <returns>A MayanDate class instance constructed from a given DateTime class instance.</returns>
    public static MayanDate FromDateTime(DateTime dt)
    {
        var days = (int)(JDNg(dt.Year, dt.Month, dt.Day) - (double)MayanCorrection.GMT);
        var md = FromDayCount(days);
        md.SetJDNCorrection((double)MayanCorrection.GMT);
        return md;
    }

    /// <summary>
    /// Constructs an empty MayanDate class instance.
    /// </summary>
    /// <returns>An empty (0.0.0.0.0) MayanDate class instance.</returns>
    public static MayanDate GetBeforeTime()
    {
        return new MayanDate();
    }


    #region GregorianDates
    /// <summary>
    /// Gets a DateTime class instance representing the Mayan date.
    /// <para/>DateTime.Max and DateTime.Min values are used to indicate
    /// <para/>an "overflow" of the DateTime classes capacity.
    /// </summary>
    public DateTime Date
    {
        get
        {
            int year, month, day;
            YMDg(JDN + cJDNMayaStart, out year, out month, out day);
            if (year < DateTime.MinValue.Year)
            {
                return DateTime.MinValue;
            }
            else if (year > DateTime.MaxValue.Year)
            {
                return DateTime.MaxValue;
            }
            return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }
    }

    /// <summary>
    /// Gets a Gregorian calendar year number representing the Mayan date.
    /// </summary>
    public int Year
    {
        get
        {
            int year, month, day;
            YMDg(JDN + cJDNMayaStart, out year, out month, out day);
            return year;
        }
    }

    /// <summary>
    /// Gets a Gregorian calendar month number representing the Mayan date.
    /// </summary>
    public int Month
    {
        get
        {
            int year, month, day;
            YMDg(JDN + cJDNMayaStart, out year, out month, out day);
            return month;
        }
    }

    /// <summary>
    /// Gets a Gregorian calendar day number representing the Mayan date.
    /// </summary>
    public int Day
    {
        get
        {
            int year, month, day;
            YMDg(JDN + cJDNMayaStart, out year, out month, out day);
            return day;
        }
    }
    #endregion

    #region JulianDayConversions
    /// <summary>
    /// Converts a given Gregorian calendar date to Julian Day Number (JDN).
    /// </summary>
    /// <param name="year">A Gregorian calendar year.</param>
    /// <param name="month">A Gregorian calendar month.</param>
    /// <param name="day">A Gregorian calendar day.</param>
    /// <returns>A Julian Day Number (JDN).</returns>
    internal static double JDNg(int year, int month, int day)
    {
        var a = Math.Floor((14.0 - month) / 12.0);
        var y = year + 4800 - a;
        var m = month + 12 * a - 3;
        var JDN = day + Math.Floor((153 * m + 2) / 5) + 365 * y + Math.Floor(y / 4) - Math.Floor(y / 100) + Math.Floor(y / 400) - 32045;
        return JDN;
    }

    /// <summary>
    /// Converts a given A Julian Day Number (JDN) to a Gregorian calendar date.
    /// </summary>
    /// <param name="JDN">A Julian Day Number (JDN).</param>
    /// <param name="year">A Gregorian calendar year.</param>
    /// <param name="month">A Gregorian calendar month.</param>
    /// <param name="day">A Gregorian calendar day.</param>
    internal static void YMDg(double JDN, out int year, out int month, out int day)
    {
        var J = (int)JDN;
        var y = 4716;
        var v = 3;
        var j = 1401;
        var u = 5;
        var m = 2;
        var s = 153;
        var n = 12;
        var w = 2;
        var r = 4;
        var B = 274277;
        var p = 1461;
        var C = -38;
        var f = J + j + (((4 * J + B) / 146097) * 3) / 4 + C;
        var e = r * f + v;
        var g = (e % p) / r;
        var h = u * g + w;
        var D = ((h % s)) / u + 1;
        var M = ((h / s + m) % n) + 1;
        var Y = (e / p) - y + (n + m - M) / n;

        year = Y;
        month = M;
        day = D;
    }
    #endregion

    /// <summary>
    /// Gets or sets the Alautun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Alautun
    {
        get => alautun;

        set
        {
            if (value is >= 0 and < 20)
            {
                alautun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the K'inchiltun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Kinchiltun
    {
        get => kinchiltun;

        set
        {
            if (value is >= 0 and < 20)
            {
                kinchiltun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the Piktun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Piktun
    {
        get => piktun;

        set
        {
            if (value is >= 0 and < 20)
            {
                piktun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the B'ak'tun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Baktun
    {
        get => baktun;

        set
        {
            if (value is >= 0 and < 20)
            {
                baktun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the K'atun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Katun
    {
        get => katun;

        set
        {
            if (value is >= 0 and < 20)
            {
                katun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the Tun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Tun
    {
        get => tun;

        set
        {
            if (value is >= 0 and < 20)
            {
                tun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the Winal (=Uinal) part of the date.
    /// <para/>Allowed values are between 0 to 17.
    /// </summary>
    public int Winal // Winal = Uinal
    {
        get => winal;

        set
        {
            if (value is >= 0 and < 18)
            {
                winal = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 17.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the Uinal (=Winal) part of the date.
    /// <para/>Allowed values are between 0 to 17.
    /// </summary>
    public int Uinal // Uinal = Winal
    {
        get => winal;

        set
        {
            if (value is >= 0 and < 18)
            {
                winal = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 17.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the K'in part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Kin
    {
        get => kin;

        set
        {
            if (value is >= 0 and < 20)
            {
                kin = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets the Kalabtun part of the date.
    /// <para/>Allowed values are between 0 to 19.
    /// </summary>
    public int Kalabtun
    {
        get => kalabtun;

        set
        {
            if (value is >= 0 and < 20)
            {
                kalabtun = value;
            }
            else
            {
                throw new MayanDateException("The number must be between 0 and 19.");
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating if the Mayan calendar date is empty/nothing (0.0.0.0.0.0.0.0).
    /// </summary>
    public bool BeforeTime
    {
        get =>
            alautun == 0 &&
            kinchiltun == 0 &&
            piktun == 0 &&
            baktun == 0 &&
            katun == 0 &&
            tun == 0 &&
            winal == 0 &&
            kin == 0;

        set
        {
            if (value)
            {
                alautun = 0;
                kinchiltun = 0;
                piktun = 0;
                baktun = 0;
                katun = 0;
                tun = 0;
                winal = 0;
                kin = 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets a Julian Day Number (JDN) of the Mayan date.
    /// </summary>
    public double JDN
    {
        get =>
            Kin * 1 +
            Winal * 20 +
            Tun * 360 +
            Katun * 7200 +
            Baktun * 144000 +
            Piktun * 2880000 +
            Kalabtun * 57600000 +
            Kinchiltun * 1152000000 +
            Alautun * 23040000000;

        set
        {
            var dJDN = value;
            var dalautun = dJDN / 23040000000.0;
            var daysLeft = dJDN - Math.Floor(dalautun) * 23040000000.0;

            var dkinchiltun = daysLeft / 1152000000.0;
            daysLeft = daysLeft - Math.Floor(dkinchiltun) * 1152000000.0;

            var dkalabtun = daysLeft / 57600000.0;
            daysLeft = daysLeft - Math.Floor(dkalabtun) * 57600000.0;

            var dpictun = daysLeft / 2880000.0;
            daysLeft = daysLeft - Math.Floor(dpictun) * 2880000.0;
            var dbaktun = daysLeft / 144000.0;
            daysLeft = daysLeft - Math.Floor(dbaktun) * 144000.0;
            var dkatun = daysLeft / 7200.0;
            daysLeft = daysLeft - Math.Floor(dkatun) * 7200.0;
            var dtun = daysLeft / 360.0;
            daysLeft = daysLeft - Math.Floor(dtun) * 360.0;
            var dwinal = daysLeft / 20.0;
            daysLeft = daysLeft - Math.Floor(dwinal) * 20.0;
            var dkin = Math.Floor(daysLeft);
            alautun = (int)dalautun;
            kinchiltun = (int)dkinchiltun;
            kalabtun = (int)dkalabtun;
            piktun = (int)dpictun;
            baktun = (int)dbaktun;
            katun = (int)dkatun;
            tun = (int)dtun;
            winal = (int)dwinal;
            kin = (int)dkin;
        }
    }

    /// <summary>
    /// Adds a number of days to the Mayan date.
    /// </summary>
    /// <param name="days">A number of days to add (positive or negative).</param>
    /// <returns>A new MayanDate class instance with the given amount of days added.</returns>
    public MayanDate AddDays(int days)
    {
        return FromDayCount(JDN + days, cJDNMayaStart);
    }

    /// <summary>
    /// Adds a number of Haab' months to the Mayan date.
    /// </summary>
    /// <param name="months">The number of Haab' months to add.</param>
    /// <returns>A new <see cref="MayanDate"/> class instance with the specified amount of months added.</returns>
    public MayanDate AddMonths(int months)
    {
        var monthIndex = HaabMonthIndex;
        var addDays = 0;
        if (months < 0)
        {
            for (var i = months; i < 0; i++)
            {
                addDays -= monthIndex == 18 ? 5 : 20;
                monthIndex--;

                if (monthIndex < 0)
                {
                    monthIndex = 18;
                }
            }
        }

        if (months > 0)
        {
            for (var i = 0; i < months; i++)
            {
                addDays += monthIndex == 18 ? 5 : 20;
                monthIndex++;

                if (monthIndex > 18)
                {
                    monthIndex = 0;
                }
            }
        }

        return AddDays(addDays);
    }

    /// <summary>
    /// Adds the specified number of years to the Mayan date.
    /// </summary>
    /// <param name="years">The number of years to add.</param>
    /// <returns>A new <see cref="MayanDate"/> class instance with the specified amount of years added.</returns>
    public MayanDate AddYears(int years)
    {
        return AddDays(years * 365);
    }

    /// <summary>
    /// Gets a Tzolk'in day number of the Mayan date.
    /// </summary>
    public int TzolkinDayNumber
    {
        get
        {
            var tzn = (int)((4.0 + JDN) % 13.0);
            if (tzn == 0)
            {
                tzn = 13;
            }
            return tzn;
        }
    }

    /// <summary>
    /// Gets a Tzolk'in day index of the Mayan date.
    /// </summary>
    private int TzolkinDayIndex
    {
        get
        {
            var index = (int)(((JDN) % 20.0));
            return index;
        }
    }

    /// <summary>
    /// Gets a Tzolk'in day name of the Mayan date.
    /// </summary>
    public string TzolkinDayName => tzolkinDayNames[TzolkinDayIndex];

    /// <summary>
    /// Gets a Haab' month index of the Mayan date.
    /// </summary>
    public int HaabMonthIndex
    {
        get
        {
            var retval = JDN - 17.0;
            while (retval < 0)
            {
                retval += 360;
            }
            retval %= 365.0;
            return (int)(retval / 20.0);
        }
    }

    /// <summary>
    /// Gets a Haab' day number of the Mayan date.
    /// </summary>
    public int HaabDay
    {
        get
        {
            var retval = JDN - 17.0;
            while (retval < 0)
            {
                retval += 365;
            }
            retval %= 365.0;
            return (int)(retval % 20.0);
        }
    }

    /// <summary>
    /// Gets a Haab' month name of the Mayan date.
    /// </summary>
    public string HaabMonth => haabMonthNames[HaabMonthIndex];

    /// <summary>
    /// Gets a Lord of the Night as a string (G1, G2, .... G9) of the Mayan date.
    /// </summary>
    public string LordOfTheNight
    {
        get
        {
            var night = (int)(((winal * 2 + kin) % 9));
            return "G" + (night == 0 ? 9 : night);
        }
    }

    // There are hyphens (') in the names so we return them as well
    #region names
    /// <summary>
    /// Gets a name of the Alautun part of the Mayan calendar (index = 9).
    /// </summary>
    public static string AlautunName => datePartNames[9];

    /// <summary>
    /// Gets a name of the K'inchiltun part of the Mayan calendar (index = 8).
    /// </summary>
    public static string KinchiltunName => datePartNames[8];

    /// <summary>
    /// Gets a name of the Piktun part of the Mayan calendar (index = 6).
    /// </summary>
    public static string PiktunName => datePartNames[6];

    /// <summary>
    /// Gets a name of the Kalabtun part of the Mayan calendar (index = 7).
    /// </summary>
    public static string KalabtunName => datePartNames[7];

    /// <summary>
    /// Gets a name of the B'ak'tun part of the Mayan calendar (index = 5).
    /// </summary>
    public static string BaktunName => datePartNames[5];

    /// <summary>
    /// Gets a name of the K'atun part of the Mayan calendar (index = 4).
    /// </summary>
    public static string KatunName => datePartNames[4];

    /// <summary>
    /// Gets a name of the Tun part of the Mayan calendar (index = 3).
    /// </summary>
    public static string TunName => datePartNames[3];

    /// <summary>
    /// Gets a name of the Winal (=Uinal) part of the Mayan calendar (index = 2).
    /// </summary>
    public static string WinalName => datePartNames[1];

    /// <summary>
    /// Gets a name of the Uinal (=Winal) part of the Mayan calendar (index = 2).
    /// </summary>
    public static string UinalName => datePartNames[2];

    /// <summary>
    /// Gets a name of the K'in part of the Mayan calendar (index = 1).
    /// </summary>
    public static string KinName => datePartNames[0];

    /// <summary>
    /// Gets a name of the Haab' portion of the Mayan calendar.
    /// </summary>
    public static string HaabName => "Haab'";

    /// <summary>
    /// Gets a name of the Tzolk'in portion of the Mayan calendar.
    /// </summary>
    public static string TzolkinName => "Tzolk'in";

    #endregion

    /// <summary>
    /// Gets a list of MayanCorrection enumeration values and their descriptions.
    /// </summary>
    public static List<MayanCorrectionContainer> JDNCorrectionList
    {
        get
        {
            var correctionList = new List<MayanCorrectionContainer>();
            var corrections = Enum.GetValues(typeof(MayanCorrection));
            foreach (MayanCorrection correction in corrections)
            {
                correctionList.Add(new MayanCorrectionContainer { Correction = correction, CorrectionName = correction.GetAttributeDescription() });
            }
            return correctionList;
        }
    }
}