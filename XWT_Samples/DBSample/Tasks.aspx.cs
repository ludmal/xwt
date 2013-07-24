using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using XWT.Web;
using XWT.Data;

public partial class DBSample_Tasks : ViewPage<TaskLogic, List<Task>> {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            List<Task> model = Logic.GetAll();
            //var m = from mm in model
            //        where mm.Id > 20
            //        select mm;

            Model = model;
        }
    }

    protected void Button1_Click(object sender, EventArgs e) {
        try {
            //Customer c = new Customer();
            //c.CustomerName = "Sunil";
            //c.CustomerTel = "223399";
            //Logic.Update(c);
           
            //this.GridView1.DataSource = Logic.GetAll();
            //this.GridView1.DataBind();

            Task task = new Task();
            task.Name = "ce task";
            task.Desc = "This my desc";

            Logic.Create(task);

            Task t = new Task();
            t.Id = 8;
            Logic.Delete(t);

            Query q = new Query("SELECT * FROM TASKS");
            Filter f = new Filter();
            f.Field = "TASK_NAME";
            f.Condition = "LIKE";
            f.Value = "First task";
            f.Active = true;

            q.FilterCollection.Add(f);
            q.SortOrder = "TASK_NAME asc";

            List<Task> tasks = Logic.Execute(q);
            Task tt = Logic.Get(5);
            //tasks.Add(tt);

            this.GridView1.DataSource = tasks;
            this.GridView1.DataBind();
            this.XWTMessageControl1.SetMsg("You have created!");

        } catch (Exception ex) {
            this.XWTMessageControl1.SetMsg(ex.Message);
        }
        
    }
}
