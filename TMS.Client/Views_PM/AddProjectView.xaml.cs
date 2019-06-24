using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddProjectView.xaml
    /// </summary>
    public partial class AddProjectView : UserControl
    {
        static private WebApiServices services = new WebApiServices();
        ProjectView newProject = null;
        TaskView newTask = null;
        TaskView _taskToDelete = null;
        public AddProjectView()
        {
            InitializeComponent();
            services.Authorization("Pakizh_engineer", "Taras20.");
            btnClear.IsEnabled = false;
        }
        public ProjectView Addproject()
        {
            newProject = new ProjectView();
            try
            {
                newProject.name = txtProjectName.Text;
                newProject.abbreviation = txtAbbreviation.Text;
                newProject.description = txtDescription.Text;
                newProject.effort = (double)upDownProject.Value;
                newProject.start = (DateTime)dtpickFrom.SelectedDate;
                newProject.end = (DateTime)dtpickTo.SelectedDate;
                newProject = services.AddNEW<ProjectView>(newProject);
                MessageBox.Show("A project has been added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newProject;
        }

        public TaskView AddTask()
        {
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

        //public void DeleteTask(TaskView toDelete)
        //{
        //    try
        //    {
        //        if (toDelete != null)
        //        {
        //            var result = services.Delete<TaskView>(toDelete.Id);                    
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please, select a task");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void BtnAddProject_Click(object sender, RoutedEventArgs e)
        {
            Addproject();
            panelAddTask.Visibility = Visibility.Visible;
            btnAddProject.IsEnabled = false;
            btnClear.IsEnabled = true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtProjectName.Text = "";
            txtAbbreviation.Text = "";
            txtDescription.Text = "";
            upDownProject.Value = 0.0;
            dtpickFrom.SelectedDate = null;
            dtpickTo.SelectedDate = null;
            txtTask.Text = "";
            upDown_task.Value = 0.0;
            listBoxTasks.Items.Clear();
            btnAddProject.IsEnabled = true;
            //btnDeleteTask.IsEnabled = false;
            panelAddTask.Visibility = Visibility.Hidden;
            btnClear.IsEnabled = false;
        }

        //private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        //{           
        //    DeleteTask(_taskToDelete);
        //}


        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            var taskToAdd = AddTask();
            listBoxTasks.Items.Add(taskToAdd);
            txtTask.Text = "";
            upDown_task.Value = 0.0;
            //btnDeleteTask.IsEnabled = true;
            panelListTasks.Visibility = Visibility.Visible;
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_taskToDelete = listBoxTasks.SelectedItem as TaskView;
        }
    }
}
