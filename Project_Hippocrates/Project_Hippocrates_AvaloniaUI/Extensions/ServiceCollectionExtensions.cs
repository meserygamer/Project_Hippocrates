using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates_AvaloniaUI.Views;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.TestEntityRepositories.Repositories;

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

    public static IServiceCollection AddDataRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IDomainEntityRepository<MedicationTime>>(provider => null); //TODO Add repository as soon ready
    }

    public static IServiceCollection AddViewLocator(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<ViewLocator>();
    }

    public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        serviceCollection.AddSingleton<TypeAdapterConfig>(config);
        serviceCollection.AddSingleton<IMapper, ServiceMapper>();
        return serviceCollection;
    }

    public static IServiceCollection AddTestRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddTransient<IDomainEntityRepository<DrugDosage>, DrugDosageRepository>()
                                .AddTransient<IDomainEntityRepository<MedicalDrug>, MedicalDrugRepository>()
                                .AddTransient<IDomainEntityRepository<MedicationSchedule>, MedicationScheduleRepository>()
                                .AddTransient<IDomainEntityRepository<MedicationTime>, MedicationTimeRepository>();
    }
}