using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Project_Hippocrates_AvaloniaUI.Views;

public partial class EditMedicationTimeView : UserControl
{
    public EditMedicationTimeView()
    {
        InitializeComponent();
        DataGrid.ItemsSource = new List<Test>
        {
            new(){DrugName = "TestDrugName", DrugDose = "TestDrugDose"}
        };
    }

    public class Test
    {
        public string DrugName { get; set; }
        public string DrugDose { get; set; }
    }
}