﻿#pragma checksum "..\..\..\Views_PM\ProjectsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FF7023258DF0BDB0E9273310AAD525F59F5DFD9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Syncfusion;
using Syncfusion.Windows;
using Syncfusion.Windows.Collections;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Controls.VirtualTreeView;
using Syncfusion.Windows.Data;
using Syncfusion.Windows.Diagnostics;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Styles;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TMS.Client.Project_Manager.Views;


namespace TMS.Client.Project_Manager.Views {
    
    
    /// <summary>
    /// ProjectsView
    /// </summary>
    public partial class ProjectsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDateFrom;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpickFrom;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelDateFrom;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDateTo;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpickTo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelDateTo;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApply;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProjects;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuReports;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTasks;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuApprove;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuDecline;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuReportDetails;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupDetails;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtProjectName;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtEngineer;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtEffort;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtStatus;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtStart;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtEnd;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApprove;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDecline;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClosePopup;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel filterPanel;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkWithRep;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton chkOpen;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton chkAproved;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton chkDecline;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelAddTask;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTask;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.UpDown upDown_task;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\Views_PM\ProjectsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddTask;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TMS.Client;component/views_pm/projectsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views_PM\ProjectsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblDateFrom = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.dtpickFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.cancelDateFrom = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Views_PM\ProjectsView.xaml"
            this.cancelDateFrom.Click += new System.Windows.RoutedEventHandler(this.CancelDateFrom_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblDateTo = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.dtpickTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.cancelDateTo = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Views_PM\ProjectsView.xaml"
            this.cancelDateTo.Click += new System.Windows.RoutedEventHandler(this.CancelDateTo_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnApply = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnApply.Click += new System.Windows.RoutedEventHandler(this.BtnApply_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dgProjects = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.menuReports = ((System.Windows.Controls.MenuItem)(target));
            
            #line 83 "..\..\..\Views_PM\ProjectsView.xaml"
            this.menuReports.Click += new System.Windows.RoutedEventHandler(this.MenuTasks_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.dgTasks = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 18:
            this.menuApprove = ((System.Windows.Controls.MenuItem)(target));
            
            #line 121 "..\..\..\Views_PM\ProjectsView.xaml"
            this.menuApprove.Click += new System.Windows.RoutedEventHandler(this.MenuApprove_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.menuDecline = ((System.Windows.Controls.MenuItem)(target));
            
            #line 122 "..\..\..\Views_PM\ProjectsView.xaml"
            this.menuDecline.Click += new System.Windows.RoutedEventHandler(this.MenuDecline_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.menuReportDetails = ((System.Windows.Controls.MenuItem)(target));
            
            #line 123 "..\..\..\Views_PM\ProjectsView.xaml"
            this.menuReportDetails.Click += new System.Windows.RoutedEventHandler(this.MenuReportDetails_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.popupDetails = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 22:
            this.txtProjectName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 23:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 24:
            this.txtEngineer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 25:
            this.txtEffort = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 26:
            this.txtStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 27:
            this.txtStart = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 28:
            this.txtEnd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 29:
            this.btnApprove = ((System.Windows.Controls.Button)(target));
            
            #line 170 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnApprove.Click += new System.Windows.RoutedEventHandler(this.MenuApprove_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            this.btnDecline = ((System.Windows.Controls.Button)(target));
            
            #line 171 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnDecline.Click += new System.Windows.RoutedEventHandler(this.MenuDecline_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            this.btnClosePopup = ((System.Windows.Controls.Button)(target));
            
            #line 172 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnClosePopup.Click += new System.Windows.RoutedEventHandler(this.BtnClosePopup_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            this.filterPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 33:
            this.chkWithRep = ((System.Windows.Controls.CheckBox)(target));
            
            #line 180 "..\..\..\Views_PM\ProjectsView.xaml"
            this.chkWithRep.Checked += new System.Windows.RoutedEventHandler(this.ChkWithRep_Checked);
            
            #line default
            #line hidden
            
            #line 180 "..\..\..\Views_PM\ProjectsView.xaml"
            this.chkWithRep.Unchecked += new System.Windows.RoutedEventHandler(this.ChkWithRep_Unchecked);
            
            #line default
            #line hidden
            return;
            case 34:
            this.chkOpen = ((System.Windows.Controls.RadioButton)(target));
            
            #line 182 "..\..\..\Views_PM\ProjectsView.xaml"
            this.chkOpen.Checked += new System.Windows.RoutedEventHandler(this.ChkOpen_Checked);
            
            #line default
            #line hidden
            return;
            case 35:
            this.chkAproved = ((System.Windows.Controls.RadioButton)(target));
            
            #line 183 "..\..\..\Views_PM\ProjectsView.xaml"
            this.chkAproved.Checked += new System.Windows.RoutedEventHandler(this.ChkAproved_Checked);
            
            #line default
            #line hidden
            return;
            case 36:
            this.chkDecline = ((System.Windows.Controls.RadioButton)(target));
            
            #line 184 "..\..\..\Views_PM\ProjectsView.xaml"
            this.chkDecline.Checked += new System.Windows.RoutedEventHandler(this.ChkDecline_Checked);
            
            #line default
            #line hidden
            return;
            case 37:
            this.panelAddTask = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 38:
            this.txtTask = ((System.Windows.Controls.TextBox)(target));
            return;
            case 39:
            this.upDown_task = ((Syncfusion.Windows.Shared.UpDown)(target));
            return;
            case 40:
            this.btnAddTask = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\..\Views_PM\ProjectsView.xaml"
            this.btnAddTask.Click += new System.Windows.RoutedEventHandler(this.BtnAddTask_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 12:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 55 "..\..\..\Views_PM\ProjectsView.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ToTasks_DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 13:
            
            #line 74 "..\..\..\Views_PM\ProjectsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDeleteProj_Click);
            
            #line default
            #line hidden
            break;
            case 16:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 93 "..\..\..\Views_PM\ProjectsView.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ReportDetails_doubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 17:
            
            #line 112 "..\..\..\Views_PM\ProjectsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDeleteTask_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
