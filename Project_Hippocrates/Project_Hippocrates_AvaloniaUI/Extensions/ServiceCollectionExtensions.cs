using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates_AvaloniaUI.Views;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.Core.Interfaces.Storage;
using Project_Hippocrates.SQLite;
using Project_Hippocrates.SQLite.StorageServices;
using System;
using Project_Hippocrates.SQLite.Mapping;

namespace Project_Hippocrates_AvaloniaUI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViews(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<EditMedicationTimeView>()
                                .AddTransient<UsersMedicationSchedulesListView>()
                                .AddTransient<MainWindow>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<CreateMedicationTimeViewModel>()
                                .AddTransient<EditExistingMedicationTimeViewModel>()
                                .AddTransient<MainWindowViewModel>()
                                .AddTransient<UsersMedicationSchedulesListViewModel>();
    }

    public static IServiceCollection AddModels(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<CreateMedicationTimeModel>()
                                .AddTransient<EditExistingMedicationTimeModel>()
                                .AddTransient<UsersMedicationSchedulesListModel>();
    }

    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<MedicationTimeService>()
                                .AddSingleton<MedicationScheduleService>();
    }

    public static IServiceCollection AddViewLocator(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<ViewLocator>();
    }

    public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
    {
        var exe = Assembly.GetExecutingAssembly();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly(), Assembly.Load("Project_Hippocrates.SQLite"));
        serviceCollection.AddSingleton<TypeAdapterConfig>(config);
        serviceCollection.AddSingleton<IMapper, ServiceMapper>();
        return serviceCollection;
    }

    public static IServiceCollection AddTestRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<IDomainEntityRepository<DrugDosage>, 
                Project_Hippocrates.TestEntityRepositories.Repositories.DrugDosageRepository>()
            .AddTransient<IDomainEntityRepository<MedicalDrug>, 
                Project_Hippocrates.TestEntityRepositories.Repositories.MedicalDrugRepository>()
            .AddTransient<IDomainEntityRepository<MedicationSchedule>, 
                Project_Hippocrates.TestEntityRepositories.Repositories.MedicationScheduleRepository>()
            .AddTransient<IDomainEntityRepository<MedicationTime>, 
                Project_Hippocrates.TestEntityRepositories.Repositories.MedicationTimeRepository>();
    }

    public static IServiceCollection AddSqLite(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<IDomainEntityRepository<DrugDosage>,
                Project_Hippocrates.SQLite.Repositories.DrugDosageRepository>()
            .AddTransient<IDomainEntityRepository<MedicalDrug>, 
                Project_Hippocrates.SQLite.Repositories.MedicalDrugRepository>()
            .AddTransient<IDomainEntityRepository<MedicationSchedule>, 
                Project_Hippocrates.SQLite.Repositories.MedicationScheduleRepository>()
            .AddTransient<IDomainEntityRepository<MedicationTime>, 
                Project_Hippocrates.SQLite.Repositories.MedicationTimeRepository>()
            .AddTransient<IMedicationTimeStorageService, SqLiteMedicationTimeStorageService>()
            .AddTransient<SqLiteDbContext, SqLiteDbContext>();
    }
}