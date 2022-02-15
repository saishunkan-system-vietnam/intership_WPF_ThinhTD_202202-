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
using System.Windows;

namespace View.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private AppDbContext db = null;
        int candidateID;
        private byte[] fileCV;
        private bool isAdd { get; set; }
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
        private Visibility showList;
        public Visibility ShowList
        {
            get { return showList; }
            set
            {
                showList = value;
                OnPropertyChanged("ShowList");
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
        private FileStream sourceCV;

        public FileStream SourceCV
        {
            get { return sourceCV; }
            set { 
                sourceCV = value;
                OnPropertyChanged("SourceCV");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelBase()
        {
            showList = Visibility.Visible;
            isAdd = true;
            statusButton = Visibility.Hidden;
            db = new AppDbContext();
            candidate = new Candidate();
            LoadCandidate();
            listTitle = db.Titles.ToList();
            listPosition = db.Position.ToList();
            listPresenter = db.Presenter.ToList();
            titleID = presenterID = positionID = 1;
            candidate.BirthDay = DateTime.Now;
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
                                File.WriteAllBytes(@"..\..\..\CVFiles\" + FileName, fileCV);
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
                                candidate.CVFile = fileCV;
                                candidate.CVFileName = FileName;
                                db.Candidate.Update(Candidate);
                                db.SaveChanges();
                                LoadCandidate();
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }));
            }
        }

        

        private RelayCommand _confirmCommand;

        public RelayCommand ConfirmCommand
        {
            get
            {
                return _confirmCommand ??
                    (_confirmCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            foreach (Candidate candidate in ListCandidate)
                            {
                                
                            }
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
                            ButtonContent = "Import";
                            isAdd = true;
                            popAddCandidate popAddCandidate = new popAddCandidate();
                            popAddCandidate.ShowDialog();
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
                            ListCandidate = db.Candidate.Where(x=>x.PositionId.Equals(positionID) && x.TitleID.Equals(titleID)).ToList();
                            foreach (Candidate item in listCandidate)
                            {
                                item.ViewCV = new RelayCommand(p => {
                                    //popViewCV popViewCV = new popViewCV(item.CVFile);
                                    sourceCV = new FileStream(@"..\..\..\CVFiles\0092-adobe-photoshop-tutorial.pdf", FileMode.Open);
                                    popViewCV popViewCV = new popViewCV();
                                    popViewCV.ShowDialog();
                                });
                                item.Delete = new RelayCommand(p => {
                                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                    {
                                        db.Candidate.Remove(item);
                                        db.SaveChanges();
                                        ListCandidate.Remove(item);
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
                            ListCandidate = db.Candidate.Where(x => x.FullName.Contains(keyWord) || x.Email.Contains(keyWord) || x.Address.Contains(keyWord) || x.Phone.Contains(keyWord)).ToList();
                            foreach (Candidate item in listCandidate)
                            {
                                item.ViewCV = new RelayCommand(p => {
                                    popViewCV popViewCV = new popViewCV();
                                    popViewCV.Show();
                                });
                                item.Delete = new RelayCommand(p => {
                                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                    {
                                        db.Candidate.Remove(item);
                                        db.SaveChanges();
                                        ListCandidate.Remove(item);
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
        private RelayCommand closeWPFCommand;
        public RelayCommand CloseWPFCommand
        {
            get
            {
                return closeWPFCommand ??
                    (closeWPFCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            ShowList = Visibility.Visible;
                            StatusButton = Visibility.Hidden;
                            SourceCV.Close();
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

                            db.Candidate_Apply.Add((new Candidate_Apply(candidateID, 1, Note)));
                            db.SaveChanges();
                            LoadCandidate();
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
                            popEmail popEmail = new popEmail();
                            popEmail.ShowDialog();
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
                            foreach (Candidate item in listCandidate)
                            {
                                if (item.IsChecked == true)
                                {
                                    Candidate_Email candidateEmail = new Candidate_Email();
                                    candidateEmail.CandidateID = item.Id;
                                    candidateEmail.Title = TitleEmail;
                                    candidateEmail.ContentEmail = ContentEmail;
                                    db.Candidate_Email.Add(candidateEmail);
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }));
            }
        }



        private void LoadCandidate()
        {
            int i = 1;
            ListCandidate = db.Candidate.ToList();
            foreach (Candidate item in ListCandidate)
            {
                if (item.Candidate_Email != null)
                {
                    if (item.Candidate_Email.Contactable == 1)
                    {
                        item.IsChecked = true;
                    }
                }
                item.SortNumber = i;
                i++;
                if (item.CandiDate_Apply == null)
                {
                    item.IsAction = Visibility.Visible;
                    item.IsView = Visibility.Hidden;
                }
                else
                {
                    item.IsAction = Visibility.Hidden;
                    item.IsView = Visibility.Visible;
                }
                item.ViewCV = new RelayCommand(p => {
                    ShowList = Visibility.Hidden;
                    StatusButton = Visibility.Visible;
                    FileName = item.CVFileName;
                    SourceCV = new FileStream(@"..\..\..\CVFiles\" + FileName, FileMode.Open);
                    //popViewCV popViewCV = new popViewCV(item.CVFileName);
                    //popViewCV.ShowDialog();
                });
                item.Edit = new RelayCommand(p => {
                    isAdd = false;
                    ButtonContent = "Save";
                    Candidate = item;
                    PresenterID = item.PresenterId;
                    PositionID = item.PositionId;
                    TitleID = item.TitleID;
                    popAddCandidate popAddCandidate = new popAddCandidate();
                    popAddCandidate.ShowDialog();
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
                        File.WriteAllBytes(saveFileDialog.FileName , item.CVFile);
                });
                item.Accept = new RelayCommand(p =>
                {
                    db.Candidate_Apply.Add((new Candidate_Apply(item.Id, 1, null)));
                    db.SaveChanges();
                    LoadCandidate();
                });
                item.Remove = new RelayCommand(p =>
                {
                    candidateID = item.Id;
                    popNote popNote = new popNote();
                    popNote.Show();
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
    }
}
