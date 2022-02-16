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
        int candidateID;
        private byte[] fileCV, attachment;
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
        private MemoryStream sourceCV;

        public MemoryStream SourceCV
        {
            get { return sourceCV; }
            set { 
                sourceCV = value;
                OnPropertyChanged("SourceCV");
            }
        }
        private bool enableListEmail;

        public bool EnableListEmail
        {
            get { return enableListEmail; }
            set { 
                enableListEmail = value;
                OnPropertyChanged("EnableListEmail");
            }
        }
        private bool enableListCandidate;

        public bool EnableListCandidate
        {
            get { return enableListCandidate; }
            set {
                enableListCandidate = value;
                OnPropertyChanged("EnableListCandidate");
            }
        }
        private bool acceptButton;

        public bool AcceptButton
        {
            get { return acceptButton; }
            set {
                acceptButton = value;
                OnPropertyChanged("AcceptButton");
            }
        }
        private bool removeButton;

        public bool RemoveButton
        {
            get { return removeButton; }
            set {
                removeButton = value;
                OnPropertyChanged("RemoveButton");
            }
        }
        private bool checkAll;

        public bool CheckAll
        {
            get { return checkAll; }
            set {
                checkAll = value;
                OnPropertyChanged("CheckAll");
            }
        }
        private bool enableInputEmail;

        public bool EnableInputEmail
        {
            get { return enableInputEmail; }
            set {
                enableInputEmail = value;
                OnPropertyChanged("EnableInputEmail");
            }
        }
        private Visibility showNote;

        public Visibility ShowNote
        {
            get { return showNote; }
            set {
                showNote = value;
                OnPropertyChanged("ShowNote");
            }
        }
        private string attachmentName;

        public string AttachmentName
        {
            get { return attachmentName; }
            set { 
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
            showNote = showAddCandidate = showConfirmEmail = showUpdateEmail = showPopEmail = statusButton = Visibility.Hidden;
            db = new AppDbContext();
            candidate = new Candidate();
            LoadCandidate();
            CheckCv();
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
                                    //sourceCV = new FileStream(@"..\..\..\CVFiles\0092-adobe-photoshop-tutorial.pdf", FileMode.Open);
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

                            db.Candidate_Apply.Add((new Candidate_Apply(candidate.Id, 1, Note)));
                            db.SaveChanges();
                            LoadCandidate();
                            ShowNote = Visibility.Hidden;
                            EnableListCandidate = true;
                            candidate = null;
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
                            foreach (Candidate item in listCandidate)
                            {
                                if (item.IsChecked == true)
                                {
                                    if (item.Candidate_Email == null)
                                    {
                                        Candidate_Email candidateEmail = new Candidate_Email();
                                        candidateEmail.CandidateID = item.Id;
                                        candidateEmail.Title = TitleEmail;
                                        candidateEmail.ContentEmail = ContentEmail;
                                        candidateEmail.Attachment = attachment;
                                        candidateEmail.Attachment_Name = attachmentName;
                                        db.Candidate_Email.Add(candidateEmail);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        Candidate_Email candidateEmail = item.Candidate_Email;
                                        candidateEmail.Title = TitleEmail;
                                        candidateEmail.ContentEmail = ContentEmail;
                                        if (!candidateEmail.Attachment_Name.Equals(attachmentName))
                                        {
                                            candidateEmail.Attachment_Name = attachmentName;
                                            candidateEmail.Attachment = attachment;
                                        }
                                        db.Candidate_Email.Update(candidateEmail);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            TitleEmail = "";
                            ContentEmail = "";
                            ShowConfirmEmail = ShowPopEmail = Visibility.Hidden;
                            EnableInputEmail = false;
                            EnableListEmail = true;
                            LoadCandidate();
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
                            Candidate_Email candidateEmail = candidate.Candidate_Email;
                            candidateEmail.Title = TitleEmail;
                            candidateEmail.ContentEmail = ContentEmail;
                            db.Candidate_Email.Update(candidateEmail);
                            db.SaveChanges();
                            TitleEmail = "";
                            ContentEmail = "";
                            ShowUpdateEmail = ShowPopEmail = Visibility.Hidden;
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
                            foreach (Candidate item in listCandidate)
                            {
                                if (item.IsChecked == true)
                                {
                                    MemoryStream ms = new MemoryStream(item.Candidate_Email.Attachment);
                                    Attachment attachment = new Attachment(ms, item.Candidate_Email.Attachment_Name);
                                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                    client.Credentials = new NetworkCredential("tt21052000@gmail.com", "T21052000@");
                                    client.EnableSsl = true;
                                    MailMessage message = new MailMessage("tt21052000@gmail.com", item.Email, item.Candidate_Email.Title, item.Candidate_Email.ContentEmail);
                                    if (attachment != null)
                                    {
                                        message.Attachments.Add(attachment);
                                    }
                                    client.Host = "smtp.gmail.com";
                                    client.Send(message);
                                    client.Dispose();
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
                            TitleEmail = "";
                            ContentEmail = "";
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
        
        private RelayCommand checkCandidateCommand;
        public RelayCommand CheckCandidateCommand
        {
            get
            {
                return checkCandidateCommand ??
                    (checkCandidateCommand = new RelayCommand(p =>
                    {
                        try
                        {
                            foreach (Candidate item in ListCandidate)
                            {
                                item.IsChecked = CheckAll;
                            }
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
            candidate.Accept = new RelayCommand(p =>
            {
                db.Candidate_Apply.Add((new Candidate_Apply(candidate.Id, 1, null)));
                db.SaveChanges();
                LoadCandidate();
                EnableListCandidate = true;
                StatusButton = Visibility.Hidden;
                candidate = null;
            });
            candidate.Remove = new RelayCommand(p =>
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
                item.Candidate_Email = db.Candidate_Email.FirstOrDefault(x => x.CandidateID.Equals(item.Id));
                item.CandiDate_Apply = db.Candidate_Apply.FirstOrDefault(x => x.CandidateId.Equals(item.Id));
                if (item.Candidate_Email != null)
                {
                    item.IsViewMail = Visibility.Visible;
                    if (item.Candidate_Email.Contactable == 1)
                    {
                        item.IsChecked = true;
                    }
                }
                else
                {
                    item.IsViewMail = Visibility.Hidden;
                }
                item.SortNumber = i;
                i++;
                string[] str = item.CVFileName.Split('.');
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
                    candidate = item;
                    ViewCVTitle = "Xem cv ứng viên: " + item.FullName;
                    EnableListCandidate = false;
                    StatusButton = Visibility.Visible;
                    FileName = item.CVFileName;
                    SourceCV = new MemoryStream(item.CVFile);
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
                item.ViewEmail = new RelayCommand(p =>
                {
                    EnableListEmail = false;
                    candidate = item;
                    ShowPopEmail = ShowUpdateEmail = Visibility.Visible;
                    EnableInputEmail = true;
                    TitleEmail = item.Candidate_Email.Title;
                    ContentEmail = item.Candidate_Email.ContentEmail;
                });
            }
        }
    }
}
