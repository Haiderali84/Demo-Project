using Dapper;
using DemoProject.DataAccess;
using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.BusinessLogics
{
    public class ActivityProcessor
    {
        public static List<Activity> GetActivities()
        {
            return SqlDataAccess.LoadDataList<Activity>($"select activity.* , priority.Priority as Priority  from activity as activity inner join dbo.ActivityPriority as priority on Activity.priorityid = priority.Priorityid ;", new DynamicParameters());
        }
        public static Activity GetSpecificActivity(int id)
        {
            return SqlDataAccess.GetDataModel<Activity>($"select activity.* , priority.Priority as Priority  from activity as activity inner join dbo.ActivityPriority as priority on Activity.priorityid = priority.Priorityid where activity.Priorityid = {id};;", new DynamicParameters());
        }
        public static int InsertActivity(Activity activity)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@ActivityId", activity.ActivityId);
            dbarg.Add("@ActivityDescription", activity.ActivityDescription);
            dbarg.Add("@ActivityTime", activity.ActivityTime);
            dbarg.Add("@PriorityId", activity.PriorityId);
            string query = $@"Insert into Activity (ActivityDescription, ActivityTime, PriorityId) VALUES (@ActivityDescription, @ActivityTime, @PriorityId)";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
        public static int UpdateActivity(Activity activity)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@ActivityId", activity.ActivityId);
            dbarg.Add("@ActivityDescription", activity.ActivityDescription);
            dbarg.Add("@ActivityTime", activity.ActivityTime);
            dbarg.Add("@PriorityId", activity.PriorityId);
            string query = $@"Update Activity set ActivityDescription =@ActivityDescription , ActivityTime=@ActivityTime, PriorityId=@PriorityId where PriorityId = @PriorityId";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
            public static int DeleteActivity(int id)
        {
            return SqlDataAccess.insertDataDapper($"Delete from activity where ActivityId = {id}", new DynamicParameters());
        }
    }
}
