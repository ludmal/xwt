using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XWT.Data ;
using XWT;

/// <summary>
/// Summary description for Task
/// </summary>
public class Task {
    public Task() {
        //
        // TODO: Add constructor logic here
        //
    }
    [Persistent("TASK_ID", true, true)]
    public int Id { get; set; }
    [Persistent("TASK_NAME")]
    public string Name { get; set; }
    [Persistent("TASK_DESC")]
    public string Desc { get; set; }
}

public class TaskData : DataModelBase {
    public TaskData() {
        TableInfo = new TableInfo() {
            TableName = "TASKS",
            UniqueField = "TASK_ID"
        };
    }
}

public class TaskLogic : LogicBase<TaskData, Task> { 
    
}

public class Customer {
    [Persistent("CUST_NAME")]
    public string CustomerName { get; set; }
    [Persistent("CUST_TEL")]
    public string CustomerTel { get; set; }
}

public class CustomerData : DataModelBase {
    public CustomerData() {
        TableInfo = new TableInfo() {
            TableName = "CUSTOMERS",
            UniqueField = "CUST_NAME"
        };
    }
}

public class CustomerLogic: LogicBase<CustomerData, Customer> {
    public void DoSomeOtherStuff() { 
        
    }
}


