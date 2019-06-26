using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TMS.Data;
using TMS.ViewModels;

namespace TMS.Server
{
    public static class Mapping
    {
        public static bool isInitialize { get; private set; }
        public static MyContext cx { get { return context; } }

        private static MyContext context = new MyContext();

        public static void Initialize()
        {
            if (isInitialize)
                return;
            Mapper.Initialize(ctg =>
            {
                ctg.CreateMap<Risk, RiskView>()
                    .ForMember(x => x.projectId,
                                y => y.MapFrom(z => z.project.Id));
                ctg.CreateMap<Task, TaskView>()
                    .ForMember(x => x.projectId,
                                y => y.MapFrom(z => z.project.Id));
                ctg.CreateMap<Approve, ApproveView>()
                    .ForMember(x => x.approveAuthorId,
                                y => y.MapFrom(z => z.approveAuthor.Id))
                    .ForMember(x => x.reportId,
                                y => y.MapFrom(z => z.report.Id));
                ctg.CreateMap<Project, ProjectView>()
                    .ForMember(x => x.riskIds,
                                y => y.MapFrom(z => z.risks.Select(l => l.Id)))
                    .ForMember(x => x.taskIds,
                                y => y.MapFrom(z => z.task.Select(l => l.Id)));
                ctg.CreateMap<Report, ReportView>()
                    .ForMember(x => x.approveIds,
                                y => y.MapFrom(z => z.approves.Select(l => l.Id)))
                    .ForMember(x => x.engineerId,
                                y => y.MapFrom(z => z.engineer.Id))
                    .ForMember(x => x.taskId,
                                y => y.MapFrom(z => z.task.Id));
                ctg.CreateMap<Team, TeamView>()
                    .ForMember(x => x.engineerIds,
                                y => y.MapFrom(z => z.engineers.Select(l => l.Id)))
                    .ForMember(x => x.teamleadId,
                                y => y.MapFrom(z => z.teamlead.Id));
                ctg.CreateMap<User, UserView>().ForMember(x => x.team_id,
                                y => y.MapFrom((z, h) => 
                                {
                                    foreach(var team in cx.Teams.ToList())
                                    {
                                        foreach(var user in team.engineers.ToList())
                                        {
                                            if(user.Id == z.Id)
                                            {
                                                return team.Id;
                                            }
                                        }
                                    }
                                    return 0;
                                } ));



                ctg.CreateMap<ReportView, Report>()
                    .ForMember(x => x.engineer,
                                y => y.MapFrom(z => cx.Users.Find(z.engineerId)))
                    .ForMember(x => x.task,
                                y => y.MapFrom(z => cx.Tasks.Find(z.taskId)))
                    .ForMember(x => x.approves,
                                y => y.MapFrom(z => z.approveIds.Select(s => cx.Approves.Find(s))));
                ctg.CreateMap<ApproveView, Approve>()
                    .ForMember(x => x.report,
                                y => y.MapFrom(z => cx.Reports.Find(z.reportId)))
                    .ForMember(x => x.approveAuthor,
                                y => y.MapFrom(z => cx.Users.Find(z.approveAuthorId)));
                ctg.CreateMap<ProjectView, Project>()
                    .ForMember(x => x.risks,
                                y => y.MapFrom(z => z.riskIds.Select(s => cx.Risks.Find(s))))
                    .ForMember(x => x.task,
                                y => y.MapFrom(z => z.taskIds.Select(s => cx.Tasks.Find(s))));
                ctg.CreateMap<RiskView, Risk>()
                    .ForMember(x => x.project,
                                y => y.MapFrom(z => cx.Projects.Find(z.projectId)));
                ctg.CreateMap<TaskView, Task>()
                    .ForMember(x => x.project,
                                y => y.MapFrom(z => cx.Projects.Find(z.projectId)));
                ctg.CreateMap<TeamView, Team>()
                    .ForMember(x => x.teamlead,
                                y => y.MapFrom(z => cx.Users.Find(z.teamleadId)))
                    .ForMember(x => x.engineers,
                                y => y.MapFrom(z => z.engineerIds.Select(s => cx.Users.Find(s))));
                ctg.CreateMap<UserView, User>();
            });
            isInitialize = true;
        }
    }
}