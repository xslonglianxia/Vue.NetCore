# 02. 后端架构 (vol.api / EFCore 版)

> 解决方案入口：`vol.api/VOL.sln`
> 目标框架：**net8.0**
> ORM：**EFCore 8 + Dapper 2.1**

## 2.1 工程清单与依赖

```
vol.api
├── VOL.Builder      ── 代码生成器后台（Utility/ProjectPath.cs 等）
├── VOL.Core         ── 框架核心（基类、过滤器、工具、扩展、Quartz、WorkFlow…）
├── VOL.Entity       ── 实体类与领域模型（DomainModels、AttributeManager、BaseEntity）
├── VOL.Sys          ── 系统模块（用户、角色、菜单、部门、字典、工作流、表单设计）
├── VOL.MES          ── 业务模块（演示用 MES，可整库移除）
└── VOL.WebApi       ── ASP.NET Core 启动项目（Program.cs / Startup.cs）
```

`VOL.WebApi.csproj` 引用：

```xml
<ProjectReference Include="..\VOL.Builder\VOL.Builder.csproj" />
<ProjectReference Include="..\VOL.Core\VOL.Core.csproj" />
<ProjectReference Include="..\VOL.Entity\VOL.Entity.csproj" />
<ProjectReference Include="..\VOL.MES\VOL.MES.csproj" />
<ProjectReference Include="..\VOL.Sys\VOL.Sys.csproj" />
```

`VOL.Core.csproj` 关键 NuGet：

| 包 | 版本 | 用途 |
|---|---|---|
| Microsoft.EntityFrameworkCore.Relational | 8.0.6 | EFCore 基础 |
| Microsoft.EntityFrameworkCore.SqlServer | 8.0.0 | SQL Server 提供程序 |
| Pomelo.EntityFrameworkCore.MySql | 8.0.0 | MySQL 提供程序 |
| Npgsql.EntityFrameworkCore.PostgreSQL | 8.0.0 | PG 提供程序 |
| Oracle.EntityFrameworkCore | 8.21.121 | Oracle 提供程序 |
| DM.Microsoft.EntityFrameworkCore | 8.0.0.28188 | 达梦提供程序 |
| Dapper | 2.1.35 | 复杂 SQL |
| CSRedisCore | 3.8.803 | Redis 客户端 |
| Quartz | 3.4.0 | 调度 |
| Autofac / Autofac.Extensions.DependencyInjection | 8.0.0 | DI 容器 |
| System.IdentityModel.Tokens.Jwt | 6.35.0 | JWT 签发/校验 |
| Yitter.IdGenerator | 1.0.14 | 雪花ID |
| Arric.Crypto.SM | 1.1.2 | 国密 SM2/3/4 |
| EPPlus.Core | 1.5.4 | Excel 导入导出 |
| Microsoft.AspNetCore.Mvc.NewtonsoftJson | 3.1.0 | JSON 序列化 |

## 2.2 VOL.Core 目录详解

```
VOL.Core/
├── BaseInterface/                  # IServices 顶层接口
├── BaseProvider/                   # ⭐ 框架核心基类
│   ├── ServiceBase.cs              # 业务服务基类（增删改查/分页/汇总/审批）
│   ├── RepositoryBase.cs           # 仓储基类（DbContext 注入 + Dapper 双轨）
│   ├── ApplicationServiceBase.cs   # 业务扩展回调（AddOnExecuting、SummaryExpress…）
│   ├── ApplicationServiceBase*.cs  # 拆分扩展：增删改查/查询/上传/工作流/多表
│   ├── IRepository.cs / IService.cs
│   └── IRepositoryDbContext.cs
│
├── Configuration/                  # 强类型配置 AppSetting、GmCryptoOptions
├── Const/                          # 枚举常量（DBType、Secret、SqlDbTypeName…）
├── DBManager/                      # 多库适配：DBServerProvider、DbName、连接特性
├── Dapper/                         # Dapper 封装 + 各数据库 GuidTypeHandler
├── EFDbContext/                    # BaseDbContext / VOLContext / EFLoggerProvider
├── Enums/                          # ApiStatutsCode、ResponseType、LoggerType…
├── Extensions/                     # 300+ 扩展方法（缓存/Lambda/请求/对象/字符串…）
├── Filters/                        # ApiAuthorizeFilter、ActionPermission、ApiTask…
├── Infrastructure/                 # 字典、字典处理
├── KafkaManager/                   # Kafka 生产消费封装
├── Middleware/                     # 异常/请求日志中间件
├── ModelBinder/                    # 自定义模型绑定器
├── ObjectActionValidator/          # 校验容器 + 空校验器（关闭 MVC 默认校验）
├── Quartz/                         # 调度封装：HttpResultfulJob、IOCJobFactory
├── Services/                       # Logger、ActionExecutingLogger
├── Tenancy/                        # 多租户
├── UserManager/                    # 当前用户/角色/部门/字段权限上下文
├── Utilities/                      # JwtHelper、IdWorker、MailHelper、EPPlus、FileHelper…
└── WorkFlow/                       # 审批流：WorkFlowContainer、WorkFlowManager…
```

