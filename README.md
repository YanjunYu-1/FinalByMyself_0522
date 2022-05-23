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
.AddRoles<IdentityRole>()
```

（2）Model=>建立AppUser并继承IdentityUser
```java
public class AppUser: IdentityUser
```

（3）Data=>ApplicationDbContext
```java
ApplicationDbContext : IdentityDbContext<AppUser>
```

(4)在program中添加
```java
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

(5)View=>Shared=>_LoginPartial=>Program
```java
@inject SignInManager<AppUser> SignInManager
@inject UserManager<AppUser> UserManager
```

10.特别注意：设置ApplicationDbContext，将数据与数据库连接