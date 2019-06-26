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

        private static Dictionary<Type, IEnumerable<IViewBase>> _context { get; set; } 
            = new Dictionary<Type, IEnumerable<IViewBase>>();

        public static void SetContext(params IEnumerable<IViewBase>[] views)
        {
            foreach(var list in views)
            {
                var type = list.FirstOrDefault().GetType();
                if (_context.Keys.Contains(type))
                {
                    _context[type] = (IEnumerable<IViewBase>) list;
                }
                else
                {
                    _context.Add(type, (IEnumerable<IViewBase>)list);
                }
            }
        }

        private static IEnumerable<T> Set<T>() where T : IViewBase
        {
            return (IEnumerable<T>) _context[typeof(T)];
        }

        private static int _words = 5;

        public static void Initialize()
        {
            if (isInitialize)
                return;

            Mapper.Initialize(ctg =>
            {
                ctg.CreateMap<TaskView, ViewTask>()
                    .ForMember(x => x.projectName,
                        y => y.MapFrom(i => Set<ProjectView>()
                            .Where(w => w.Id == i.projectId)
                                .Single().name))
                    .ForMember(x => x.taskName,
                        y => y.MapFrom((i, h) => {
                            var decs = i.description;
                            if (i.description.Length > 50)
                                decs = i.description.Substring(0, 50);
                            var words = decs.Split(new char[] { ' ' });
                            if(words.Length >= _words)
                            {
                                return string.Join(" ", words.Take(_words)) + "...";
                            }
                            return i.description;
                        }));
                ctg.CreateMap<ViewTask, TaskView>();

                ctg.CreateMap<ProjectView, ViewProject>();
                ctg.CreateMap<ViewProject, ProjectView>();

                ctg.CreateMap<ReportView, ViewReport>()
                    .ForMember(x => x.taskName,
                        y => y.MapFrom((i, h) =>
                        {
                            var desc = Set<TaskView>()
                            .Where(w => w.Id == i.taskId)
                                .Single().description;
                            if (desc.Length > 50)
                                desc = desc.Substring(0, 50);
                            var words = desc.Split(new char[] { ' ' });
                            if (words.Length >= _words)
                            {
                                return string.Join(" ", words.Take(_words)) + "...";
                            }
                            return desc;
                        }));
                ctg.CreateMap<ViewReport, ReportView>();
                ctg.CreateMap<ReportValidationModel, ViewReport>();

                ctg.CreateMap<UserView, ViewUser>()
                    .ForMember(x => x.ReportsCount,
                            y => y.MapFrom(i => Set<ReportView>().Count(c => c.engineerId == i.Id)))
                    .ForMember(x => x.TeamName,
                            y => y.MapFrom(i => Set<TeamView>().Where(w => w.Id == i.team_id).Single().name));
            });

            isInitialize = true;
        }

    }
}
