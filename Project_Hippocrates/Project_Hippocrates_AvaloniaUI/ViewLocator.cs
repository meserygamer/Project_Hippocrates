using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using System;

namespace Project_Hippocrates_AvaloniaUI
{
    public class ViewLocator : IDataTemplate
    {
        private string _viewNamespace = "Project_Hippocrates_AvaloniaUI.Views";
        private string _viewModelNamespace = "Project_Hippocrates_AvaloniaUI.ViewModels";
        
        public ViewLocator() { }
        
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }
        
        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }

        public Control BuildViewWithDataContext(ViewModelBase vm)
        {
            string viewTypeName = vm.ViewModelFullName!
                .Replace(_viewModelNamespace, _viewNamespace)
                .Replace("ViewModel", "View", StringComparison.Ordinal);
            Type viewType = Type.GetType(viewTypeName) 
                                 ?? throw new NullReferenceException($"Type - {viewTypeName} was not found!");
            Control view = (Control)Activator.CreateInstance(viewType)!;
            view.DataContext = vm;
            return view;
        }
    }
}