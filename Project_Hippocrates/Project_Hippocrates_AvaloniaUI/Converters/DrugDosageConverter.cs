using Avalonia.Data.Converters;
using System;
using System.Globalization;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;

namespace Project_Hippocrates_AvaloniaUI.Converters;

public class DrugDosageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
            return string.Empty;

        if (value is not DrugDosageDTO)
            throw new NotSupportedException("Value is not DrugDosageDTO");

        if (targetType != typeof(string))
            throw new NotSupportedException("DrugDosageConverter not support this convertion type");

        DrugDosageDTO dosage = (DrugDosageDTO)value;
        return $"- {dosage.DrugName} ({dosage.DrugDoseValue} {dosage.DoseUnit})";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("Convertor only for display data");
    }
}