### 2.2.1 核心抽象关系

```
┌────────────────────────────────┐
│  ApplicationServiceBase<T,R>   │  ← 业务扩展点（回调、汇总、原生SQL）
└──────────────┬─────────────────┘
               │ 继承
┌──────────────▼─────────────────┐
│  ServiceBase<T,R>              │  ← 标准 CRUD、分页、详情、上传、审批
└──────────────┬─────────────────┘
               │ 实现 IService<T>
┌──────────────▼─────────────────┐
│  IRMES_Bom_MainService …       │  ← 业务模块自定义接口
│  (由代码生成器生成)            │
└──────────────┬─────────────────┘
               │ 实现
┌──────────────▼─────────────────┐
│  MES_Bom_MainService :         │
│   ServiceBase<MES_Bom_Main,    │
│   IMES_Bom_MainRepository>     │  ← 业务实现
└────────────────────────────────┘

仓储侧（同样的层级）：

RepositoryBase<T> ─┬─ IRepository<T>
                   └─ 注入 BaseDbContext（VOLContext） + ISqlDapper
MES_Bom_MainRepository : RepositoryBase<MES_Bom_Main>, IMES_Bom_MainRepository
```

### 2.2.2 关键类速览

| 类 | 作用 |
|---|---|
| `ServiceBase<TEntity, TRepository>` | 业务基类，分页、汇总、详情、增删改、上传、审批全在此 |
| `RepositoryBase<TEntity>` | 仓储基类，注入 `BaseDbContext` + `ISqlDapper`（Dapper 双轨） |
| `ApplicationServiceBase` | 暴露 30+ 业务回调（`AddOnExecuting` / `DelOnExecuting` / `SummaryExpress` / `GetPageDataOnExecuted` / `QueryRelativeExpression` / `OrderByExpression` 等） |
| `BaseDbContext` / `VOLContext` | 继承 EFCore DbContext，按 `DBType` 切换连接工厂 |
| `DBServerProvider` | 多库适配中枢：根据 `appsettings.json#Connection.DBType` 返回对应的 ISqlDapper |
| `SqlDapper` | Dapper 封装，处理 Guid/字符拼接/参数化等 |
| `AppSetting` | 强类型读取 `appsettings.json` |
| `WorkFlowContainer` | 工作流注册器（链式 API）：`Instance.Use<T>("业务名").Run()` |
| `ApiAuthorizeFilter` | 授权过滤器：JWT 校验、字段权限、菜单权限 |
| `ActionExecuteFilter` | 通用拦截器：操作日志、审计、异常包装 |
| `UserContext` | 当前用户上下文（线程级，依赖 `HttpContext`） |
| `TableColumnContext` | 字段权限：当前用户对当前表的可见列 |
| `JwtHelper` | 生成/解析 JWT |
| `IdWorker` | 雪花 ID 生成器 |
| `ExceptionHandlerMiddleWare` | 统一异常处理中间件 |
| `HttpRequestMiddleware` | 请求日志、IP/UA 解析 |
| `QuartzNETExtension` | `app.UseQuartz(env)` 启用调度 |
| `IOCJobFactory` | 把 Quartz Job 实例交由 Autofac 管理 |
| `HttpResultfulJob` | 通过 HTTP 调用业务接口的 Job 类型 |
| `ActionLog` / `Logger` | 操作日志与日志门面 |
| `KafkaHelper` | Kafka 生产/消费封装 |

