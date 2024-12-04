using Mapster;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Mapping;

public class MedicationScheduleEntityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicationScheduleEntity, MedicationSchedule>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Name, source => source.Name)
            .Map(dest => dest.MedicationTimes, source => source.MedicationTimes.AsQueryable().ProjectToType<MedicationTime>(config));
        
        config.NewConfig<MedicationSchedule, MedicationScheduleEntity>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Name, source => source.Name)
            .Map(dest => dest.MedicationTimes, source => source.MedicationTimes.AsQueryable().ProjectToType<MedicationTimeEntity>(config).ToList());
    }
}