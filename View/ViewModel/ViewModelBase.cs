using DBContexts;
using Microsoft.Win32;
using Models.Entities;
using Services;
using Services.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace View.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private AppDbContext db = null;
        int candidateID, candidateApplyId, oldStatus;
        private byte[] fileCV, attachment;
        private bool isAdd, isCheckInterview;
        public Candidate candidateItem { get; set; }
        private Candidate candidate;
        public Candidate Candidate
        {
            get { return candidate; }
            set
            {
                candidate = value;
                OnPropertyChanged("Candidate");
            }
        }
        private Candidate_Apply candidateApply;

        public Candidate_Apply CandidateApply
        {
            get { return candidateApply; }
            set
            {
                candidateApply = value;
                OnPropertyChanged("CandidateApply");
            }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        private string buttonInterviewContent;
        public string ButtonInterviewContent
        {
            get { return buttonInterviewContent; }
            set
            {
                buttonInterviewContent = value;
                OnPropertyChanged("ButtonInterviewContent");
            }
        }
        private string viewCVTitle;
        public string ViewCVTitle
        {
            get { return viewCVTitle; }
            set
            {
                viewCVTitle = value;
                OnPropertyChanged("ViewCVTitle");
            }
        }
        private string titlePopSave;
        public string TitlePopSave
        {
            get { return titlePopSave; }
            set
            {
                titlePopSave = value;
                OnPropertyChanged("TitlePopSave");
            }
        }
        private string noteRefuse;
        public string NoteRefuse
        {
            get { return noteRefuse; }
            set
            {
                noteRefuse = value;
                OnPropertyChanged("NoteRefuse");
            }
        }
        private string titlePopInterview;
        public string TitlePopInterview
        {
            get { return titlePopInterview; }
            set
            {
                titlePopInterview = value;
                OnPropertyChanged("TitlePopInterview");
            }
        }
        private int status;
        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
                LoadListTask(Status);
            }
        }
        private string titleEmail;
        public string TitleEmail
        {
            get { return titleEmail; }
            set
            {
                titleEmail = value;
                OnPropertyChanged("TitleEmail");
            }
        }
        private string contentEmail;
        public string ContentEmail
        {
            get { return contentEmail; }
            set
            {
                contentEmail = value;
                OnPropertyChanged("ContentEmail");
            }
        }
        private Visibility statusButton;
        public Visibility StatusButton
        {
            get { return statusButton; }
            set
            {
                statusButton = value;
                OnPropertyChanged("StatusButton");
            }
        }
        private Visibility showPopEmail;
        public Visibility ShowPopEmail
        {
            get { return showPopEmail; }
            set
            {
                showPopEmail = value;
                OnPropertyChanged("ShowPopEmail");
            }
        }
        private Visibility showPopInterview;
        public Visibility ShowPopInterview
        {
            get { return showPopInterview; }
            set
            {
                showPopInterview = value;
                OnPropertyChanged("ShowPopInterview");
            }
        }
        private Visibility showConfirmEmail;
        public Visibility ShowConfirmEmail
        {
            get { return showConfirmEmail; }
            set
            {
                showConfirmEmail = value;
                OnPropertyChanged("ShowConfirmEmail");
            }
        }
        private Interview interview;

        public Interview Interview
        {
            get { return interview; }
            set
            {
                interview = value;
                OnPropertyChanged("InterView");
            }
        }


        private Visibility showUpdateEmail;
        public Visibility ShowUpdateEmail
        {
            get { return showUpdateEmail; }
            set
            {
                showUpdateEmail = value;
                OnPropertyChanged("ShowUpdateEmail");
            }
        }
        private Visibility showAddCandidate;
        public Visibility ShowAddCandidate
        {
            get { return showAddCandidate; }
            set
            {
                showAddCandidate = value;
                OnPropertyChanged("ShowAddCandidate");
            }
        }
        private List<Titles> listTitle;

        public List<Titles> ListTitle
        {
            get { return listTitle; }
            set
            {
                listTitle = value;
                OnPropertyChanged("ListTitle");
            }
        }
        private List<Position> listPosition;

        public List<Position> ListPosition
        {
            get { return listPosition; }
            set
            {
                listPosition = value;
                OnPropertyChanged("ListPosition");
            }
        }

        private List<Candidate_Apply> listCA;

        public List<Candidate_Apply> ListCA
        {
            get { return listCA; }
            set
            {
                listCA = value;
                OnPropertyChanged("ListCA");
            }
        }
        private List<Candidate_Apply> candidate_Applies;

        public List<Candidate_Apply> Candidate_Applies
        {
            get { return candidate_Applies; }
            set
            {
                candidate_Applies = value;
                OnPropertyChanged("Candidate_Applies");
            }
        }


        private List<SortType> sortInterView;

        public List<SortType> SortInterView
        {
            get { return sortInterView; }
            set { sortInterView = value; }
        }


        private string keyWord;

        public string KeyWord
        {
            get { return keyWord; }
            set
            {
                keyWord = value;
                OnPropertyChanged("KeyWord");
            }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }
        private List<Candidate> listCandidate;

        public List<Candidate> ListCandidate
        {
            get { return listCandidate; }
            set
            {
                listCandidate = value;
                OnPropertyChanged("ListCandidate");
            }
        }
        private List<Employee> listEmployee;

        public List<Employee> ListEmployee
        {
            get { return listEmployee; }
            set
            {
                listEmployee = value;
                OnPropertyChanged("ListEmployee");
            }
        }

        private List<Presenter> listPresenter;

        public List<Presenter> ListPresenter
        {
            get { return listPresenter; }
            set
            {
                listPresenter = value;
                OnPropertyChanged("ListPresenter");
            }
        }
        private int positionID;

        public int PositionID
        {
            get { return positionID; }
            set
            {
                positionID = value;
                OnPropertyChanged("PositionID");
            }
        }

        private int presenterID;

        public int PresenterID
        {
            get { return presenterID; }
            set
            {
                presenterID = value;
                OnPropertyChanged("PresenterID");
            }
        }

        private int titleID;

        public int TitleID
        {
            get { return titleID; }
            set
            {
                titleID = value;
                OnPropertyChanged("TitleID");
            }
        }

        private int testPoint;

        public int TestPoint
        {
            get { return testPoint; }
            set
            {
                testPoint = value;
                OnPropertyChanged("TestPoint");
            }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }
        private MemoryStream sourceCV;

        public MemoryStream SourceCV
        {
            get { return sourceCV; }
            set
            {
                sourceCV = value;
                OnPropertyChanged("SourceCV");
            }
        }
        private bool enableListEmail;

        public bool EnableListEmail
        {
            get { return enableListEmail; }
            set
            {
                enableListEmail = value;
                OnPropertyChanged("EnableListEmail");
            }
        }
        private bool enableUpdateMail;

        public bool EnableUpdateMail
        {
            get { return enableUpdateMail; }
            set
            {
                enableUpdateMail = value;
                OnPropertyChanged("EnableUpdateMail");
            }
        }
        private bool enableListCandidate;

        public bool EnableListCandidate
        {
            get { return enableListCandidate; }
            set
            {
                enableListCandidate = value;
                OnPropertyChanged("EnableListCandidate");
            }
        }
        private bool acceptButton;

        public bool AcceptButton
        {
            get { return acceptButton; }
            set
            {
                acceptButton = value;
                OnPropertyChanged("AcceptButton");
            }
        }
        private bool removeButton;

        public bool RemoveButton
        {
            get { return removeButton; }
            set
            {
                removeButton = value;
                OnPropertyChanged("RemoveButton");
            }
        }
        private bool enableCheckTask;

        public bool EnableCheckTask
        {
            get { return enableCheckTask; }
            set {
                enableCheckTask = value;
                OnPropertyChanged("EnableCheckTask");
            }
        }


        private bool checkAll;

        public bool CheckAll
        {
            get { return checkAll; }
            set
            {
                checkAll = value;
                OnPropertyChanged("CheckAll");
                LoadListCA();
                foreach (Candidate_Apply item in Candidate_Applies)
                {
                    item.IsChecked = checkAll;
                }
            }
        }
        private bool checkAllTask;

        public bool CheckAllTask
        {
            get { return checkAllTask; }
            set
            {
                checkAllTask = value;
                OnPropertyChanged("CheckAllTask");
                LoadListCA();
                foreach (Candidate_Apply item in ListCA)
                {
                    item.IsChecked = checkAllTask;
                }
            }
        }
        private bool enableInputEmail;

        public bool EnableInputEmail
        {
            get { return enableInputEmail; }
            set
            {
                enableInputEmail = value;
                OnPropertyChanged("EnableInputEmail");
            }
        }
        private Visibility showNote;

        public Visibility ShowNote
        {
            get { return showNote; }
            set
            {
                showNote = value;
                OnPropertyChanged("ShowNote");
            }
        }
        private Visibility showPopPoint;

        public Visibility ShowPopPoint
        {
            get { return showPopPoint; }
            set
            {
                showPopPoint = value;
                OnPropertyChanged("ShowPopPoint");
            }
        }
        private string attachmentName;

        public string AttachmentName
        {
            get { return attachmentName; }
            set
            {
                attachmentName = value;
                OnPropertyChanged("AttachmentName");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelBase()
        {
            enableListCandidate = enableListEmail = isAdd = true;
            enableInputEmail = false;
            showPopPoint = showPopInterview = showNote = showAddCandidate = showConfirmEmail = showUpdateEmail = showPopEmail = statusButton = Visibility.Hidden;
            db = new AppDbContext();
            LoadCandidate();
            LoadListCA();
            LoadListEmployee();
            listTitle = db.Titles.ToList();
            listPosition = db.Position.ToList();
            listPresenter = db.Presenter.ToList();
            titleID = presenterID = positionID = 1;
        }
        private void LoadListEmployee()
        {
            ListEmployee = db.Employee.ToList();
        }
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            if (isAdd == true)
                            {
                                candidate.PositionId = PositionID;
                                candidate.TitleID = TitleID;
                                candidate.PresenterId = PresenterID;
                                candidate.CVFile = fileCV;
                                candidate.CVFileName = FileName;
                                db.Candidate.Add(Candidate);
                                db.SaveChanges();
                                LoadCandidate();
                            }
                            else
                            {
                                candidate.PositionId = PositionID;
                                candidate.TitleID = TitleID;
                                candidate.PresenterId = PresenterID;
                                if (!candidate.CVFileName.Equals(FileName))
                                {
                                    candidate.CVFile = fileCV;
                                    candidate.CVFileName = FileName;
                                }
                                db.Candidate.Update(Candidate);
                                db.SaveChanges();
                                LoadCandidate();
                            }
                            EnableListCandidate = true;
                            ShowAddCandidate = Visibility.Hidden;
                            Candidate = null;
                            PositionID = listPosition[0].Id;
                            PresenterID = listPresenter[0].Id;
                            TitleID = listPresenter[0].Id;
                            fileCV = null;
                            FileName = "";
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand _saveInterviewCommand;

        public RelayCommand SaveInterviewCommand
        {
            get
            {
                return _saveInterviewCommand ??
                    (_saveInterviewCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            if (isCheckInterview == true)
                            {
                                Interview.Candidate_ApplyId = candidateApplyId;
                                Interview.Status = oldStatus + 1;
                                db.Interview.Add(Interview);
                                List<Interview> interviews = db.Interview.ToList();
                                Interview _interview = interviews[interviews.Count - 1];
                                foreach (var item in listEmployee)
                                {
                                    if (item.IsChecked)
                                    {
                                        Interview_Employee interview_Employee = new Interview_Employee();
                                        interview_Employee.EmployeeId = item.Id;
                                        interview_Employee.InterViewId = _interview.Id;
                                        db.interview_Employee.Add(interview_Employee);
                                    }
                                }
                                db.SaveChanges();
                            }
                            else
                            {
                                db.Interview.Update(Interview);
                                List<Interview_Employee> list = db.interview_Employee.Where(x => x.InterViewId.Equals(Interview.Id)).ToList();
                                foreach (var itemIE in list)
                                {
                                    db.interview_Employee.Remove(itemIE);
                                }
                                foreach (var item in listEmployee)
                                {
                                    if (item.IsChecked)
                                    {
                                        Interview_Employee interview_Employee = new Interview_Employee();
                                        interview_Employee.EmployeeId = item.Id;
                                        interview_Employee.InterViewId = Interview.Id;
                                        db.interview_Employee.Add(interview_Employee);
                                    }
                                }
                                db.SaveChanges();
                            }
                            LoadCandidate();
                            LoadListEmployee();
                            LoadListTask(Status);
                            EnableListCandidate = true;
                            ShowPopInterview = Visibility.Hidden;
                            Interview = null;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _chooseFileCommand;

        public RelayCommand ChooseFileCommand
        {
            get
            {
                return _chooseFileCommand ??
                    (_chooseFileCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            if (openFileDialog.ShowDialog() == true)
                            {
                                FileName = openFileDialog.SafeFileName;
                                fileCV = File.ReadAllBytes(openFileDialog.FileName);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _okPointCommand;

        public RelayCommand OkPointCommand
        {
            get
            {
                return _okPointCommand ??
                    (_okPointCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            CandidateApply.TestPoint = TestPoint;
                            MessageBox.Show(TestPoint.ToString());
                            db.Candidate_Apply.Update(CandidateApply);
                            db.SaveChanges();
                            ShowPopPoint = Visibility.Hidden;
                            EnableListEmail = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _okNoteCommand;

        public RelayCommand OkNoteCommand
        {
            get
            {
                return _okNoteCommand ??
                    (_okNoteCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            CandidateApply.IsAccept = false;
                            CandidateApply.Note = NoteRefuse;
                            db.Candidate_Apply.Update(CandidateApply);
                            db.SaveChanges();
                            ShowNote = Visibility.Hidden;
                            EnableListEmail = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _exitPointCommand;

        public RelayCommand ExitPointCommand
        {
            get
            {
                return _exitPointCommand ??
                    (_exitPointCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            ShowPopPoint = Visibility.Hidden;
                            enableListEmail = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _exitNoteCommand;

        public RelayCommand ExitNoteCommand
        {
            get
            {
                return _exitNoteCommand ??
                    (_exitNoteCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            ShowNote = Visibility.Hidden;
                            EnableListEmail = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _enableUpdateMailCommand;

        public RelayCommand EnableUpdateMailCommand
        {
            get
            {
                return _enableUpdateMailCommand ??
                    (_enableUpdateMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            EnableInputEmail = true;
                            EnableUpdateMail = false;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }


        private RelayCommand _chooseattachmentCommand;

        public RelayCommand ChooseAttachmentCommand
        {
            get
            {
                return _chooseattachmentCommand ??
                    (_chooseattachmentCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            if (openFileDialog.ShowDialog() == true)
                            {
                                AttachmentName = openFileDialog.SafeFileName;
                                attachment = File.ReadAllBytes(openFileDialog.FileName);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand _cancelNoteCommand;

        public RelayCommand CancelNoteCommand
        {
            get
            {
                return _cancelNoteCommand ??
                    (_cancelNoteCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            ShowNote = Visibility.Hidden;
                            EnableListCandidate = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand _openAddCommand;

        public RelayCommand OpenAddCommand
        {
            get
            {
                return _openAddCommand ??
                    (_openAddCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            Candidate = new Candidate();
                            Candidate.BirthDay = DateTime.Now;
                            TitlePopSave = "Thêm ứng viên";
                            ButtonContent = "Import";
                            EnableListCandidate = false;
                            ShowAddCandidate = Visibility.Visible;
                            isAdd = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand _openCheckCVCommand;

        public RelayCommand OpenCheckCVCommand
        {
            get
            {
                return _openCheckCVCommand ??
                    (_openCheckCVCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            frmListCandidate_Apply frmListCandidate_Apply = new frmListCandidate_Apply();
                            frmListCandidate_Apply.Show();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand _exitSaveCommand;

        public RelayCommand ExitSaveCommand
        {
            get
            {
                return _exitSaveCommand ??
                    (_exitSaveCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            EnableListCandidate = true;
                            Candidate = null;
                            PositionID = listPosition[0].Id;
                            PresenterID = listPresenter[0].Id;
                            TitleID = listPresenter[0].Id;
                            fileCV = null;
                            FileName = "";
                            ShowAddCandidate = Visibility.Hidden;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }
        private RelayCommand _exitPopInterView;

        public RelayCommand ExitPopInterView
        {
            get
            {
                return _exitPopInterView ??
                    (_exitPopInterView = new RelayCommand(p =>
                    {
                        try
                        {
                            ShowPopInterview = Visibility.Hidden;
                            EnableListCandidate = true;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        private RelayCommand searchBasicCommand;
        public RelayCommand SearchBasicCommand
        {
            get
            {
                return searchBasicCommand ??
                    (searchBasicCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            int i = 1;
                            ListCandidate = db.Candidate.Where(x => x.PositionId.Equals(positionID) && x.TitleID.Equals(titleID)).ToList();
                            foreach (Candidate item in ListCandidate)
                            {
                                item.CandiDate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                                item.SortNumber = i;
                                i++;
                                string[] str = item.CVFileName.Split('.');
                                if (item.CandiDate_Apply != null)
                                {
                                    if (item.CandiDate_Apply.Status == 1)
                                    {
                                        item.AcceptButton = true;
                                        item.RemoveButton = false;
                                    }
                                    else
                                    {
                                        item.AcceptButton = false;
                                        item.RemoveButton = true;
                                    }
                                }
                                else
                                {

                                    item.AcceptButton = true;
                                    item.RemoveButton = true;
                                }
                                if (str[1].ToLower().Equals("pdf"))
                                {

                                    item.IsAction = Visibility.Hidden;
                                    item.IsView = Visibility.Visible;
                                }
                                else
                                {
                                    item.IsAction = Visibility.Visible;
                                    item.IsView = Visibility.Hidden;
                                }
                                item.ViewCV = new RelayCommand(p => {

                                    if (item.CandiDate_Apply != null)
                                    {
                                        if (item.CandiDate_Apply.Status == 1)
                                        {
                                            AcceptButton = true;
                                            RemoveButton = false;
                                        }
                                        else
                                        {
                                            AcceptButton = false;
                                            RemoveButton = true;
                                        }
                                    }
                                    else
                                    {

                                        AcceptButton = true;
                                        RemoveButton = true;
                                    }
                                    Candidate = item;
                                    ViewCVTitle = "Xem cv ứng viên: " + item.FullName;
                                    EnableListCandidate = false;
                                    StatusButton = Visibility.Visible;
                                    FileName = item.CVFileName;
                                    SourceCV = new MemoryStream(item.CVFile);
                                    CheckCv();
                                });
                                item.Edit = new RelayCommand(p => {
                                    isAdd = false;
                                    EnableListCandidate = false;
                                    ShowAddCandidate = Visibility.Visible;
                                    ButtonContent = "Save";
                                    Candidate = item;
                                    PresenterID = item.PresenterId;
                                    PositionID = item.PositionId;
                                    TitleID = item.TitleID;
                                    FileName = item.CVFileName;
                                    TitlePopSave = "Chỉnh sửa thông tin ứng viên";
                                });
                                item.Delete = new RelayCommand(p => {
                                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                    {
                                        db.Candidate.Remove(item);
                                        db.SaveChanges();
                                        LoadCandidate();
                                    }
                                });
                                item.Save = new RelayCommand(p => {
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    saveFileDialog.FileName = item.CVFileName;
                                    saveFileDialog.Filter = "Pdf Files|*.pdf";
                                    if (saveFileDialog.ShowDialog() == true)
                                        File.WriteAllBytes(saveFileDialog.FileName, item.CVFile);
                                });
                                item.Accept = new RelayCommand(p =>
                                {
                                    Candidate_Apply candidate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                                    if (candidate_Apply != null)
                                    {
                                        candidate_Apply.Status = 2;
                                        db.Candidate_Apply.Update(candidate_Apply);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        db.Candidate_Apply.Add(new Candidate_Apply(item.Id, 2, null, null, null, false, null, null));
                                        db.SaveChanges();
                                    }
                                    MessageBox.Show("Accept thành công!");
                                    LoadCandidate();
                                });
                                item.Remove = new RelayCommand(p =>
                                {
                                    candidateID = item.Id;
                                    ShowNote = Visibility.Visible;
                                    EnableListCandidate = false;
                                });
                                item.ChangeCheck = new RelayCommand(p =>
                                {
                                    if (item.IsChecked)
                                    {
                                        item.IsChecked = false;
                                    }
                                    else
                                    {
                                        item.IsChecked = true;
                                    }
                                });
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }

        private RelayCommand advancedSearchCommand;
        public RelayCommand AdvancedSearchCommand
        {
            get
            {
                return advancedSearchCommand ??
                    (advancedSearchCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            int i = 1;
                            ListCandidate = db.Candidate.Where(x => x.FullName.Contains(keyWord) || x.Email.Contains(keyWord) || x.Address.Contains(keyWord) || x.Phone.Contains(keyWord)).ToList();
                            foreach (Candidate item in ListCandidate)
                            {
                                item.CandiDate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                                item.SortNumber = i;
                                i++;
                                string[] str = item.CVFileName.Split('.');
                                if (item.CandiDate_Apply != null)
                                {
                                    if (item.CandiDate_Apply.Status == 1)
                                    {
                                        item.AcceptButton = true;
                                        item.RemoveButton = false;
                                    }
                                    else
                                    {
                                        item.AcceptButton = false;
                                        item.RemoveButton = true;
                                    }
                                }
                                else
                                {

                                    item.AcceptButton = true;
                                    item.RemoveButton = true;
                                }
                                if (str[1].ToLower().Equals("pdf"))
                                {

                                    item.IsAction = Visibility.Hidden;
                                    item.IsView = Visibility.Visible;
                                }
                                else
                                {
                                    item.IsAction = Visibility.Visible;
                                    item.IsView = Visibility.Hidden;
                                }
                                item.ViewCV = new RelayCommand(p => {

                                    if (item.CandiDate_Apply != null)
                                    {
                                        if (item.CandiDate_Apply.Status == 1)
                                        {
                                            AcceptButton = true;
                                            RemoveButton = false;
                                        }
                                        else
                                        {
                                            AcceptButton = false;
                                            RemoveButton = true;
                                        }
                                    }
                                    else
                                    {

                                        AcceptButton = true;
                                        RemoveButton = true;
                                    }
                                    Candidate = item;
                                    ViewCVTitle = "Xem cv ứng viên: " + item.FullName;
                                    EnableListCandidate = false;
                                    StatusButton = Visibility.Visible;
                                    FileName = item.CVFileName;
                                    SourceCV = new MemoryStream(item.CVFile);
                                    CheckCv();
                                });
                                item.Edit = new RelayCommand(p => {
                                    isAdd = false;
                                    EnableListCandidate = false;
                                    ShowAddCandidate = Visibility.Visible;
                                    ButtonContent = "Save";
                                    Candidate = item;
                                    PresenterID = item.PresenterId;
                                    PositionID = item.PositionId;
                                    TitleID = item.TitleID;
                                    FileName = item.CVFileName;
                                    TitlePopSave = "Chỉnh sửa thông tin ứng viên";
                                });
                                item.Delete = new RelayCommand(p => {
                                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                    {
                                        db.Candidate.Remove(item);
                                        db.SaveChanges();
                                        LoadCandidate();
                                    }
                                });
                                item.Save = new RelayCommand(p => {
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    saveFileDialog.FileName = item.CVFileName;
                                    saveFileDialog.Filter = "Pdf Files|*.pdf";
                                    if (saveFileDialog.ShowDialog() == true)
                                        File.WriteAllBytes(saveFileDialog.FileName, item.CVFile);
                                });
                                item.Accept = new RelayCommand(p =>
                                {
                                    Candidate_Apply candidate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                                    if (candidate_Apply != null)
                                    {
                                        candidate_Apply.Status = 2;
                                        db.Candidate_Apply.Update(candidate_Apply);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        db.Candidate_Apply.Add(new Candidate_Apply(item.Id, 2, null, null, null, false, null, null));
                                        db.SaveChanges();
                                    }
                                    MessageBox.Show("Accept thành công!");
                                    LoadCandidate();
                                });
                                item.Remove = new RelayCommand(p =>
                                {
                                    candidateID = item.Id;
                                    ShowNote = Visibility.Visible;
                                    EnableListCandidate = false;
                                });
                                item.ChangeCheck = new RelayCommand(p =>
                                {
                                    if (item.IsChecked)
                                    {
                                        item.IsChecked = false;
                                    }
                                    else
                                    {
                                        item.IsChecked = true;
                                    }
                                });
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }

        private RelayCommand resetTableCommand;
        public RelayCommand ResetTableCommand
        {
            get
            {
                return resetTableCommand ??
                    (resetTableCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            LoadCandidate();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }
        private RelayCommand closePDFCommand;
        public RelayCommand ClosePDFCommand
        {
            get
            {
                return closePDFCommand ??
                    (closePDFCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            EnableListCandidate = true;
                            StatusButton = Visibility.Hidden;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }
        private RelayCommand saveNoteCommand;
        public RelayCommand SaveNoteCommand
        {
            get
            {
                return saveNoteCommand ??
                    (saveNoteCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            Candidate_Apply candidate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(candidate.Id));
                            if (candidate_Apply != null)
                            {
                                candidate_Apply.Status = 1;
                                db.Candidate_Apply.Update(candidate_Apply);
                                db.SaveChanges();
                            }
                            else
                            {
                                db.Candidate_Apply.Add(new Candidate_Apply(candidate.Id, 1, null, null, null, false, null, null));
                                db.SaveChanges();
                            }
                            LoadCandidate();
                            ShowNote = Visibility.Hidden;
                            EnableListCandidate = true;
                            candidate = null;
                            AcceptButton = true;
                            RemoveButton = false;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }
        private RelayCommand createMailCommand;
        public RelayCommand CreateMailCommand
        {
            get
            {
                return createMailCommand ??
                    (createMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            EnableUpdateMail = false;
                            ShowPopEmail = ShowConfirmEmail = Visibility.Visible;
                            EnableInputEmail = true;
                            EnableListEmail = false;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }
        private RelayCommand confirmMailCommand;
        public RelayCommand ConfirmMailCommand
        {
            get
            {
                return confirmMailCommand ??
                    (confirmMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            foreach (Candidate_Apply item in Candidate_Applies)
                            {
                                if (item.IsChecked == true)
                                {
                                    item.Title = TitleEmail;
                                    item.ContentEmail = ContentEmail;
                                    if (item.Attachment_Name != null)
                                    {
                                        if (!item.Attachment_Name.Equals(AttachmentName))
                                        {
                                            item.Attachment = attachment;
                                            item.Attachment_Name = AttachmentName;
                                        }
                                    }
                                    else
                                    {
                                        item.Attachment = attachment;
                                        item.Attachment_Name = AttachmentName;
                                    }
                                    db.Candidate_Apply.Update(item);
                                    db.SaveChanges();
                                }
                            }
                            TitleEmail = AttachmentName = ContentEmail = "";
                            ShowConfirmEmail = ShowPopEmail = Visibility.Hidden;
                            EnableInputEmail = false;
                            EnableListEmail = true;
                            LoadListCA();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }


        private RelayCommand updateMailCommand;
        public RelayCommand UpdateMailCommand
        {
            get
            {
                return updateMailCommand ??
                    (updateMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            CandidateApply.Title = TitleEmail;
                            CandidateApply.ContentEmail = ContentEmail;
                            if (!CandidateApply.Attachment_Name.Equals(AttachmentName))
                            {
                                CandidateApply.Attachment = attachment;
                                CandidateApply.Attachment_Name = AttachmentName;
                            }
                            db.Candidate_Apply.Update(CandidateApply);
                            db.SaveChanges();
                            TitleEmail = AttachmentName = ContentEmail = "";
                            ShowUpdateEmail = ShowPopEmail = Visibility.Hidden;
                            EnableInputEmail = false;
                            EnableListEmail = true;
                            CandidateApply = null;
                            LoadListCA();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }


        private RelayCommand sendMailCommand;
        public RelayCommand SendMailCommand
        {
            get
            {
                return sendMailCommand ??
                    (sendMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            foreach (Candidate_Apply item in Candidate_Applies)
                            {
                                if (item.IsChecked == true)
                                {
                                    Attachment attachment = null;
                                    if (item.Attachment != null)
                                    {
                                        MemoryStream ms = new MemoryStream(item.Attachment);
                                        attachment = new Attachment(ms, item.Attachment_Name);
                                    }
                                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                    client.Credentials = new NetworkCredential("tt21052000@gmail.com", "T21052000@");
                                    client.EnableSsl = true;
                                    MailMessage message = new MailMessage("tt21052000@gmail.com", item.Candidate.Email, item.Title, item.ContentEmail);
                                    if (attachment != null)
                                    {
                                        message.Attachments.Add(attachment);
                                    }
                                    client.Host = "smtp.gmail.com";
                                    client.Send(message);
                                    client.Dispose();
                                    Interview = new Interview();
                                    Interview.Candidate_ApplyId = item.CandidateId;
                                    Interview.Status = 3;
                                    db.Interview.Add(Interview);
                                    db.SaveChanges();
                                }
                            }
                            MessageBox.Show("Gửi thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }

        private RelayCommand exitMailCommand;
        public RelayCommand ExitMailCommand
        {
            get
            {
                return exitMailCommand ??
                    (exitMailCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            TitleEmail = AttachmentName = ContentEmail = "";
                            ShowConfirmEmail = ShowUpdateEmail = ShowPopEmail = Visibility.Hidden;
                            EnableInputEmail = false;
                            EnableListEmail = true;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }

        private void CheckCv()
        {
            Candidate.Accept = new RelayCommand(p =>
            {
                Candidate_Apply candidate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(candidate.Id));
                if (candidate_Apply != null)
                {
                    candidate_Apply.Status = 2;
                    db.Candidate_Apply.Update(candidate_Apply);
                    db.SaveChanges();
                }
                else
                {
                    db.Candidate_Apply.Add(new Candidate_Apply(candidate.Id, 2, null, null, null, false, null, null));
                    db.SaveChanges();
                }
                LoadCandidate();
                EnableListCandidate = true;
                StatusButton = Visibility.Hidden;
                MessageBox.Show("Accept thành công!");
                candidate = null;
                AcceptButton = false;
                RemoveButton = true;
            });
            Candidate.Remove = new RelayCommand(p =>
            {
                ShowNote = Visibility.Visible;
                EnableListCandidate = false;

            });
        }

        private void LoadCandidate()
        {
            int i = 1;
            ListCandidate = db.Candidate.ToList();
            foreach (Candidate item in ListCandidate)
            {
                item.CandiDate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                item.SortNumber = i;
                i++;
                string[] str = item.CVFileName.Split('.');
                if (item.CandiDate_Apply != null)
                {
                    if (item.CandiDate_Apply.Status == 1)
                    {
                        item.AcceptButton = true;
                        item.RemoveButton = false;
                    }
                    else
                    {
                        item.AcceptButton = false;
                        item.RemoveButton = true;
                    }
                }
                else
                {

                    item.AcceptButton = true;
                    item.RemoveButton = true;
                }
                if (str[1].ToLower().Equals("pdf"))
                {

                    item.IsAction = Visibility.Hidden;
                    item.IsView = Visibility.Visible;
                }
                else
                {
                    item.IsAction = Visibility.Visible;
                    item.IsView = Visibility.Hidden;
                }
                item.ViewCV = new RelayCommand(p => {

                    if (item.CandiDate_Apply != null)
                    {
                        if (item.CandiDate_Apply.Status == 1)
                        {
                            AcceptButton = true;
                            RemoveButton = false;
                        }
                        else
                        {
                            AcceptButton = false;
                            RemoveButton = true;
                        }
                    }
                    else
                    {

                        AcceptButton = true;
                        RemoveButton = true;
                    }
                    Candidate = item;
                    ViewCVTitle = "Xem cv ứng viên: " + item.FullName;
                    EnableListCandidate = false;
                    StatusButton = Visibility.Visible;
                    FileName = item.CVFileName;
                    SourceCV = new MemoryStream(item.CVFile);
                    CheckCv();
                });
                item.Edit = new RelayCommand(p => {
                    isAdd = false;
                    EnableListCandidate = false;
                    ShowAddCandidate = Visibility.Visible;
                    ButtonContent = "Save";
                    Candidate = item;
                    PresenterID = item.PresenterId;
                    PositionID = item.PositionId;
                    TitleID = item.TitleID;
                    FileName = item.CVFileName;
                    TitlePopSave = "Chỉnh sửa thông tin ứng viên";
                });
                item.Delete = new RelayCommand(p => {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        db.Candidate.Remove(item);
                        db.SaveChanges();
                        LoadCandidate();
                    }
                });
                item.Save = new RelayCommand(p => {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = item.CVFileName;
                    saveFileDialog.Filter = "Pdf Files|*.pdf";
                    if (saveFileDialog.ShowDialog() == true)
                        File.WriteAllBytes(saveFileDialog.FileName, item.CVFile);
                });
                item.Accept = new RelayCommand(p =>
                {
                    Candidate_Apply candidate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                    if (candidate_Apply != null)
                    {
                        candidate_Apply.Status = 2;
                        db.Candidate_Apply.Update(candidate_Apply);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Candidate_Apply.Add(new Candidate_Apply(item.Id, 2, null, null, null, false, null, null));
                        db.SaveChanges();
                    }
                    MessageBox.Show("Accept thành công!");
                    LoadCandidate();
                });
                item.Remove = new RelayCommand(p =>
                {
                    candidateID = item.Id;
                    ShowNote = Visibility.Visible;
                    EnableListCandidate = false;
                });
                item.ChangeCheck = new RelayCommand(p =>
                {
                    if (item.IsChecked)
                    {
                        item.IsChecked = false;
                    }
                    else
                    {
                        item.IsChecked = true;
                    }
                });
            }
        }
        private void LoadListCA()
        {
            status = 1;
            int i = 1;
            sortInterView = new List<SortType>();
            sortInterView.Add(new SortType(1, "Tất cả"));
            sortInterView.Add(new SortType(5, "Vòng 1"));
            sortInterView.Add(new SortType(7, "Vòng 2"));
            LoadListTask(Status);
            Candidate_Applies = db.Candidate_Apply.Where(x => x.Status.Equals(2) && (x.IsAccept == null || x.IsAccept == false)).ToList();
            foreach (Candidate_Apply item in Candidate_Applies)
            {
                item.Candidate = db.Candidate.FirstOrDefault(x => x.Id.Equals(item.CandidateId));
                item.Interview = db.Interview.Where(x=>x.Candidate_ApplyId.Equals(item.CandidateId)).ToList();
                item.SortNumber = i;
                i++;
                if (item.Title != null || item.ContentEmail != null)
                {
                    item.Preview = true;
                }
                else
                {
                    item.Preview = false;
                }
                item.ViewEmail = new RelayCommand(p =>
                {
                    EnableUpdateMail = true;
                    EnableListEmail = false;
                    CandidateApply = item;
                    ShowPopEmail = ShowUpdateEmail = Visibility.Visible;
                    EnableInputEmail = false;
                    TitleEmail = item.Title;
                    ContentEmail = item.ContentEmail;
                    AttachmentName = item.Attachment_Name;
                });
                item.AcceptInterView = new RelayCommand(p => {
                    item.IsAccept = true;
                    db.Candidate_Apply.Update(item);
                    Interview = item.Interview[0];
                    Interview.Status = 4;
                    db.Interview.Update(Interview);
                    db.SaveChanges();
                    LoadListCA();
                });
                item.AddPoint = new RelayCommand(p =>
                {
                    CandidateApply = item;
                    TestPoint = 1;
                    ShowPopPoint = Visibility.Visible;
                    enableListEmail = false;
                });
                item.RefuseInterView = new RelayCommand(p =>
                {
                    CandidateApply = item;
                    ShowNote = Visibility.Visible;
                    EnableListEmail = false;
                });
                if (item.Interview != null)
                    item.enablePointButton = true;
                else
                    item.enablePointButton = false;
            }
        }
        private void LoadListTask(int status)
        {
            int i = 1;
            if (status == 1)
            {
                
                ListCA = db.Candidate_Apply.Where(x => x.IsAccept == true).ToList();
                foreach (Candidate_Apply item in ListCA)
                {
                    item.SortNumber = i;
                    i++;
                    item.Candidate = db.Candidate.FirstOrDefault(x => x.Id.Equals(item.CandidateId));
                    item.Interview = db.Interview.Where(x=>x.Candidate_ApplyId.Equals(item.CandidateId)).ToList();
                    int n = item.Interview.Count - 1;
                    switch (item.Interview[n].Status)
                    {
                        case 4:
                            item.Status_Name = "Test OK";
                            break;
                        case 5:
                            item.Status_Name = "Mời pv v1";
                            break;
                        case 6:
                            item.Status_Name = "Pass v1";
                            break;
                        case 7:
                            item.Status_Name = "Mời pv v2";
                            break;
                        case 8:
                            item.Status_Name = "Pass v2";
                            break;
                    }
                    if (item.Interview != null)
                    {
                        item.GetInterView = item.Interview[n];
                    }
                    if (item.Title != null || item.ContentEmail != null)
                    {
                        item.Preview = true;
                    }
                    else
                    {
                        item.Preview = false;
                    }
                    item.ViewEmail = new RelayCommand(p =>
                    {
                        EnableUpdateMail = true;
                        EnableListEmail = false;
                        CandidateApply = item;
                        ShowPopEmail = ShowUpdateEmail = Visibility.Visible;
                        EnableInputEmail = false;
                        TitleEmail = item.Title;
                        ContentEmail = item.ContentEmail;
                        AttachmentName = item.Attachment_Name;
                    });
                    item.AddInterview = new RelayCommand(p =>
                    {
                        TitlePopInterview = "Thêm lịch phỏng vấn cho ứng viên: " + item.Candidate.FullName;
                        ButtonInterviewContent = "Thêm lịch";
                        Interview = new Interview();
                        candidateApplyId = item.CandidateId;
                        oldStatus = item.Interview[n].Status.Value;
                        isCheckInterview = true;
                        ShowPopInterview = Visibility.Visible;
                        EnableListCandidate = false;
                    });
                    item.EditInterview = new RelayCommand(p =>
                    {
                        TitlePopInterview = "Sửa lịch phỏng vấn cho ứng viên: " + item.Candidate.FullName;
                        ButtonInterviewContent = "Sửa lịch";
                        Interview = item.Interview[n];
                        isCheckInterview = false;
                        LoadListEmployee();
                        foreach (Employee itemE in ListEmployee)
                        {
                           Interview_Employee interview = db.interview_Employee.FirstOrDefault(x=>x.EmployeeId.Equals(itemE.Id) && x.InterViewId.Equals(Interview.Id));
                            if (interview != null)
                            {
                                itemE.IsChecked = true;
                            }
                        }
                        ShowPopInterview = Visibility.Visible;
                        EnableListCandidate = false;
                    });
                    item.PassInterview = new RelayCommand(p =>
                    {
                        Interview interview = new Interview();
                        interview.Candidate_ApplyId = item.CandidateId;
                        interview.Status = 6;
                        db.Interview.Add(interview);
                        db.SaveChanges();
                        LoadListTask(Status);
                    });
                    if (item.Interview[n].Status == 5)
                    {
                        item.EnableAddInter = true;
                    }
                    else
                    {
                        item.EnableAddInter = false;
                    }
                }
                if (ListCA != null)
                {
                    EnableCheckTask = true;
                }
                else
                {
                    EnableCheckTask= false;
                }
            }
            else
            {
                ListCA = db.Candidate_Apply.Where(x => x.IsAccept == true).ToList();                
                for (int j = 0; j < ListCA.Count - 1; j++) 
                {
                    ListCA[j].SortNumber = i;
                    i++;
                    ListCA[j].Candidate = db.Candidate.FirstOrDefault(x => x.Id.Equals(ListCA[j].CandidateId));
                    if (ListCA[j].Interview != null)
                    {
                        ListCA[j].Inter = ListCA[j].Interview[ListCA[j].Interview.Count - 1];
                        if (ListCA[j].Inter != null)
                        {
                            if (ListCA[j].Inter.Status == (status - 1) || ListCA[j].Inter.Status == status)
                            {
                                if (ListCA[j].Title != null || ListCA[j].ContentEmail != null)
                                {
                                    ListCA[j].Preview = true;
                                }
                                else
                                {
                                    ListCA[j].Preview = false;
                                }
                                ListCA[j].ViewEmail = new RelayCommand(p =>
                                {
                                    EnableUpdateMail = true;
                                    EnableListEmail = false;
                                    CandidateApply = ListCA[j];
                                    ShowPopEmail = ShowUpdateEmail = Visibility.Visible;
                                    EnableInputEmail = false;
                                    TitleEmail = ListCA[j].Title;
                                    ContentEmail = ListCA[j].ContentEmail;
                                    AttachmentName = ListCA[j].Attachment_Name;
                                });
                                ListCA[j].AddInterview = new RelayCommand(p =>
                                {
                                    TitlePopInterview = "Thêm lịch phỏng vấn cho ứng viên: " + ListCA[j].Candidate.FullName;
                                    ShowPopInterview = Visibility.Visible;
                                    Interview = new Interview();
                                    candidateApplyId = ListCA[j].CandidateId;
                                    oldStatus = ListCA[j].Interview[ListCA[j].Interview.Count - 1].Status.Value;
                                    EnableListCandidate = false;
                                    isCheckInterview = true;
                                }); 
                                ListCA[j].EditInterview = new RelayCommand(p =>
                                {
                                    TitlePopInterview = "Sửa lịch phỏng vấn cho ứng viên: " + ListCA[j].Candidate.FullName;
                                    ButtonInterviewContent = "Sửa lịch";
                                    Interview = ListCA[j].Interview[ListCA[j].Interview.Count - 1];
                                    isCheckInterview = false;
                                    List<Interview_Employee> list = db.interview_Employee.Where(x => x.InterViewId.Equals(Interview.Id)).ToList();
                                    foreach (Employee itemE in ListEmployee)
                                    {
                                        foreach (Interview_Employee itemI in list)
                                        {
                                            if (itemE.Id == itemI.Id)
                                            {
                                                itemE.IsChecked = true;
                                            }
                                        }
                                    }
                                    ShowPopInterview = Visibility.Visible;
                                    EnableListCandidate = false;
                                }); 
                            }
                            else
                            {
                                ListCA.Remove(ListCA[j]);
                            }
                        }
                        else
                        {
                            ListCA.Remove(ListCA[j]);
                        }
                    }
                    else
                    {
                        ListCA.Remove(ListCA[j]);
                    }
                }
                if (ListCA[ListCA.Count-1].Interview == null)
                {
                    ListCA = null;
                }
                else
                {
                    ListCA[ListCA.Count - 1].SortNumber = i;
                    i++;
                    ListCA[ListCA.Count - 1].Candidate = db.Candidate.FirstOrDefault(x => x.Id.Equals(ListCA[ListCA.Count - 1].CandidateId));
                    if (ListCA[ListCA.Count - 1].Interview != null)
                    {
                        ListCA[ListCA.Count - 1].Inter = ListCA[ListCA.Count - 1].Interview[ListCA[ListCA.Count - 1].Interview.Count - 1];
                        if (ListCA[ListCA.Count - 1].Inter != null)
                        {
                            if (ListCA[ListCA.Count - 1].Inter.Status == (status - 1) || ListCA[ListCA.Count - 1].Inter.Status == status)
                            {
                                if (ListCA[ListCA.Count - 1].Title != null || ListCA[ListCA.Count - 1].ContentEmail != null)
                                {
                                    ListCA[ListCA.Count - 1].Preview = true;
                                }
                                else
                                {
                                    ListCA[ListCA.Count - 1].Preview = false;
                                }
                                ListCA[ListCA.Count - 1].ViewEmail = new RelayCommand(p =>
                                {
                                    EnableUpdateMail = true;
                                    EnableListEmail = false;
                                    CandidateApply = ListCA[ListCA.Count - 1];
                                    ShowPopEmail = ShowUpdateEmail = Visibility.Visible;
                                    EnableInputEmail = false;
                                    TitleEmail = ListCA[ListCA.Count - 1].Title;
                                    ContentEmail = ListCA[ListCA.Count - 1].ContentEmail;
                                    AttachmentName = ListCA[ListCA.Count - 1].Attachment_Name;
                                });
                                ListCA[ListCA.Count - 1].AddInterview = new RelayCommand(p =>
                                {
                                    TitlePopInterview = "Thêm lịch phỏng vấn cho ứng viên: " + ListCA[ListCA.Count - 1].Candidate.FullName;
                                    ShowPopInterview = Visibility.Visible;
                                    Interview = new Interview();
                                    isCheckInterview = true;
                                    candidateApplyId = ListCA[ListCA.Count - 1].CandidateId;
                                    oldStatus = ListCA[ListCA.Count - 1].Interview[ListCA[ListCA.Count - 1].Interview.Count - 1].Status.Value;
                                    EnableListCandidate = false;
                                });

                                ListCA[ListCA.Count - 1].EditInterview = new RelayCommand(p =>
                                {
                                    TitlePopInterview = "Sửa lịch phỏng vấn cho ứng viên: " + ListCA[ListCA.Count - 1].Candidate.FullName;
                                    ButtonInterviewContent = "Sửa lịch";
                                    Interview = ListCA[ListCA.Count - 1].Interview[ListCA[ListCA.Count - 1].Interview.Count - 1];
                                    isCheckInterview = false;
                                    List<Interview_Employee> list = db.interview_Employee.Where(x => x.InterViewId.Equals(Interview.Id)).ToList();
                                    foreach (Employee itemE in ListEmployee)
                                    {
                                        foreach (Interview_Employee itemI in list)
                                        {
                                            if (itemE.Id == itemI.Id)
                                            {
                                                itemE.IsChecked = true;
                                            }
                                        }
                                    }
                                    ShowPopInterview = Visibility.Visible;
                                    EnableListCandidate = false;
                                });
                            }
                            else
                            {
                                ListCA = null;
                            }
                        }
                        else
                        {
                            ListCA = null;
                        }
                    }
                }

                if (ListCA != null)
                {
                    EnableCheckTask = true;
                }
                else
                {
                    EnableCheckTask = false;
                }
            }
        }
    }
    public class SortType
    {
        public int Status { get; set; }
        public string Name { get; set; }
        public SortType(int status, string name)
        {
            Status = status;
            Name = name;
        }
    }
}