## 2.3 VOL.Entity 目录

```
VOL.Entity/
├── AttributeManager/
│   ├── DBType.cs                   # 枚举：数据库类型
│   ├── EntityAttribute.cs          # EntityAttribute / TableAttribute 等
│   └── PermissionTableAttribute.cs # 权限表特性
├── BaseCore/
│   └── MappingManager.cs           # 实体与表映射
├── SystemModels/
│   ├── BaseEntity.cs               # 实体基类（空类，约定所有实体继承）
│   └── Sys_MenuRole.cs
├── IBaseInterface.cs
└── VOL.Entity.csproj
```

> **约定**：所有数据库实体必须继承 `BaseEntity`（位于 `VOL.Entity/SystemModels/BaseEntity.cs`，当前为空类，仅作为约定标记）。`DomainModels` 下的实体在 `VOL.Core`/`VOL.Sys`/`VOL.MES` 中按业务模块划分。

## 2.4 VOL.Sys 系统模块

```
VOL.Sys/
├── IRepositories/
│   ├── Quartz/    ── ISys_QuartzLogRepository、ISys_QuartzOptionsRepository
│   ├── System/    ── 用户/角色/菜单/部门/日志/字典 仓储接口
│   ├── flow/      ── 工作流：Sys_WorkFlow、Sys_WorkFlowStep、Sys_WorkFlowTable* 接口
│   └── form/      ── 表单设计：FormCollectionObject、FormDesignOptions 接口
│
├── Repositories/   ── 以上接口的 EFCore 实现
│
├── IServices/      ── 业务服务接口（System/form）
│
└── Services/       ── 业务服务实现
    ├── Quartz/
    ├── System/    ── Sys_User/Sys_Role/Sys_Menu/Sys_Department/Sys_Dictionary/Sys_Log
    ├── flow/      ── 工作流 Service
    └── form/      ── 表单 Service
```

### 2.4.1 系统表约定

`Sys_` 前缀的系统表是**框架内置**的，菜单、角色、权限、字典、调度、日志都依赖它。**禁止删除或重命名前缀**。

| 表 | 作用 |
|---|---|
| `Sys_User` | 用户表（含密码加密、字段：CreateID/Creator/CreateDate/ModifyID/Modifier/ModifyDate） |
| `Sys_Role` | 角色表 |
| `Sys_Menu` | 菜单/权限/按钮树 |
| `Sys_MenuRole` | 角色-菜单关联 |
| `Sys_Department` | 部门 |
| `Sys_Dictionary` / `Sys_DictionaryList` | 通用字典 |
| `Sys_Log` | 操作日志 |
| `Sys_QuartzOptions` / `Sys_QuartzLog` | 定时任务 |
| `Sys_WorkFlow` / `Sys_WorkFlowStep` | 工作流模板 |
| `Sys_WorkFlowTable` / `Sys_WorkFlowTableStep` / `Sys_WorkFlowTableAuditLog` | 工作流实例与审计 |
| `Form_CollectionObject` / `Form_DesignOptions` | 表单设计持久化 |

## 2.5 VOL.MES 业务模块

```
VOL.MES/
├── IRepositories/mes/    ── 35+ 仓储接口
│   ├── IMES_Bom_MainRepository.cs
│   ├── IMES_ProductionOrderRepository.cs
│   └── …
├── IServices/mes/        ── 对应 Service 接口
├── Repositories/mes/     ── EFCore 仓储实现
└── Services/mes/         ── 业务实现
```

**完整实体清单（35 个）**：

