function Task(Name,Desc,Date,Important){
    this.Name = Name,
    this.Desc = Desc,
    this.Date=Date,
    this.Important = Important
}

var tasks = new Array()

function Add(){
    var name = document.getElementById("task_name").value;
    if(name == ""){
        alert("no");
    }
    var desc = document.getElementById("task_desc").value;
    var date = document.getElementById("task_date").value;
    var imp = document.querySelector('input[name="important"]:checked');
    if(imp){
        imp = "true"
    }
    else{
        imp = "false"
    }
    var task = new Task(name,desc,date,imp);
    tasks.push(task);
    list();
}
function list(){
    document.getElementById("tasks").innerHTML = "";
    for(let i in tasks){
        const para = document.createElement("p");
        var important = "";
        if(tasks[i].Important == "true"){
            important = "important";
        }
        else{
            important = "not important";
        }
        const node = document.createTextNode(tasks[i].Name + "-------" + tasks[i].Desc + "-------" + tasks[i].Date + "-------" + important);
        para.appendChild(node);
        document.getElementById("tasks").appendChild(para);
    }
}


