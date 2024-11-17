using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.TestEntityRepositories;

internal class TestStorage
{
    public static readonly List<MedicalDrug> MedicalDrugs;
    public static readonly List<DrugDosage> DrugDosages;
    public static readonly List<MedicationTime> MedicationTimes;
    public static readonly List<MedicationSchedule> MedicationSchedules;

    static TestStorage()
    {
        MedicalDrugs = 
        [
            new (){ Id = Guid.NewGuid(), Name = "ВИТАКИДС ВИТАМИН С пастилки апельсин \u211660" },
            new (){ Id = Guid.NewGuid(), Name = "ФОЛИЕВАЯ КИСЛОТА ПРЕНАТАЛЬ табл. п/о \u211690" },
            new (){ Id = Guid.NewGuid(), Name = "ВИТАМИН С ЗДРАВСИТИ табл. растворим. цитрус 900 мг \u211620" },
            new (){ Id = Guid.NewGuid(), Name = "АКВАДЕТРИМ капли внутр. 500 МЕ/1 капля фл.- кап. 15 мл" },
            new (){ Id = Guid.NewGuid(), Name = "АСКОРБИНОВАЯ КИСЛОТА С ГЛЮКОЗОЙ БАД табл. \u211610" },
        ];
        
        DrugDosages =
        [
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[0], DrugDoseValue = 10, DoseUnit = "кап."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[0], DrugDoseValue = 2, DoseUnit = "т."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[1], DrugDoseValue = 100, DoseUnit = "мл."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[1], DrugDoseValue = 8, DoseUnit = "кап."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[2], DrugDoseValue = 1, DoseUnit = "т."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[2], DrugDoseValue = 50, DoseUnit = "мл."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[3], DrugDoseValue = 5, DoseUnit = "кап."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[3], DrugDoseValue = 3, DoseUnit = "т."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[4], DrugDoseValue = 75, DoseUnit = "мл."},
            new() { Id = Guid.NewGuid(), Drug = MedicalDrugs[4], DrugDoseValue = 12, DoseUnit = "кап."}
        ];

        MedicationTimes =
        [
            new (){ Id = Guid.NewGuid(), Label = "Утро", MedicationsTaken = DrugDosages[0..3], Time = new TimeSpan(8, 0, 0)},
            new (){ Id = Guid.NewGuid(), Label = "День", MedicationsTaken = DrugDosages[3..7], Time = new TimeSpan(14, 30, 0)},
            new (){ Id = Guid.NewGuid(), Label = "Вечер", MedicationsTaken = DrugDosages[7..10], Time = new TimeSpan(21, 0, 0)},
            new (){ Id = Guid.NewGuid(), Label = "Утро", MedicationsTaken = DrugDosages[0..2], Time = new TimeSpan(8, 0, 0)},
            new (){ Id = Guid.NewGuid(), Label = "День", MedicationsTaken = DrugDosages[2..8], Time = new TimeSpan(15, 0, 0)},
            new (){ Id = Guid.NewGuid(), Label = "Вечер", MedicationsTaken = DrugDosages[8..10], Time = new TimeSpan(22, 0, 0)}
        ];

        MedicationSchedules =
        [
            new (){ Id = Guid.NewGuid(), MedicationTimes = MedicationTimes[0..3], Name = "Расписание №1"},
            new (){ Id = Guid.NewGuid(), MedicationTimes = MedicationTimes[3..6], Name = "Расписание №2"}
        ];
    }
}