| 业务域 | 表 |
|---|---|
| 基础数据 | `MES_Customer`, `MES_Supplier`, `MES_Material`, `MES_MaterialCatalog`, `MES_Packaging`, `MES_WarehouseManagement`, `MES_LocationManagement` |
| 主数据 | `MES_Bom_Main`, `MES_Bom_Detail`, `MES_Process`, `MES_ProcessRoute`, `MES_ProcessReport` |
| 生产 | `MES_ProductionOrder`, `MES_ProductionPlanDetail`, `MES_ProductionPlanChangeRecord`, `MES_ProductionReporting`, `MES_ProductionReportingDetail`, `MES_ProductionLine`, `MES_ProductionLineDevice`, `MES_SchedulingPlan` |
| 质量 | `MES_QualityInspectionPlan`, `MES_QualityInspectionPlanDetail`, `MES_QualityInspectionRecord`, `MES_DefectiveProductRecord` |
| 设备 | `MES_EquipmentManagement`, `MES_EquipmentMaintenance`, `MES_EquipmentFaultRecord`, `MES_EquipmentRepair` |
| 库存 | `MES_InventoryManagement`, `MES_ProductInbound`, `MES_ProductOutbound` |
| 测试 | `TestService` |

## 2.6 VOL.WebApi 启动项目

```
VOL.WebApi/
├── Controllers/
│   ├── ApiHomeController.cs                  # 默认重定向到 /swagger
│   └── ObjectActionValidatorExampleController.cs
├── Properties/launchSettings.json
├── wwwroot/                                  # 静态资源
├── Upload/                                   # 上传目录（运行时创建）
├── Program.cs                                # ⭐ 启动入口
├── Startup.cs                                # 流程注册（演示用生产报工）
├── appsettings.json                          # 全部配置
├── appsettings.Development.json
├── Dockerfile                                # 镜像构建
├── builder_run.bat / dev_run.bat / dev_run2.bat / tmp.bat
└── dev_run启动异常说明.txt
```

### 2.6.1 Program.cs 关键流程

```csharp
// 1. 模块注册（VOL.Core 提供的扩展）
builder.Services.AddModule(builder.Configuration);

// 2. MVC + Newtonsoft + Dapper Guid
builder.Services.AddControllers()
    .AddNewtonsoftJson(op => { /* 驼峰、日期格式、Long 转换 */ });
DapperParseGuidTypeHandler.InitParseGuid();

// 3. JWT 鉴权
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { /* ValidIssuer / Audience / Key */ });

// 4. 跨域 (默认放行所有 Origin)
builder.Services.AddCors(...);

// 5. Swagger
builder.Services.AddSwaggerGen(c => { /* JWT Bearer 授权按钮 */ });

// 6. SignalR / HttpClient / MemoryCache / Redis / Quartz JobFactory
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<RedisCacheService>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<Quartz.Spi.IJobFactory, IOCJobFactory>();

// 7. 自定义模型校验（关闭 MVC 默认 400）
builder.Services.AddSingleton<IObjectModelValidator>(new NullObjectModelValidator());

// 8. 启动端口 9991
builder.WebHost.UseUrls("http://*:9991");

// 9. 业务 Startup
var startup = new Startup(builder.Configuration);

// 10. 中间件顺序
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStaticHttpContext();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHub<HomePageMessageHub>("/message");
app.Run();
```

### 2.6.2 Startup.cs（业务流程注册）

```csharp
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        // 把"生产报工"注册为可走工作流审批的实体
        WorkFlowContainer.Instance
           .Use<MES_ProductionReporting>(
             "生产报工",
                filterFields: x => new { x.ReportingNumber, x.AcceptedQuantity, x.RejectedQuantity, x.Total, x.ReportedBy, x.ReportingTime },
                formFields:    x => new { x.ReportedBy, x.ReportingNumber, x.ReportingTime, x.AcceptedQuantity, x.RejectedQuantity, x.Total }
            )
           .Run();
    }
}
```

### 2.6.3 appsettings.json 关键配置

