# 04. 前端架构 (vol.web)

> 入口：`vol.web/`
> 技术栈：**Vue 3.5+ / Vite 6 / TypeScript 5.6 / Element Plus 2.11 / Pinia 3**

## 4.1 工程结构

```
vol.web
├── public/                      # 不参与打包的静态资源
│   ├── static/                  #   imgs / login_bg.png
│   ├── favicon.ico
│   └── vol.css
│
├── src/
│   ├── api/                     # HTTP 封装
│   │   ├── http.js              #   axios 实例 + 拦截器 + Token 刷新
│   │   ├── buttons.js           #   按钮权限指令
│   │   └── permission.js
│   ├── assets/                  # 全局资源
│   │   ├── css/common.less
│   │   ├── element-icon/icon.css
│   │   ├── script/              # common.js / extend.js / buttons.js…
│   │   └── imgs/                # logo / default_header / error…
│   ├── components/              # 通用业务组件
│   │   ├── VolProvider/         #   框架级 Provider（缓存 / 权限 / 压缩）
│   │   ├── basic/               #   ⭐ 核心组件 VolTable / VolForm / VolBox
│   │   ├── editor/              #   wangEditor 富文本
│   │   ├── lang/                #   国际化切换
│   │   ├── redirect/            #   401 / 404 / coding / message
│   │   └── workflow/            #   ⭐ 流程图设计器（基于 jsplumb）
│   ├── extension/mes/           # 业务扩展占位
│   ├── router/                  # 路由 + 动态菜单 viewGird
│   ├── store/                   # Pinia/Vuex
│   ├── uitils/                  # 工具 + i18n
│   │   ├── common.js
│   │   └── translator/{en.js,index.js}
│   ├── views/                   # 页面
│   │   ├── builder/             #   ⭐ 在线代码生成器
│   │   ├── formDraggable/       #   ⭐ 表单设计器
│   │   ├── index/               #   框架主框架页 (Index.vue)
│   │   ├── mes/                 #   MES 业务页面（演示）
│   │   ├── signalR/             #   SignalR 调试页
│   │   ├── sys/                 #   用户/权限/系统管理
│   │   ├── Home.vue
│   │   ├── Index.vue
│   │   └── Login.vue
│   ├── App.vue
│   └── main.js                  # 应用入口
│
├── index.html
├── package.json
├── vite.config.ts
├── tsconfig.json
├── tsconfig.app.json
├── tsconfig.node.json
├── env.d.ts
├── babel.config.js
├── .eslintrc.cjs / .eslintrc.js
├── .prettierrc.json
├── .browserslistrc
├── build.bat / run.bat / install.bat
├── volar.config.js
└── README.md
```

## 4.2 package.json 关键依赖

```jsonc
"dependencies": {
  "@microsoft/signalr": "^8.0.7",   // 实时消息
  "ali-oss": "^6.23.0",             // 阿里云 OSS
  "axios": "^1.15.0",               // HTTP
  "echarts": "^5.6.0",              // 图表
  "element-plus": "^2.11.4",        // UI
  "less": "^4.4.0",                 // CSS 预处理
  "pinia": "^3.0.3",                // 状态管理
  "qrcode.vue": "^3.6.0",           // 二维码
  "sortablejs": "^1.15.3",          // 拖拽
  "vue": "^3.5.13", "vue-router": "^4.5.1", "vuex": "^4.1.0",
  "vue-draggable-next": "^2.2.1",
  "wangeditor": "^4.7.15"           // 富文本
},
"devDependencies": {
  "@vitejs/plugin-vue": "^5.2.1",
  "@vitejs/plugin-vue-jsx": "^4.0.0",
  "typescript": "~5.6.2",
  "vite": "^6.0.1",
  "vue-tsc": "^2.1.10"
}
```

## 4.3 vite.config.ts 关键配置

