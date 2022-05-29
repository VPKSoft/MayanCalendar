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
using System.ComponentModel;

namespace VPKSoft.MayanCalendar.Helpers;

/// <summary>
/// An extension class for Enum to get it's Description attribute.
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// An extension method for Enum to get it's Description attribute.
    /// </summary>
    /// <param name="enumValue">An enum value to get a Description for.</param>
    /// <returns>Enum value's Description attribute.</returns>
    public static string GetAttributeDescription(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var memInfo = enumType.GetMember(enumValue.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes is { Length: > 0 })
        {
            return ((DescriptionAttribute)attributes[0]).Description;
        }
        else
        {
            return enumValue.ToString();
        }
    }
}
