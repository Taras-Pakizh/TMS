﻿#pragma checksum "..\..\..\Views_PM\AddProjectView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98ED165450F934086ED00AFED11FE87AC9FFBE9B"
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
    /// AddProjectView
    /// </summary>
    public partial class AddProjectView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAbbreviation;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.UpDown upDownProject;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpickFrom;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpickTo;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProject;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelAddTask;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTask;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.UpDown upDown_task;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddTask;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelListTasks;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views_PM\AddProjectView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listBoxTasks;
        
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
            System.Uri resourceLocater = new System.Uri("/TMS.Client;component/views_pm/addprojectview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views_PM\AddProjectView.xaml"
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
            this.txtProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtAbbreviation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.upDownProject = ((Syncfusion.Windows.Shared.UpDown)(target));
            return;
            case 5:
            this.dtpickFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.dtpickTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btnAddProject = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Views_PM\AddProjectView.xaml"
            this.btnAddProject.Click += new System.Windows.RoutedEventHandler(this.BtnAddProject_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Views_PM\AddProjectView.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.BtnClear_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.panelAddTask = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.txtTask = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.upDown_task = ((Syncfusion.Windows.Shared.UpDown)(target));
            return;
            case 12:
            this.btnAddTask = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Views_PM\AddProjectView.xaml"
            this.btnAddTask.Click += new System.Windows.RoutedEventHandler(this.BtnAddTask_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.panelListTasks = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.listBoxTasks = ((System.Windows.Controls.ListView)(target));
            
            #line 68 "..\..\..\Views_PM\AddProjectView.xaml"
            this.listBoxTasks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxTasks_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