```ts
export default defineConfig({
  plugins: [removePureAnnotation, vue(), vueJsx()],
  server: { port: 9990 },                  // 前端 dev 端口
  build: {
    chunkSizeWarningLimit: 1000,
    rollupOptions: {
      manualChunks(id) { /* node_modules 分包 */ },
      entryFileNames: "assets/js/[hash].js",
      chunkFileNames: "assets/js/[hash].js",
      assetFileNames:  "assets/[ext]/[hash].[ext]"
    },
    sourcemap: false
  },
  resolve: {
    alias: { "@": fileURLToPath(new URL("./src", import.meta.url)) }
  }
})
```

## 4.4 入口与全局配置（main.js）

```js
const app = createApp(App)
app.config.globalProperties.base = Object.assign(base, VolProvider)   // 框架基础方法
app.config.globalProperties.http = http
app.config.globalProperties.$tabs = {}
app.config.globalProperties.permission = permission
app.config.globalProperties.$global = {
  useIncludeCache: true,   // 旧版本升级需设为 false
  theme: 'blue',           // dark/blue/red/orange/green
  layout: 'top',           // classics=经典导航 | top=顶部导航
  menuSearch: true,
  navSearch: true,
  table: { useTag: true },
  border: true,
  labelPosition: 'left',   // 表单 label 位置
  signalR: true,
  audit: { data: [/*通过/拒绝/驳回*/], status: [0, 2] }
}
app.use(store).use(ElementPlus).use(router)
   .use(VolTitle).use(VolTable).use(VolForm).use(VolBox)
   .mount('#app')
```

## 4.5 路由（src/router/index.js）

```
/                       ── Index.vue 框架主容器
  ├── /home             ── 首页
  ├── /UserInfo         ── 用户信息
  ├── /sysMenu          ── 菜单/权限管理
  ├── /coder            ── ⭐ 在线代码生成器
  ├── /formDraggable    ── ⭐ 表单设计器
  ├── /formSubmit       ── 表单提交页
  ├── /formCollectionResultTree
  ├── /signalR          ── SignalR 演示
  └── ...viewgird (动态路由，由后端菜单生成)
/login                  ── 登录页
```

动态路由在 `viewGird.js` 中按后端返回的菜单树生成。

## 4.6 核心组件：VolTable

路径：`src/components/basic/VolTable/`

提供：

- 列配置（key、title、width、type、绑定、格式化、字典、sortable、fixed）
- 自适应列宽
- 表头筛选 / 排序
- 单元格编辑（input/select/date/switch）
- 行内按钮（按权限渲染）
- 树形结构 / 主从表嵌套
- 数据源自动绑定（select/checkbox/radio）
- 合计行（SummaryExpress 后端汇总）
- 导入 / 导出

## 4.7 核心组件：VolForm

路径：`src/components/basic/VolForm/`

提供：

- 30+ 表单字段类型（input/select/date/upload/editor/tree/switch/slider…）
- 自动绑定字典 / 远程数据源
- 主从表编辑
- 字段权限（按 TableColumnContext）
- 校验规则 / 自定义校验
- 表单事件（change/select…）

## 4.8 核心组件：VolBox

路径：`src/components/basic/VolBox/`

抽屉 / 弹窗 / 弹出编辑表单的容器。配合 VolForm 实现"行内弹窗编辑"。

## 4.9 VolProvider（src/components/VolProvider）

- `VolStoreCache.js`  ─ 全局本地缓存（localStorage/sessionStorage）
- `VolPermission.js`  ─ 按钮 / 菜单 / 字段权限指令
- `VolProvider.js`    ─ 注册到 `app.config.globalProperties.base`
- `VolImgCompress.js` ─ 图片压缩

## 4.10 表单设计器（formDraggable）

路径：`src/views/formDraggable/`

