using System.Diagnostics;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.Application.Services;

public class MedicationTimeService
{
    private IDomainEntityRepository<MedicationTime> _medicationTimeRepository;
    private IDomainEntityRepository<MedicationSchedule> _medicationScheduleRepository;

    public MedicationTimeService(IDomainEntityRepository<MedicationTime> medicationTimeRepository, IDomainEntityRepository<MedicationSchedule> medicationScheduleRepository)
    {
        _medicationTimeRepository = medicationTimeRepository;
        _medicationScheduleRepository = medicationScheduleRepository;
    }

    public async Task<bool> CreateMedicationTimeAndJoinToScheduleAsync(Guid scheduleId, MedicationTime medicationTime)
    {
        try
        {
            MedicationSchedule schedule = await _medicationScheduleRepository.GetByIdAsync(scheduleId) 
                                          ?? throw new ApplicationException("Schedule was not exist!");
            if (!await _medicationTimeRepository.AddAsync(medicationTime))
                throw new ApplicationException("MedicationTime creation was failed");
            IEnumerable<MedicationTime> medicationTimes = schedule.MedicationTimes.Union(new []{medicationTime});
            schedule.MedicationTimes = medicationTimes;
            return await _medicationScheduleRepository.UpdateAsync(schedule);
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }
        return false;
    }
    public async Task<bool> CreateMedicationTimeAsync(MedicationTime medicationTime)
        => await _medicationTimeRepository.AddAsync(medicationTime);
    public async Task<bool> UpdateMedicationTimeAsync(MedicationTime medicationTime)
        => await _medicationTimeRepository.UpdateAsync(medicationTime);
    public async Task<MedicationTime?> FindMedicationTimeByIdAsync(Guid id)
        => await _medicationTimeRepository.GetByIdAsync(id);
    public async Task<IEnumerable<int>> GetAllBusyNotificationIdAsync()
        => (await _medicationTimeRepository.GetAllAsync()).Select((mt, id) => mt.NotificationId);
}