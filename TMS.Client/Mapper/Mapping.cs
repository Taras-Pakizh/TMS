using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TMS.Client.ViewModels;
using TMS.ViewModels;

namespace TMS.Client
{
    public static class Mapping
    {
        public static bool isInitialize { get; private set; }
        //public static MyContext cx { get { return context; } }

        //private static MyContext context = new MyContext();

        public static void Initialize()
        {
            if (isInitialize)
                return;

            Mapper.Initialize(ctg =>
            {
                ctg.CreateMap<TaskView, ViewTask>();
                ctg.CreateMap<ViewTask, TaskView>();

                ctg.CreateMap<ProjectView, ViewProject>();
                ctg.CreateMap<ViewProject, ProjectView>();

                ctg.CreateMap<ReportView, ViewReport>();
                ctg.CreateMap<ViewReport, ReportView>();
            });

            isInitialize = true;
        }

    }
}