- `formDraggable.vue`  ─ 拖拽式表单设计主页面
- `FormSubmit.vue`     ─ 表单提交
- `FormCollectionResultTree.vue` ─ 数据收集结果
- 配套后端：`VOL.Sys/Repositories/form/*`、`VOL.Sys/Services/form/*`

支持字段类型、校验规则、布局（栅格）、数据源联动、提交后回调。

## 4.11 流程图设计器（workflow）

路径：`src/components/workflow/`

- `workflow.vue`  ─ 画布
- `node.vue` / `node_form.vue` / `node_menu.vue` / `node_filter.vue`  ─ 节点配置
- `panel.vue`  ─ 工具面板
- `force-directed.js` / `jsplumb.js`  ─ 关系计算
- `mixins.js` / `utils.js` / `data_*.js`

> 基于 jsplumb 实现审批流的可视化配置。流程模板与实例分别落在 `Sys_WorkFlow*` / `Sys_WorkFlowTable*` 表中。

## 4.12 代码生成器前端（builder）

路径：`src/views/builder/`

- `coder.vue`  ─ 生成器主页面
- `coderV2Form.vue` / `coderV2Table.vue` / `coderV2Tree.vue` / `coderV2DetailSelect.vue` / `coderV2SortFieldSelect.vue`  ─ 表/树/排序/明细配置
- `coderV2Options.jsx`  ─ 配置项
- `builderData.jsx`  ─ 数据

通过 30+ 配置项（字段类型、查询条件、表单控件、字典、权限、校验、关联、树、汇总…）生成完整的前后端代码。

## 4.13 API 层（src/api/http.js）

```js
axios.defaults.baseURL = process.env.NODE_ENV == 'production'
  ? 'http://api.volcore.xyz/' : 'http://localhost:9991/'
axios.defaults.timeout = 1000*60*5
// 响应拦截：401 跳登录；header 'vol_exp' 触发 token 刷新
```

全局方法挂载：
- `this.http.post(url, params)`  / `.get(url)` / `.put` / `.delete`
- `this.base.getUrl()` / `this.base.getDic()` / `this.base.openForm()` 等框架级方法
- `this.permission.hasBtn('xxx')` 按钮权限

## 4.14 状态管理（src/store/index.js）

使用 Pinia 3（Vuex 4 兼容），主要管理：
- `userInfo` / `token` / `permissions`
- `tabs` / `activeMenu`
- `globalLoading`
- `dictionaries`（字典缓存）

## 4.15 工具与国际化（src/uitils）

- `common.js`  ─ 通用工具（日期格式化、深拷贝、防抖、节流…）
- `translator/` ─ i18n 切换（en.js / index.js）

## 4.16 开发与构建

```bash
# 安装依赖
npm install / yarn

# 本地开发（默认 http://localhost:9990）
npm run dev   # = vite --host

# 类型检查 + 构建
npm run build
# 或仅构建
npm run build:only   # 包脚本里无此条目，按需执行 vite build

# 代码风格
npm run lint
npm run format
```

> 端口约定：前端 `9990`，后端 `9991`。`http.js` 中默认指向后端 `localhost:9991`。

## 4.17 二次开发入口

| 需求 | 入口 |
|------|------|
| 新增业务菜单 | `views/xxx/xxx.vue` + 后端 `Sys_Menu` 表新增数据 |
| 自定义表格列 | `VolTable` 列配置 + `extend.js` 扩展方法 |
| 自定义表单控件 | `VolForm` 字段 type 注册 |
| 按钮权限 | `v-permission="xxx"` 指令 + `Sys_Menu.Auth` 字段 |
| 数据权限 | 后端 `ApiAuthorizeFilter` + `UserContext.DeptIds` |
| 新增字典 | `Sys_Dictionary` + `Sys_DictionaryList` |
| 表单设计 | `views/formDraggable/formDraggable.vue` |
| 流程图 | `views/...` 调用 `components/workflow` |
| 主题切换 | `main.js#global.theme` 配合 `assets/css/common.less` |
