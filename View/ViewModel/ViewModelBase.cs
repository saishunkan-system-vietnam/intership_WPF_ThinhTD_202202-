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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelBase()
        {
            isAdd = true;
            db = new AppDbContext();
            listTitle = db.Titles.ToList();
            candidate = new Candidate();
            LoadCandidate();            
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


        private RelayCommand _viewCVCommand;

        public RelayCommand ViewCVCommand
        {
            get
            {
                return _viewCVCommand ??
                    (_viewCVCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            popViewCV popViewCV = new popViewCV();
                            popViewCV.Close();
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
                                    popViewCV popViewCV = new popViewCV(item.CVFile);
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
                                    popViewCV popViewCV = new popViewCV(item.CVFile);
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



        private void LoadCandidate()
        {
            ListCandidate = db.Candidate.ToList();
            foreach (Candidate item in listCandidate)
            {
                item.ViewCV = new RelayCommand(p => {
                    popViewCV popViewCV = new popViewCV(item.CVFile);
                    popViewCV.ShowDialog();
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
            }
        }
    }
}
