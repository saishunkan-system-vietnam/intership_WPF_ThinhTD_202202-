using DBContext;
using Microsoft.Win32;
using Model.Entities;
using Services;
using Services.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Candidate candidate;
        private AppDbContext db = null;
        private byte[] fileCV;
        private readonly IDialogService dialogService;

        public Candidate Candidate
        {
            get { return candidate; }
            set {
                candidate = value;
                OnPropertyChanged("Candidate");
            }
        }
        private List<Titles> listTitle;

        public List<Titles> ListTitle
        {
            get { return listTitle; }
            set { 
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
            set {
                listPresenter = value;
                OnPropertyChanged("ListPresenter");
            }
        }
        private int positionID;

        public int PositionID
        {
            get { return positionID; }
            set { 
                positionID = value;
                OnPropertyChanged("PositionID");
            }
        }
        
        private int presenterID;

        public int PresenterID
        {
            get { return presenterID; }
            set { 
                presenterID = value;
                OnPropertyChanged("PresenterID");
            }
        }

        private int titleID;

        public int TitleID
        {
            get { return titleID; }
            set { 
                titleID = value;
                OnPropertyChanged("TitleID");
            }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { 
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelBase() {
            db = new AppDbContext();
            Candidate = new Candidate();
            listTitle = db.Titles.ToList();
            listCandidate = db.Candidate.ToList();
            listPosition = db.Position.ToList();
            listPresenter = db.Presenter.ToList();
            titleID = presenterID = positionID = 1;
            candidate.BirthDay = DateTime.Now;
        }
        public ViewModelBase(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        private RelayCommand _testCommand;

        public RelayCommand TestCommand
        {
            get
            {
                return _testCommand ??
                    (_testCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            candidate.PositionId = PositionID;
                            candidate.TitleID = TitleID;
                            candidate.PresenterId = PresenterID;
                            candidate.CVFile = fileCV;
                            db.Candidate.Add(Candidate);
                            db.SaveChanges();
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
        private RelayCommand openFileCommand;

        public RelayCommand OpenFileCommand
        {
            get {
                return openFileCommand ??
                        (openFileCommand = new RelayCommand(p =>
                        {
                            try
                            {
                                
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }));
            }
        }


    }
}
