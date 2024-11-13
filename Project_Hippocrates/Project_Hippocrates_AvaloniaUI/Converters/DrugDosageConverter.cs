using Avalonia.Data.Converters;
using Project_Hippocrates.Core.Entities;
using System;
using System.Globalization;

namespace Project_Hippocrates_AvaloniaUI.Converters;

public class DrugDosageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
            return string.Empty;

        if (value is not DrugDosage)
            throw new NotSupportedException("Value is not DrugDosage");

        if (targetType != typeof(string))
            throw new NotSupportedException("DrugDosageConverter not support this convertion type");

        DrugDosage dosage = (DrugDosage)value;
        return $"{dosage.Drug.Name} ({dosage.DrugDoseValue} {dosage.DoseUnit})";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("Convertor only for display data");
    }
}
