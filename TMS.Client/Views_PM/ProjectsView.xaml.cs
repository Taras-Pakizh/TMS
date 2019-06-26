using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.Project_Manager.Views
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        static private WebApiServices services = new WebApiServices();
        TaskView newTask = null;
        public ProjectsView()
        {
            InitializeComponent();
            services.Authorization("Pakizh_engineer", "Taras20.");
            dgProjects.ItemsSource = LoadProjectsGrid();
        }
        #region Projects_
        //**********************************************PROJECTS_SECTION_START*******************************************************
        public IEnumerable<ProjectView> LoadProjectsGrid()
        {
            var datagridContent = services.GetAll<ProjectView>();
            return datagridContent;
        }

        public int GetClickedProjectId()
        {
            var selectedItem = dgProjects.SelectedItem as ProjectView;
            return selectedItem.Id;
        }
        public ProjectView GetClickedProject()
        {
            return dgProjects.SelectedItem as ProjectView;
        }
        // Forwarding to list of tasks depending on project clicked
        public void ForwardToTasks()
        {
            dgProjects.Visibility = Visibility.Collapsed;
            dgTasks.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            filterPanel.Visibility = Visibility.Visible;

            int selectedProject = GetClickedProjectId();

            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject &&
                                                            x.status == TMS.Data.ReportStatus.Open);
            chkWithRep.IsChecked = true;
            chkOpen.IsChecked = true;
            dtpickTo.IsEnabled = false;
            dtpickFrom.IsEnabled = false;
        }

        public void DeleteProject(ProjectView _proj)
        {
            //int selectedProject = GetClickedProjectId();
            ConfirmWindow confirmWindow = new ConfirmWindow();
            if (confirmWindow.ShowDialog() == true)
            {
                try
                {
                    if (_proj.Id != 0)
                    {
                        services.Delete<ProjectView>(_proj.Id);
                        MessageBox.Show("The project has been successfully deleted!");
                        dgProjects.ItemsSource = LoadProjectsGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
            }
        }
        //**********************************************PROJECTS_SECTION_END*******************************************************
        #endregion

        #region Tasks_
        //**********************************************TASKS_SECTION_START*******************************************************
        public List<TaskView> GetAllTasks()
        {
            var result = (from tasks in services.GetAll<TaskView>()
                          join proj in services.GetAll<ProjectView>()
                          on tasks.projectId equals proj.Id
                          select new TaskView
                          {
                              Id = tasks.Id,
                              description = tasks.description,
                              effort = tasks.effort,
                              projectId = tasks.projectId,
                              start = proj.start,
                              end = proj.end,
                              projName = proj.name
                          }).ToList();
            return result.ToList();
        }

        public List<TaskView> GetTasksWithReports()
        {
            var result = (from tasks in services.GetAll<TaskView>()
                          join reports in services.GetAll<ReportView>()
                          on tasks.Id equals reports.taskId
                          join appr in services.GetAll<ApproveView>()
                          on reports.Id equals appr.reportId
                          join proj in services.GetAll<ProjectView>()
                          on tasks.projectId equals proj.Id
                          select new TaskView
                          {
                              Id = tasks.Id,
                              description = tasks.description,
                              effort = tasks.effort,
                              projectId = tasks.projectId,
                              start = proj.start,
                              end = proj.end,
                              projName = proj.name,
                              report_id = reports.Id,
                              status = reports.status,
                              approveId = appr.Id
                          }).ToList();
            return result.ToList();
        }

        public TaskView GetClickedTask()
        {
            return dgTasks.SelectedItem as TaskView;
        }

        public void DeleteTask(TaskView _task)
        {
            int selectedProject = GetClickedProjectId();
            ConfirmWindow confirmWindow = new ConfirmWindow();
            if (confirmWindow.ShowDialog() == true)
            {
                try
                {
                    if (_task.Id != 0)
                    {
                        if (chkWithRep.IsChecked == true)
                        {
                            services.Delete<TaskView>(_task.Id);
                            MessageBox.Show("The task has been successfully deleted!");
                            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject);
                            chkWithRep.IsChecked = true;
                        }
                        if (chkWithRep.IsChecked == false)
                        {
                            services.Delete<TaskView>(_task.Id);
                            MessageBox.Show("The task has been successfully deleted!");
                            dgTasks.ItemsSource = GetAllTasks().Where(x => x.projectId == selectedProject);
                            chkWithRep.IsChecked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
            }
        }
        public TaskView AddTask()
        {
            ProjectView newProject = GetClickedProject();
            newTask = new TaskView();
            try
            {
                newTask.description = txtTask.Text;
                newTask.effort = (double)upDown_task.Value;
                newTask.projectId = newProject.Id;
                newTask = services.AddNEW<TaskView>(newTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newTask;
        }
        //**********************************************TASKS_SECTION_END*******************************************************
        #endregion

        #region Reports_
        //**********************************************REPORTS_SECTION_START*******************************************************
        public void ShowReportDetails(TaskView _task)
        {
            if (_task.report_id != 0)
            {
                TaskView task = services.Get<TaskView>(_task.Id);
                var project = services.Get<ProjectView>(task.projectId);

                ReportView _report = services.Get<ReportView>(_task.report_id);
                var engineer = services.Get<UserView>(_report.engineerId);

                txtProjectName.Text = project.name;
                txtDescription.Text = _report.description;
                txtEngineer.Text = engineer.FullName;
                txtEffort.Text = _report.effort.ToString();
                txtStatus.Text = _report.status.ToString();
                txtStart.Text = _report.start.ToString();
                txtEnd.Text = _report.end.ToString();
                popupDetails.IsOpen = true;
            }
            else
            {
                //MessageBox.Show("No");
            }
        }

        public void ApprovedReport(TaskView _task)
        {
            ConfirmWindow confirmWindow = new ConfirmWindow();
            int selectedProject = GetClickedProjectId();
            if (confirmWindow.ShowDialog() == true)
            {
                try
                {
                    TaskView task = services.Get<TaskView>(_task.Id);

                    ReportView _report = services.Get<ReportView>(_task.report_id);
                    _report.status = TMS.Data.ReportStatus.Approved;
                    services.Update<ReportView>(_report);

                    ApproveView apprView = services.Get<ApproveView>(_task.approveId);
                    apprView.isApproved = true;
                    apprView.rootCase = "Approved";
                    apprView.reportId = _report.Id;
                    services.Update<ApproveView>(apprView);

                    if (chkOpen.IsChecked == true)
                    {
                        dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Open);
                    }
                    if (chkAproved.IsChecked == true)
                    {
                        dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Approved);
                    }
                    if (chkDecline.IsChecked == true)
                    {
                        dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Declined);
                    }

                    MessageBox.Show("The report has been successfully approved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { }
        }

        public void DeclineReport(TaskView _task)
        {
            try
            {
                int selectedProject = GetClickedProjectId();
                MessageDecline messageWindow = new MessageDecline();
                if (messageWindow.ShowDialog() == true)
                {
                    if (messageWindow.Message != "")
                    {
                        TaskView task = services.Get<TaskView>(_task.Id);
                        var project = services.Get<ProjectView>(_task.projectId);
                        var projectName = project.name;
                        var projectTask = task.description;

                        ReportView _report = services.Get<ReportView>(_task.report_id);
                        _report.status = TMS.Data.ReportStatus.Declined;
                        var engineer = services.Get<UserView>(_report.engineerId);
                        var email = engineer.email;

                        services.Update<ReportView>(_report);
                        SendEmail(messageWindow.Message, email, projectName, projectTask);
                        ApproveView apprView = services.Get<ApproveView>(_task.approveId);
                        apprView.isApproved = false;
                        apprView.rootCase = messageWindow.Message;
                        apprView.reportId = _report.Id;
                        services.Update<ApproveView>(apprView);

                        if (chkOpen.IsChecked == true)
                        {
                            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Open);
                        }
                        if (chkAproved.IsChecked == true)
                        {
                            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Approved);
                        }
                        if (chkDecline.IsChecked == true)
                        {
                            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject && x.status == TMS.Data.ReportStatus.Declined);
                        }
                        MessageBox.Show($"The Report has been declined! {engineer.FullName} will be informed by email.");
                    }
                    else
                    {
                        MessageBox.Show("Please, enter the reason of decline");
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SendEmail(string message, string email, string projectName, string task)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["SenderEmailId"],
                                                        ConfigurationManager.AppSettings["SenderPassword"]);
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["SenderEmailId"]),
                    Subject = "Declined task",
                    Body = $"Project: {projectName} {Environment.NewLine} " +
                            $"Declined task: {task} {Environment.NewLine} " +
                            $"{Environment.NewLine} {message}"
                };

                mail.To.Add(new MailAddress(email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = ConfigurationManager.AppSettings["SmtpServer"],
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sending email: " + ex.Message);
            }
            //MessageBox.Show("Success");
        }
        //**********************************************REPORTS_SECTION_END*******************************************************
        #endregion

        #region Events

        // Projects Events
        private void MenuTasks_Click(object sender, RoutedEventArgs e)
        {
            ForwardToTasks();
        }

        private void ToTasks_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ForwardToTasks();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dgProjects.Visibility == Visibility.Visible)
            {
                var result = LoadProjectsGrid().Where(x => x.name.ToLower().Contains(txtSearch.Text.ToLower()));
                dgProjects.ItemsSource = result;
            }

            if (dgTasks.Visibility == Visibility.Visible)
            {
                int selectedProject = GetClickedProjectId();
                if (chkWithRep.IsChecked == false)
                {
                    var result_rep = GetAllTasks().Where(x => x.projectId == selectedProject && x.description.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgTasks.ItemsSource = result_rep;
                }
                if (chkWithRep.IsChecked == true)
                {
                    if (chkOpen.IsChecked == true)
                    {
                        var result_without_rep = GetTasksWithReports().Where(x => x.description.ToLower().Contains(txtSearch.Text.ToLower())
                                                                            && x.status == TMS.Data.ReportStatus.Open
                                                                            && x.projectId == selectedProject);
                        dgTasks.ItemsSource = result_without_rep;
                    }
                    if (chkAproved.IsChecked == true)
                    {
                        var result_without_rep = GetTasksWithReports().Where(x => x.description.ToLower().Contains(txtSearch.Text.ToLower())
                                                                            && x.status == TMS.Data.ReportStatus.Approved
                                                                            && x.projectId == selectedProject);
                        dgTasks.ItemsSource = result_without_rep;
                    }
                    if (chkDecline.IsChecked == true)
                    {
                        var result_without_rep = GetTasksWithReports().Where(x => x.description.ToLower().Contains(txtSearch.Text.ToLower())
                                                                            && x.status == TMS.Data.ReportStatus.Declined
                                                                            && x.projectId == selectedProject);
                        dgTasks.ItemsSource = result_without_rep;
                    }
                }
            }
        }

        private void CancelDateFrom_Click(object sender, RoutedEventArgs e)
        {
            dtpickFrom.SelectedDate = null;
            dgProjects.ItemsSource = LoadProjectsGrid();
        }

        private void CancelDateTo_Click(object sender, RoutedEventArgs e)
        {
            dtpickTo.SelectedDate = null;
            dgProjects.ItemsSource = LoadProjectsGrid();
        }

        // Apply filter by dates
        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (dtpickFrom.SelectedDate == null)
            {
                dtpickFrom.SelectedDate = DateTime.Today;
            }
            if (dtpickTo.SelectedDate == null)
            {
                dtpickTo.SelectedDate = DateTime.Today;
            }
            if (dgProjects.Visibility == Visibility.Visible)
            {
                var result = LoadProjectsGrid().Where(x => x.start >= dtpickFrom.SelectedDate && x.end <= dtpickTo.SelectedDate);
                dgProjects.ItemsSource = result;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            dgProjects.Visibility = Visibility.Visible;
            dgTasks.Visibility = Visibility.Collapsed;
            btnBack.Visibility = Visibility.Hidden;
            filterPanel.Visibility = Visibility.Collapsed;
            panelAddTask.Visibility = Visibility.Collapsed;
            btnAddTask.Visibility = Visibility.Collapsed;
            dtpickTo.IsEnabled = true;
            dtpickFrom.IsEnabled = true;
        }

        // Reports Events
        private void MenuReportDetails_Click(object sender, RoutedEventArgs e)
        {
            TaskView task = GetClickedTask();
            ShowReportDetails(task);
        }

        private void ReportDetails_doubleClick(object sender, MouseButtonEventArgs e)
        {
            TaskView task = GetClickedTask();
            ShowReportDetails(task);
        }

        private void MenuApprove_Click(object sender, RoutedEventArgs e)
        {
            TaskView task = GetClickedTask();
            ApprovedReport(task);
        }

        private void MenuDecline_Click(object sender, RoutedEventArgs e)
        {
            TaskView task = GetClickedTask();
            DeclineReport(task);
        }
        private void BtnClosePopup_Click(object sender, RoutedEventArgs e)
        {
            popupDetails.IsOpen = false;
        }

        private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            TaskView task = GetClickedTask();
            DeleteTask(task);
        }

        private void ChkWithRep_Checked(object sender, RoutedEventArgs e)
        {
            chkOpen.Visibility = Visibility.Visible;
            chkAproved.Visibility = Visibility.Visible;
            chkDecline.Visibility = Visibility.Visible;
            panelAddTask.Visibility = Visibility.Collapsed;
            btnAddTask.Visibility = Visibility.Collapsed;
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.projectId == selectedProject);
            chkOpen.IsChecked = true;
        }

        private void ChkWithRep_Unchecked(object sender, RoutedEventArgs e)
        {
            chkOpen.Visibility = Visibility.Hidden;
            chkAproved.Visibility = Visibility.Hidden;
            chkDecline.Visibility = Visibility.Hidden;
            chkOpen.IsChecked = false;
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetAllTasks().Where(x => x.projectId == selectedProject);
            panelAddTask.Visibility = Visibility.Visible;
            btnAddTask.Visibility = Visibility.Visible;
        }

        private void ChkOpen_Checked(object sender, RoutedEventArgs e)
        {
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.status == TMS.Data.ReportStatus.Open && x.projectId == selectedProject);
        }


        private void ChkAproved_Checked(object sender, RoutedEventArgs e)
        {
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.status == TMS.Data.ReportStatus.Approved && x.projectId == selectedProject);
        }

        private void ChkDecline_Checked(object sender, RoutedEventArgs e)
        {
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetTasksWithReports().Where(x => x.status == TMS.Data.ReportStatus.Declined && x.projectId == selectedProject);
        }

        #endregion

        private void BtnDeleteProj_Click(object sender, RoutedEventArgs e)
        {
            ProjectView projectToDelete = GetClickedProject();
            DeleteProject(projectToDelete);
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            var taskToAdd = AddTask();
            txtTask.Text = "";
            upDown_task.Value = 0.0;
            int selectedProject = GetClickedProjectId();
            dgTasks.ItemsSource = GetAllTasks().Where(x => x.projectId == selectedProject);
        }
    }
}
