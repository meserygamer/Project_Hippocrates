﻿using System;

namespace Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

public class DrugDosagePresenter
{
    public Guid DrugId { get; set; }
    public string DrugName { get; set; } = null!;
    public uint DrugDoseValue { get; set; }
    public string DoseUnit { get; set; } = null!;
}