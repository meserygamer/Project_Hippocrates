using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public class UsersMedicationSchedulesListViewModel : ViewModelBase
    {
        #region Fields

        private readonly UsersMedicationSchedulesListModel _model;

        private ObservableCollection<MedicationScheduleDTO> _medicationSchedules = [];
        private ObservableCollection<MedicationTimeDTO>? _medicationTimes;
        
        private MedicationScheduleDTO? _selectedMedicationSchedule;

        #endregion
        
        public UsersMedicationSchedulesListViewModel(UsersMedicationSchedulesListModel model)
        {
            _model = model;
            _model.ViewModel = this;
        }

        #region Implementation ViewModelBase

        public override async Task InitializeForShowAsync(Bundle? bundle)
        {
            MedicationSchedules = await _model.GetAllMedicationScheduleAsync();
            SelectedMedicationSchedule = MedicationSchedules[0];
        }

        #endregion

        #region Properties

        public MedicationScheduleDTO? SelectedMedicationSchedule
        {
            get => _selectedMedicationSchedule;
            set
            {
                SetProperty(ref _selectedMedicationSchedule, value);
                OnSelectedMedicationScheduleChanged();
            }
        }
        public ObservableCollection<MedicationScheduleDTO> MedicationSchedules
        {
            get => _medicationSchedules;
            set
            {
                SetProperty(ref _medicationSchedules, value);
                OnMedicationSchedulesChanged();
            }
        }
        public ObservableCollection<MedicationTimeDTO> MedicationTimes
        {
            get => _medicationTimes ?? [];
            set => SetProperty(ref _medicationTimes, value);
        }

        #endregion

        #region Handlers

        private void OnSelectedMedicationScheduleChanged()
        {
            MedicationTimes = SelectedMedicationSchedule?.MedicationTimes ?? [];
        }
        private void OnMedicationSchedulesChanged()
        {
            SelectedMedicationSchedule = null;
        }

        #endregion
    }
}