```jsonc
{
  "Connection": {
    "DBType": "MsSql",                  // MySql/MsSql/PgSql/Oracle/DM
    "DbConnectionString": "...",
    "RedisConnectionString": "127.0.0.1,Password=123456,SyncTimeout=15000",
    "UseRedis": "false",                // false=MemoryCache
    "UseSignalR": "true"
  },
  "Secret": {
    "JWT":      "AA3627441FFA4B5DB4E64A29B53CE525",
    "Audience": "vol.core",
    "Issuer":   "vol.core.owner",
    "User":     "C5ABA9E202D94C43A3CA66002BF77FAF",
    "DB":       "3F8B7B38AD3D484A89ACA513CBD79F36",
    "Redis":    "E6D90DDBC70C4F4EA3C312B6FCB473C8"
  },
  "CorsUrls": "http://127.0.0.1:9990,http://localhost:9990,http://www.volcore.xyz",
  "ExpMinutes": "120",
  "CreateMember":  { "UserIdField":"CreateID", "UserNameField":"Creator", "DateField":"CreateDate" },
  "ModifyMember":  { "UserIdField":"ModifyID", "UserNameField":"Modifier","DateField":"ModifyDate" },
  "GlobalFilter":  { "Enable":"false", "Actions":[ "Update","Del","Add","SavePermission","Import","Upload","Audit","ModifyPwd" ] },
  "GmCrypto": { "SM2":{...}, "SM3":{"Enabled":true}, "SM4":{...} },
  "QuartzAccessKey": "65EC9387355E4717899C552963CE59FF",
  "EnableSnowFlakeID": true,
  "SnowFlakeOptions": { "BaseTime":"2023-01-01 00:00:00.000", "WorkerId":1, "WorkerIdBitLength":6, "SeqBitLength":6, "MinSeqNumber":5, "TopOverCostCount":2000 }
}
```

## 2.7 VOL.Builder 代码生成器

`VOL.Builder` 提供 **在线代码生成** 的后端能力（生成实体/服务/Controller/Sql 脚本等）。前端入口在 `vol.web/src/views/builder/coder.vue`。

关键文件：
- `VOL.Builder/Utility/ProjectPath.cs` — 解析目标项目路径
- `VOL.Builder/Class1.cs` — 占位
- `VOL.Builder.csproj` — 类库项目

> 代码生成器内部会读取数据库表结构、字段类型、注释等，套用模板生成与表名相关的 Service/Repository/Controller/Vue 页面。生成的代码风格统一、可在框架基础上二次扩展。

## 2.8 自定义业务模块的标准姿势

新增一个业务模块 `VOL.Order`：

1. 新建类库 `VOL.Order`，引用 `VOL.Core` + `VOL.Entity`。
2. 定义实体（继承 `BaseEntity`），放 `OrderEntity.cs`。
3. 定义仓储接口与实现：`IOrderRepository` : `IRepository<OrderEntity>`，`OrderRepository` : `RepositoryBase<OrderEntity>, IOrderRepository`。
4. 定义服务接口与实现：`IOrderService` : `IService<OrderEntity>`，`OrderService` : `ServiceBase<OrderEntity, IOrderRepository>, IOrderService`。
5. 业务扩展：在构造函数中通过 `base(repository)` 接收仓储；通过 `AddOnExecuting`、`SummaryExpress` 等回调实现自定义逻辑。
6. `VOL.WebApi.csproj` 中加入 `ProjectReference`。
7. `Program.cs` / `Startup.cs` 无需改动（DI 自动扫描）。
8. 在数据库建表 → 通过代码生成器生成 Vue 页面。

## 2.9 EFCore 与 Dapper 双轨

`RepositoryBase` 中同时持有 `BaseDbContext` 与 `ISqlDapper`：

- **EFCore**：用于实体变更跟踪、`Add`/`Update`/`Remove`、事务 `DbContextBeginTransaction`。
- **Dapper**：用于复杂 SQL、多表关联、批量写入、DBA 友好。

`DBServerProvider.GetSqlDapper<TEntity>()` 会根据 `Connection.DBType` 返回不同方言的 `SqlDapper`，并通过 `DapperParseGuidTypeHandler*` 处理不同数据库的 Guid 差异。

## 2.10 常用运行命令

```bash
# 本地开发
cd vol.api
dotnet run --project VOL.WebApi            # 默认监听 http://*:9991

# Docker 构建
docker build -t volapi:1.0 -f VOL.WebApi/Dockerfile .
docker run -d --name volapi --network=host volapi:1.0
```

> 详细的本地开发、调试与生产部署步骤见 [08-运行与部署指南](./08-运行与部署指南.md)。
