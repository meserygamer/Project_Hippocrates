using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public class UsersMedicationSchedulesListViewModel : ViewModelBase
    {
        #region Fields

        private readonly UsersMedicationSchedulesListModel _model;
        private readonly IViewShower _viewShower;

        private ObservableCollection<MedicationScheduleDTO> _medicationSchedules = [];
        
        private MedicationScheduleDTO? _selectedMedicationSchedule;

        #endregion

        #region Constructors

        public UsersMedicationSchedulesListViewModel(UsersMedicationSchedulesListModel model,
            IViewShower viewShower)
        {
            _model = model;
            _model.ViewModel = this;
            _viewShower = viewShower;
        }

        /// <summary>
        /// Only for design mode
        /// </summary>
        public UsersMedicationSchedulesListViewModel() { }

        #endregion

        #region Implementation ViewModelBase

        public override async Task InitializeForShowAsync(Bundle? bundle)
        {
            MedicationSchedules = await _model.GetAllMedicationScheduleAsync();
            SelectedMedicationSchedule = MedicationSchedules.Count >= 1 ? MedicationSchedules[0] : null;
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
            get => _selectedMedicationSchedule?.MedicationTimes ?? [];
            set
            {
                if(_selectedMedicationSchedule is null)
                    return;
                _selectedMedicationSchedule.MedicationTimes = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Handlers
        
        /// <summary>
        /// Method-handler of click on AddMedicationTime button
        /// </summary>
        public async Task OnAddMedicationTimeButtonClickAsync()
            => await _viewShower.ShowViewAsync(typeof(CreateMedicationTimeViewModel),
                new Bundle(
                    new Dictionary<string, object?>{{"CurrentMedicationSchedule", _selectedMedicationSchedule!.Id}}
                    ));
        
        /// <summary>
        /// Method-handler of click on RemoveMedicationTime button
        /// </summary>
        public async Task OnRemoveMedicationTimeButtonClickAsync(object medicationTime)
        {
            if (_selectedMedicationSchedule is null)
                return;

            var currentMedicationSchedule = _selectedMedicationSchedule;
            MedicationTimeDTO medicationTimeDto = (MedicationTimeDTO)medicationTime;
            if (!await _model.TryRemoveMedicationTimeFromScheduleAsync(currentMedicationSchedule, medicationTimeDto))
                return;
            
            currentMedicationSchedule.MedicationTimes = 
                new ObservableCollection<MedicationTimeDTO>(
                    await _model.GetSchedulesMedicationTimesAsync(currentMedicationSchedule.Id)
                );
            OnPropertyChanged(nameof(MedicationTimes));
        }

        /// <summary>
        /// Method-handler of click on EditMedicationTime button
        /// </summary>
        public async Task OnEditMedicationTimeButtonClickAsync(object medicationTime)
            => await _viewShower.ShowViewAsync(typeof(EditExistingMedicationTimeViewModel),
                new Bundle(
                    new Dictionary<string, object?> { { "ChangingMedicationTimeId", (medicationTime as MedicationTimeDTO)!.Id } }
                ));

        /// <summary>
        /// Method-handler of change selection MedicationScheduleDTO
        /// </summary>
        private void OnSelectedMedicationScheduleChanged()
        {
            MedicationTimes = SelectedMedicationSchedule?.MedicationTimes ?? [];
        }
        
        /// <summary>
        /// Method-handler of change MedicationScheduleDTO list 
        /// </summary>
        private void OnMedicationSchedulesChanged()
        {
            SelectedMedicationSchedule = null;
        }
        
        #endregion
    }
}
