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
using System.Globalization;
using System.Linq;
using VPKSoft.MayanCalendar.Enumerations;

namespace VPKSoft.MayanCalendar;

/// <summary>
/// Maya calendar.
/// Implements the <see cref="Calendar" />
/// </summary>
/// <seealso cref="Calendar" />
public class MayaCalendar : Calendar
{
    /// <summary>
    /// Gets or sets the correction to use with the <see cref="MayanDate"/> class.
    /// </summary>
    /// <value>The correction to use with the <see cref="MayanDate"/> class.</value>
    // ReSharper disable once MemberCanBePrivate.Global
    public MayanCorrection Correction { get; set; } = MayanCorrection.GMT;

    /// <inheritdoc cref="Calendar.AddMonths(DateTime,int)"/>
    public override DateTime AddMonths(DateTime time, int months)
    {
        return MayanDate.FromDateTime(time, Correction).AddMonths(months).Date;
    }

    /// <inheritdoc cref="Calendar.AddYears(DateTime,int)"/>
    public override DateTime AddYears(DateTime time, int years)
    {
        return MayanDate.FromDateTime(time, Correction).AddYears(years).Date;
    }

    /// <inheritdoc cref="Calendar.GetDayOfMonth(DateTime)"/>
    public override int GetDayOfMonth(DateTime time)
    {
        return MayanDate.FromDateTime(time, Correction).Kin;
    }

    /// <inheritdoc cref="Calendar.GetDayOfWeek(DateTime)"/>
    /// <exception cref="System.NotImplementedException">Week days of the Mayas are unknown.</exception>
    public override DayOfWeek GetDayOfWeek(DateTime time)
    {
        throw new NotImplementedException("Week days of the Mayas are unknown.");
    }

    /// <inheritdoc cref="Calendar.GetDayOfYear(DateTime)"/>
    public override int GetDayOfYear(DateTime time)
    {
        var mayanDate = MayanDate.FromDateTime(time, Correction);
        var winal = mayanDate.Winal;
        var haabDay = mayanDate.HaabDay;

        return winal < 17 ? winal * 20 : 360 + haabDay;
    }

    /// <inheritdoc cref="Calendar.GetDaysInMonth(int,int,int)"/>
    public override int GetDaysInMonth(int year, int month, int era)
    {
        return month == 18 ? 5 : 20;
    }

    /// <inheritdoc cref="Calendar.GetDaysInYear(int,int)"/>
    public override int GetDaysInYear(int year, int era)
    {
        return 365; // There is no leap count day.
    }

    /// <inheritdoc cref="Calendar.GetEra(DateTime)"/>
    public override int GetEra(DateTime time)
    {
        return MayanDate.FromDateTime(time, Correction).Baktun;
    }

    /// <inheritdoc cref="Calendar.GetMonth(DateTime)"/>
    public override int GetMonth(DateTime time)
    {
        return MayanDate.FromDateTime(time, Correction).Winal;
    }

    /// <inheritdoc cref="Calendar.GetMonthsInYear(int,int)"/>
    public override int GetMonthsInYear(int year, int era)
    {
        return 20; // There are no leaps.
    }

    /// <inheritdoc cref="Calendar.GetYear(DateTime)"/>
    public override int GetYear(DateTime time)
    {
        return MayanDate.FromDateTime(time, Correction).Tun;
    }

    /// <inheritdoc cref="Calendar.IsLeapDay(int,int,int,int)"/>
    public override bool IsLeapDay(int year, int month, int day, int era)
    {
        return false; // There are no leaps.
    }

    /// <inheritdoc cref="Calendar.IsLeapMonth(int,int,int)"/>
    public override bool IsLeapMonth(int year, int month, int era)
    {
        return false; // There are no leaps.
    }

    /// <inheritdoc cref="Calendar.IsLeapYear(int,int)"/>
    public override bool IsLeapYear(int year, int era)
    {
        return false; // There are no leaps.
    }

    /// <inheritdoc cref="Calendar.ToDateTime(int,int,int,int,int,int,int,int)"/>
    /// <exception cref="System.ArgumentException">month</exception>
    /// <exception cref="System.ArgumentException">day</exception>
    /// <exception cref="System.ArgumentException">Time is not supported.</exception>
    /// <exception cref="System.ArgumentException">Era is not supported.</exception>
    public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
    {
        if (month is < 0 or > 19)
        {
            throw new ArgumentException(nameof(month));
        }

        if (day is < 0 or > 19)
        {
            throw new ArgumentException(nameof(day));
        }

        if (month == 19 && day is < 0 or > 4)
        {
            throw new ArgumentException(nameof(day));
        }

        if (hour != default || minute != default || second != default || millisecond != default)
        {
            throw new ArgumentException("Time is not supported.");
        }

        if (!Eras.Contains(era))
        {
            throw new ArgumentException("Era is not supported.");
        }

        var days = year * 365 + month < 17 ? month * 20 + day : 360 + day;
        var mayanDate = new MayanDate { Baktun = era, };
        mayanDate.SetJDNCorrection(Correction);
        return mayanDate.AddDays(days).Date;
    }

    /// <summary>
    /// Returns a <see cref="T:System.DateTime" /> that is set to the specified date and time in the specified era.
    /// </summary>
    /// <param name="year">An integer that represents the year.</param>
    /// <param name="month">A positive integer that represents the month.</param>
    /// <param name="day">A positive integer that represents the day.</param>
    /// <param name="era">An integer that represents the era.</param>
    /// <returns>The <see cref="T:System.DateTime" /> that is set to the specified date and time in the current era.</returns>
    /// <exception cref="System.ArgumentException">month</exception>
    /// <exception cref="System.ArgumentException">day</exception>
    public DateTime ToDateTime(int year, int month, int day, int era)
    {
        return ToDateTime(year, month, day, 0, 0, 0, 0, era);
    }

    /// <summary>
    /// Returns a <see cref="T:System.DateTime" /> that is set to the specified date and time in the era 13.
    /// </summary>
    /// <param name="year">An integer that represents the year.</param>
    /// <param name="month">A positive integer that represents the month.</param>
    /// <param name="day">A positive integer that represents the day.</param>
    /// <exception cref="System.ArgumentException">month</exception>
    /// <exception cref="System.ArgumentException">day</exception>
    public DateTime ToDateTime(int year, int month, int day)
    {
        // ReSharper disable once IntroduceOptionalParameters.Global
        return ToDateTime(year, month, day, 13);
    }

    /// <inheritdoc cref="Eras"/>.
    public override int[] Eras { get; } =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, };
}