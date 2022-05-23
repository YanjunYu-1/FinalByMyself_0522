一、建所有ClassName

二、完善class内容

1.创建新的分支-Bob

2.完成Ticket：两个类之间有两个关系需要加两个"?"。如果中间有eunm（枚举，可参考里面的内容

3.完成TicketAttachment

4.完成TicketComment

5.完成TicketHistory

6.完成TicketNotification

7.完成Project

8.完成ProjectUser

9.完成AppUser：此处用到InverseProperty，因为两个class中有两个以上的关系（当两个实体之间不止一种关系的时候，可以使用InverseProperty特性，）https://www.cnblogs.com/caofangsheng/p/10677235.html

（1）在program中添加
```java
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

（2）Model=>建立AppUser并继承IdentityUser
```java
public class AppUser: IdentityUser
```

（3）Data=>ApplicationDbContext.特别注意：设置ApplicationDbContext，将数据与数据库连接
```java
ApplicationDbContext : IdentityDbContext<AppUser>

public DbSet<AppUser> AppUser { get; set; }
public DbSet<Project> Project { get; set; }
public DbSet<ProjectUser> ProjectUser { get; set; }
public DbSet<Ticket> Ticket { get; set; }
public DbSet<TicketAttachment> TicketAttachment { get; set; }
public DbSet<TicketComment> TicketComment { get; set; }
public DbSet<TicketHistory> TicketHistory { get; set; }
public DbSet<TicketNotification> TicketNotification { get; set; }
```

(4)View=>Shared=>_LoginPartial=>Program
```java
@inject SignInManager<AppUser> SignInManager
@inject UserManager<AppUser> UserManager
```
10.（1）在appsettings中修改连接服务器的数据 

（2）添加依赖项

```java
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

（3）迁移，导入数据

```java
Add-Migration Initial
Update-Database
```
三、完善SeedData

(1)建立SeedData，并放入所需数据

（2）在program中添加
```java
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}
```

（3）再次在程序包管理控制器中上传命令

```java
Add-Migration AddCourseDbSet //单独更改Course的迁移
Update-Database//更新数据库
```

（4）启动后，SQL中应该就有数据

四、建立DAL（Data Access Layer）数据访问层

（1）建立IDAL（注意：此处是interface接口不是class类），里面包含所有用到的“泛型”

（2）所有class中都要调取ApplicationDbContext中的Context，并被class使用

（3）对于单独类型，使用first查找对应Id等数据

（4）class_RoleDAL不同于其他class，继承的是IdentityRole。在SQL中是Roles

（5）Project Get方法不同于其他的，使用了include，不明白原因

五、建立BLL

（1）BLL中的不同之处：因为有时AppUserDAL中包含IDAL中没有的方法
```java
IDAL<AppUser> repo;//只能读取IDAL中有的方法
public AppUserDAL AppUserDAL;//可以读取APPUserDAL中的方法
```

（2）RoleBLL中DAL层，genericity泛型T指的是IdentityRole

六、建立Controller

1、HomeController：修改数据连接的入口，不是从ApplicationDbContext进入，而是从BLL（new DAL）进入

（1）Index中需要传递数据
```java
public IActionResult Index()
{
    return View(projectBLL.GetAll());
}
//数据传入到Index的Model
```