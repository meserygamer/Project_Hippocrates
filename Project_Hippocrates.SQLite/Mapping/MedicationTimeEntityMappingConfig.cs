using Mapster;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Mapping;

public class MedicationTimeEntityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicationTimeEntity, MedicationTime>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Label, source => source.Label)
            .Map(dest => dest.Time, source => source.Time)
            .Map(dest => dest.NotificationId, source => source.PushNotificationId)
            .Map(dest => dest.MedicationsTaken, source => source.MedicationsTaken.AsQueryable().ProjectToType<DrugDosage>(config));
        
        config.NewConfig<MedicationTime, MedicationTimeEntity>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Label, source => source.Label)
            .Map(dest => dest.Time, source => source.Time)
            .Map(dest => dest.PushNotificationId, source => source.NotificationId)
            .Map(dest => dest.MedicationsTaken, source => source.MedicationsTaken.AsQueryable().ProjectToType<DrugDosage>(config).ToList());
    }
}