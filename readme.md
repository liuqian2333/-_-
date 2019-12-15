# 荣阳人事管理系统

# 1选题

因为毕业设计准备做一个管理系统，此次做的是设计的原型,做的是一个基于Windows的WPF应用，前端用xaml写的后端用C#，数据库选的是本机的mysql数据库

# 2工具和环境
+ 工具VS2017， MySqlServer8.0
+ 环境.net4.6.1，window10

# 3实现的模块：
+ 员工档案管理
+ 员工考核奖惩
+ 高级权限获得
+ 员工人事变动（只有在高级权限获得后才能进行人事管理）

# 4系统的需求分析

### 功能性需求：
+ 1 查询某个员工的信息
+ 2 修改某个员工的信息
+ 3 查询某个员工的奖惩状况
+ 4 修改某个员工的奖惩情况
+ 5 新建奖惩情况
+ 6 新员工登记
+ 7 现有的员工离职
+ 8 考勤加班出差管理
+ 9 员工培训
+ 10 需要更高级的权限才能进行员工的入职，离职操作
### 非功能性需求：
+ 1 界面功能清晰
+ 2 安全性 sql 语言使用参数化防止注入攻击
+ 3 运行效率高

# 系统功能模块图

![功能模块图](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/%E7%BB%93%E6%9E%84.png)

# 数据库设计

+ 员工信息表
```sql
Create table staff_data(id char(10), name varchar(20),
sex char(10), hukou varchar(50), zhengzhimianmao varchar(50),
health varchar(50), contrance varchar(50), pay int),
Primary key (id);
```
+ 员工奖惩信息表
```sql
create table staffaward_data(number int, id char(10),
award int, time char(20), reason char(50)), primary key
(number), foreign key (id) references staff_data(id) on
delete cascade

+ 普通管理员表
create table normaluser(id char(10), password char(16))
primary key (id);
```
+ 高级管理员表
```sql
create table hightuser(id chr(10), password char(16))
primary key (id);
```
因为大部分表的搜索是关于主码的如登录账户， 查询修改员工的信息都是用到主码， 对于员工奖惩信息表修改时需要用到主码，而查询某个员工的奖惩信息时需要用到外码 id。
同时 MySql 默认基于主码建立索引的因此综上每个表都设计为主码聚集

# 运行界面
![运行界面](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/1.PNG)

+ 登录
![登录](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/2.PNG)
+ 管理奖惩情况
![管理奖惩](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/4.PNG)
![人事变动](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/5.PNG)


+ 登录成功后可以管理员工的基础信息
![](https://github.com/liuqian2333/rongyang-/blob/master/%E6%88%AA%E5%9B%BE/3.PNG)

# 总结
+ xaml虽然不是新的技术，但是在windows的前端设计还是比较方便的，模块“考勤出差加班管理”和“员工培训”的模块没有实现，暂时空着，另外我认为现阶段的界面制作是比较粗糙的还应改进一下,另外因为数据库是本地的没有搭建云数据库，因此还不能在其他的设备运行
