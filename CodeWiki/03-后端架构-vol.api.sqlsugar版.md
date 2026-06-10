# 03. 后端架构 (vol.api.sqlsugar 版)

> 解决方案入口：`vol.api.sqlsugar/VOL.sln`
> 目标框架：**net10.0**
> ORM：**SqlSugarCore 5.1.4.214**

## 3.1 与 EFCore 版的差异速览

| 维度 | vol.api（EFCore） | vol.api.sqlsugar（SqlSugar） |
|------|-------------------|------------------------------|
| 目标框架 | net8.0 | net10.0 |
| ORM | EFCore 8 + Dapper | SqlSugar 5.1 + Dapper（极少使用） |
| `VOL.Entity` | EFCore 实体（无特性） | SqlSugar 实体（`[SugarTable]`、`[SugarColumn]`） |
| `VOL.Core/DbContext` | `BaseDbContext` 继承 `DbContext` | `BaseDbContext` 继承 SqlSugar `ISqlSugarClient` |
| `VOL.Core/DBManager` | `DBServerProvider` | 新增 `DbManger`、`SqlSugarRegister`、`SqlSugarExtension`、`SqlSugarDbType` |
| `VOL.Core/BaseProvider/RepositoryBase` | 通过 `BaseDbContext` 暴露 DbSet | 通过 SqlSugar `ISqlSugarClient` 暴露 `Queryable<T>` |
| 启动注册 | `AddModule` + Dapper 初始化 | `AddModule` + `UseSqlSugar()` 扩展 |
| 启动包 | EF 相关 | SqlSugarCore 5.1 + Confluent.Kafka 1.8.2 |
| Swagger 版本 | 7.0.0 | 10.1.7 |
| EFCore 数据迁移 | 支持 | 移除（SqlSugar 用 `CodeFirst`） |

> **结论**：两套后端是**并行维护**的，业务代码风格几乎一致，可以按团队技术栈任选其一。

## 3.2 工程清单

```
vol.api.sqlsugar
├── VOL.Builder/        ── 代码生成器后台
├── VOL.Core/           ── SqlSugar 适配版框架核心
├── VOL.Entity/         ── 领域实体（SqlSugar 特性）
├── VOL.Sys/            ── 系统模块（SqlSugar 仓储）
├── VOL.MES/            ── 业务模块（占位/简化）
└── VOL.WebApi/         ── 启动项目
```

`VOL.Core.csproj` 关键差异：

```xml
<TargetFramework>net10.0</TargetFramework>
<PackageReference Include="SqlSugarCore" Version="5.1.4.214" />
<PackageReference Include="Confluent.Kafka" Version="1.8.2" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="10.0.0" />
<PackageReference Include="Npgsql" Version="10.0.2" />
<PackageReference Include="System.Linq.Dynamic.Core" Version="1.3.5" />
```

`VOL.Entity.csproj` 关键差异：

```xml
<TargetFramework>net10.0</TargetFramework>
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />  <!-- 仅为兼容 -->
<PackageReference Include="SqlSugarCore" Version="5.1.4.214" />
```

## 3.3 VOL.Core 新增/差异目录

```
VOL.Core/
├── DBManager/
│   ├── DBServerProvider.cs
│   ├── DBConnectionAttribute.cs
│   ├── DbName.cs
│   ├── DbManger.cs            ★ 新增：SqlSugar Client 管理器
│   ├── SqlSugarDbType.cs      ★ 新增：枚举映射
│   ├── SqlSugarExtension.cs   ★ 新增：扩展方法（Queryable / Updateable / Insertable）
│   └── SqlSugarRegister.cs    ★ 新增：DI 注册
│
├── DbContext/                  ★ 新目录，替换原 EFDbContext/
│   ├── BaseDbContext.cs        ★ ISqlSugarClient 包装
│   ├── DbContext.cs            ★ SqlSugar Client 工厂
│   └── VOLContext.cs
│
├── ModelBinder/
│   └── FileModelBinder.cs      ★ 新增：上传模型绑定
│
└── WorkFlow/
    └── WorkFlowQuery.cs        ★ 移除（EFCore 版有）
```

## 3.4 VOL.WebApi/Program.cs 差异

```csharp
// EFCore 版
builder.Services.AddModule(builder.Configuration);
// ...
DapperParseGuidTypeHandler.InitParseGuid();

// SqlSugar 版
builder.Services.AddModule(builder.Configuration);
builder.Services.UseSqlSugar();   // ← 关键差异

builder.Services
    .AddControllers()
    .AddCompatibility()          // ← SqlSugar 版需要
    .AddNewtonsoftJson(op => { ... });
```

Swagger 配置也调整为：

```csharp
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Type = SecuritySchemeType.Http,   // ← 由 ApiKey 改为 Http
    Scheme = "bearer",
    BearerFormat = "JWT"
});
```

> 其余 `JWT` / `CORS` / `SignalR` / `Quartz` 注册流程与 EFCore 版一致。

## 3.5 SqlSugar 实体约定

`VOL.Entity` 内的实体使用 SqlSugar 特性（`[SugarTable]`、`[SugarColumn(IsPrimaryKey=true)]` 等），`MappingManager` 负责实体与表名映射。

> 该目录的代码在 `vol.api.sqlsugar` 中以 `MappingConfiguration/` 形式重新组织，但 `DomainModels/` 命名空间与 EFCore 版兼容。

## 3.6 业务模块

- `VOL.MES` 在该解决方案下被精简（仅有 `.csproj` 占位），实际业务由 `VOL.Core` + `VOL.Sys` 提供。
- `VOL.Sys` 提供与 EFCore 版完全等价的能力（用户/角色/菜单/工作流/表单设计）。

## 3.7 何时选择 SqlSugar 版

| 场景 | 建议 |
|------|------|
| 团队熟悉 SqlSugar | ✅ 推荐 |
| MySQL 性能敏感 / 需要更激进的 SQL 控制 | ✅ 推荐 |
| 需要 `CodeFirst` 模式在线建表 | ✅ 推荐 |
| 已有 EFCore 技术沉淀 / 需要 Database First | ❌ 选 EFCore 版 |
| 短期内需要 Entity Framework Migrations | ❌ 选 EFCore 版 |

## 3.8 迁移指南（EFCore → SqlSugar）

1. 拷贝 `vol.api.sqlsugar` 整个目录。
2. 在 `appsettings.json` 中把 `DBType` 改为目标数据库（如 `MySql`）。
3. 业务 `Service/Repository` 一般无需改动，因为 `ServiceBase` / `RepositoryBase` 抽象是一致的。
4. 实体特性：EFCore 实体本身没有特性；如迁到 SqlSugar 需要补 `[SugarTable]` 与 `[SugarColumn]`（或在 `MappingManager` 中显式配置）。
5. 删除 `DapperParseGuidTypeHandler` 相关初始化代码（SqlSugar 不需要）。
6. `Program.cs` 调整：
   - 移除 `DapperParseGuidTypeHandler.InitParseGuid()`
   - 新增 `builder.Services.UseSqlSugar()`
7. `appsettings.json` 字段差异：参考 EFCore 版的 `Connection` 段，调整 `DBType` 即可。

## 3.9 关键运行命令

```bash
cd vol.api.sqlsugar
dotnet run --project VOL.WebApi            # 默认监听 http://*:9991
```

> Docker 部署与 EFCore 版一致，复用 `VOL.WebApi/Dockerfile`。
