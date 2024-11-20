﻿using System;
using System.Threading.Tasks;

namespace Project_Hippocrates_AvaloniaUI;

public interface IViewShower
{
    Task ShowViewAsync(Type viewModelType, Bundle? data);
    Task ShowPreviousViewAsync();
}