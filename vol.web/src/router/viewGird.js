//多个页面指向同一个菜单时请加上属性：
// meta: {
//   dynamic: true,
// }
let viewgird = [
  {
    path: '/Sys_Log',
    name: 'sys_Log',
    component: () => import('@/views/sys/system/Sys_Log.vue')
  },
  {
    path: '/Sys_User',
    name: 'Sys_User',
    component: () => import('@/views/sys/system/Sys_User.vue')
  },
  {
    path: '/permission',
    name: 'permission',
    component: () => import('@/views/sys/Permission.vue')
  },

  {
    path: '/Sys_Dictionary',
    name: 'Sys_Dictionary',
    component: () => import('@/views/sys/system/Sys_Dictionary.vue')
  },
  {
    path: '/Sys_Role',
    name: 'Sys_Role',
    component: () => import('@/views/sys/system/Sys_Role.vue')
  },
  {
    path: '/FormDesignOptions',
    name: 'FormDesignOptions',
    component: () => import('@/views/sys/form/FormDesignOptions.vue')
  },
  {
    path: '/FormCollectionObject',
    name: 'FormCollectionObject',
    component: () => import('@/views/sys/form/FormCollectionObject.vue')
  },
  {
    path: '/Sys_WorkFlow',
    name: 'Sys_WorkFlow',
    component: () => import('@/views/sys/flow/Sys_WorkFlow.vue')
  },
  {
    path: '/Sys_WorkFlowStep',
    name: 'Sys_WorkFlowStep',
    component: () => import('@/views/sys/flow/Sys_WorkFlowStep.vue')
  },
  {
    path: '/Sys_WorkFlowTable',
    name: 'Sys_WorkFlowTable',
    component: () => import('@/views/sys/flow/Sys_WorkFlowTable.vue')
  },
  {
    path: '/Sys_WorkFlowTableStep',
    name: 'Sys_WorkFlowTableStep',
    component: () => import('@/views/sys/flow/Sys_WorkFlowTableStep.vue')
  },
  {
    path: '/flowList',
    name: 'flowList',
    component: () => import('@/views/sys/flow/FlowList.vue')
  },
  {
    path: '/Sys_QuartzOptions',
    name: 'Sys_QuartzOptions',
    component: () => import('@/views/sys/quartz/Sys_QuartzOptions.vue')
  },
  {
    path: '/Sys_QuartzLog',
    name: 'Sys_QuartzLog',
    component: () => import('@/views/sys/quartz/Sys_QuartzLog.vue')
  },
  {
    path: '/Sys_Department',
    name: 'Sys_Department',
    component: () => import('@/views/sys/system/Sys_Department.vue')
  },
  {
    path: '/MES_WarehouseManagement',
    name: 'MES_WarehouseManagement',
    component: () => import('@/views/mes/mes/MES_WarehouseManagement.vue')
  }, {
    path: '/MES_ProductOutbound',
    name: 'MES_ProductOutbound',
    component: () => import('@/views/mes/mes/MES_ProductOutbound.vue')
  }, {
    path: '/MES_LocationManagement',
    name: 'MES_LocationManagement',
    component: () => import('@/views/mes/mes/MES_LocationManagement.vue')
  }, {
    path: '/MES_InventoryManagement',
    name: 'MES_InventoryManagement',
    component: () => import('@/views/mes/mes/MES_InventoryManagement.vue')
  }, {
    path: '/MES_ProductInbound',
    name: 'MES_ProductInbound',
    component: () => import('@/views/mes/mes/MES_ProductInbound.vue')
  }, {
    path: '/MES_Customer',
    name: 'MES_Customer',
    component: () => import('@/views/mes/mes/MES_Customer.vue')
  }, {
    path: '/MES_Supplier',
    name: 'MES_Supplier',
    component: () => import('@/views/mes/mes/MES_Supplier.vue')
  }, {
    path: '/MES_ProductionLine',
    name: 'MES_ProductionLine',
    component: () => import('@/views/mes/mes/MES_ProductionLine.vue')
  }, {
    path: '/MES_Material',
    name: 'MES_Material',
    component: () => import('@/views/mes/mes/MES_Material.vue')
  }, {
    path: '/MES_ProductionLineDevice',
    name: 'MES_ProductionLineDevice',
    component: () => import('@/views/mes/mes/MES_ProductionLineDevice.vue')
  }, {
    path: '/MES_EquipmentManagement',
    name: 'MES_EquipmentManagement',
    component: () => import('@/views/mes/mes/MES_EquipmentManagement.vue')
  }, {
    path: '/MES_EquipmentRepair',
    name: 'MES_EquipmentRepair',
    component: () => import('@/views/mes/mes/MES_EquipmentRepair.vue')
  }, {
    path: '/MES_EquipmentFaultRecord',
    name: 'MES_EquipmentFaultRecord',
    component: () => import('@/views/mes/mes/MES_EquipmentFaultRecord.vue')
  }, {
    path: '/MES_EquipmentMaintenance',
    name: 'MES_EquipmentMaintenance',
    component: () => import('@/views/mes/mes/MES_EquipmentMaintenance.vue')
  }, {
    path: '/MES_Process',
    name: 'MES_Process',
    component: () => import('@/views/mes/mes/MES_Process.vue')
  }, {
    path: '/MES_ProcessReport',
    name: 'MES_ProcessReport',
    component: () => import('@/views/mes/mes/MES_ProcessReport.vue')
  }, {
    path: '/MES_ProcessRoute',
    name: 'MES_ProcessRoute',
    component: () => import('@/views/mes/mes/MES_ProcessRoute.vue')
  }, {
    path: '/MES_MaterialCatalog',
    name: 'MES_MaterialCatalog',
    component: () => import('@/views/mes/mes/MES_MaterialCatalog.vue')
  }, {
    path: '/MES_ProductionOrder',
    name: 'MES_ProductionOrder',
    component: () => import('@/views/mes/mes/MES_ProductionOrder.vue')
  }, {
    path: '/MES_ProductionPlanDetail',
    name: 'MES_ProductionPlanDetail',
    component: () => import('@/views/mes/mes/MES_ProductionPlanDetail.vue')
  }, {
    path: '/MES_ProductionPlanChangeRecord',
    name: 'MES_ProductionPlanChangeRecord',
    component: () => import('@/views/mes/mes/MES_ProductionPlanChangeRecord.vue')
  }, {
    path: '/MES_ProductionReporting',
    name: 'MES_ProductionReporting',
    component: () => import('@/views/mes/mes/MES_ProductionReporting.vue')
  }, {
    path: '/MES_DefectiveProductRecord',
    name: 'MES_DefectiveProductRecord',
    component: () => import('@/views/mes/mes/MES_DefectiveProductRecord.vue')
  }, {
    path: '/MES_Bom_Main',
    name: 'MES_Bom_Main',
    component: () => import('@/views/mes/mes/MES_Bom_Main.vue')
  }, {
    path: '/MES_QualityInspectionPlan',
    name: 'MES_QualityInspectionPlan',
    component: () => import('@/views/mes/mes/MES_QualityInspectionPlan.vue')
  }, {
    path: '/MES_QualityInspectionRecord',
    name: 'MES_QualityInspectionRecord',
    component: () => import('@/views/mes/mes/MES_QualityInspectionRecord.vue')
  }, {
    path: '/MES_SchedulingPlan',
    name: 'MES_SchedulingPlan',
    component: () => import('@/views/mes/mes/MES_SchedulingPlan.vue')
  }, {
    path: '/MES_Calendar',
    name: 'MES_Calendar',
    component: () => import('@/views/mes/mes/MES_Calendar.vue')
  }, {
    path: '/MES_Gantt',
    name: 'MES_Gantt',
    component: () => import('@/views/mes/mes/MES_Gantt.vue')
  }, {
    path: '/MES_Bom_Detail',
    name: 'MES_Bom_Detail',
    component: () => import('@/views/mes/mes/MES_Bom_Detail.vue')
  }, {
    path: '/ProductionState',
    name: 'ProductionState',
    component: () => import('@/views/mes/state/ProductionState.vue')
  },{
        path: '/TestService',
        name: 'TestService',
        component: () => import('@/views/mes/mes/TestService.vue')
    },
    {
        path: '/DC_Home',
        name: 'DC_Home',
        component: () => import('@/views/datacenter/home.vue')
    },
    {
        path: '/DC_SysUser',
        name: 'DC_SysUser',
        component: () => import('@/views/datacenter/system/users.vue')
    },
    {
        path: '/DC_SysOrg',
        name: 'DC_SysOrg',
        component: () => import('@/views/datacenter/system/orgs.vue')
    },
    {
        path: '/DC_SysPosition',
        name: 'DC_SysPosition',
        component: () => import('@/views/datacenter/system/positions.vue')
    },
    {
        path: '/DC_SysRole',
        name: 'DC_SysRole',
        component: () => import('@/views/datacenter/system/roles.vue')
    },
    {
        path: '/DC_SysGroup',
        name: 'DC_SysGroup',
        component: () => import('@/views/datacenter/system/groups.vue')
    },
    {
        path: '/DC_SysStrategy',
        name: 'DC_SysStrategy',
        component: () => import('@/views/datacenter/system/strategies.vue')
    },
    {
        path: '/DC_SysOperationLog',
        name: 'DC_SysOperationLog',
        component: () => import('@/views/datacenter/system/operationLogs.vue')
    },
    {
        path: '/DC_SysUserLoginLog',
        name: 'DC_SysUserLoginLog',
        component: () => import('@/views/datacenter/system/userLoginLogs.vue')
    },
    {
        path: '/DC_SysFileReference',
        name: 'DC_SysFileReference',
        component: () => import('@/views/datacenter/system/fileReferences.vue')
    },
    {
        path: '/DC_SysFile',
        name: 'DC_SysFile',
        component: () => import('@/views/datacenter/system/files.vue')
    },
    {
        path: '/DC_MktMember',
        name: 'DC_MktMember',
        component: () => import('@/views/datacenter/marketing/members.vue')
    },
    {
        path: '/DC_MktLevel',
        name: 'DC_MktLevel',
        component: () => import('@/views/datacenter/marketing/levels.vue')
    },
    {
        path: '/DC_MktCategory',
        name: 'DC_MktCategory',
        component: () => import('@/views/datacenter/marketing/categories.vue')
    },
    {
        path: '/DC_MktSpu',
        name: 'DC_MktSpu',
        component: () => import('@/views/datacenter/marketing/spus.vue')
    },
    {
        path: '/DC_MktOrderDetail',
        name: 'DC_MktOrderDetail',
        component: () => import('@/views/datacenter/marketing/orderDetails.vue')
    },
    {
        path: '/DC_MktRechargeRecord',
        name: 'DC_MktRechargeRecord',
        component: () => import('@/views/datacenter/marketing/rechargeRecords.vue')
    },
    {
        path: '/DC_MktWithdrawalRecord',
        name: 'DC_MktWithdrawalRecord',
        component: () => import('@/views/datacenter/marketing/withdrawalRecords.vue')
    },
    {
        path: '/DC_MktTradingFlow',
        name: 'DC_MktTradingFlow',
        component: () => import('@/views/datacenter/marketing/tradingFlows.vue')
    },
    {
        path: '/DC_MktYuebaoAccount',
        name: 'DC_MktYuebaoAccount',
        component: () => import('@/views/datacenter/marketing/yuebaoAccounts.vue')
    },
    {
        path: '/DC_MktYuebaoTradingFlow',
        name: 'DC_MktYuebaoTradingFlow',
        component: () => import('@/views/datacenter/marketing/yuebaoTradingFlows.vue')
    },
    {
        path: '/DC_MktBanner',
        name: 'DC_MktBanner',
        component: () => import('@/views/datacenter/marketing/banners.vue')
    },
    {
        path: '/DC_MktBulletin',
        name: 'DC_MktBulletin',
        component: () => import('@/views/datacenter/marketing/bulletins.vue')
    },
    {
        path: '/DC_MktCustomerService',
        name: 'DC_MktCustomerService',
        component: () => import('@/views/datacenter/marketing/customerServices.vue')
    },
    {
        path: '/DC_MktSetting',
        name: 'DC_MktSetting',
        component: () => import('@/views/datacenter/marketing/settings.vue')
    },
    {
        path: '/DC_MktWithdrawalKind',
        name: 'DC_MktWithdrawalKind',
        component: () => import('@/views/datacenter/marketing/withdrawalKinds.vue')
    },
    {
        path: '/DC_MktWallet',
        name: 'DC_MktWallet',
        component: () => import('@/views/datacenter/marketing/wallets.vue')
    },
    {
        path: '/DC_MktRecruitment',
        name: 'DC_MktRecruitment',
        component: () => import('@/views/datacenter/marketing/recruitments.vue')
    },
    {
        path: '/DC_MktNotice',
        name: 'DC_MktNotice',
        component: () => import('@/views/datacenter/marketing/notices.vue')
    },
    {
        path: '/DC_MktMemberLoginLog',
        name: 'DC_MktMemberLoginLog',
        component: () => import('@/views/datacenter/marketing/memberLoginLogs.vue')
    },
    {
        path: '/DC_MktWithdrawalAccountApproveLog',
        name: 'DC_MktWithdrawalAccountApproveLog',
        component: () => import('@/views/datacenter/marketing/withdrawalAccountApproveLogs.vue')
    },
    {
        path: '/DC_MktMemberDateStatistic',
        name: 'DC_MktMemberDateStatistic',
        component: () => import('@/views/datacenter/marketing/memberDateStatistics.vue')
    },
    {
        path: '/DC_MktMemberStatistic',
        name: 'DC_MktMemberStatistic',
        component: () => import('@/views/datacenter/marketing/memberStatistics.vue')
    },
    {
        path: '/DC_MktPerformanceStatistic',
        name: 'DC_MktPerformanceStatistic',
        component: () => import('@/views/datacenter/marketing/performanceStatistics.vue')
    },
    {
        path: '/DC_MktStatistic',
        name: 'DC_MktStatistic',
        component: () => import('@/views/datacenter/marketing/statistics.vue')
    },
    {
        path: '/DC_PtsGift',
        name: 'DC_PtsGift',
        component: () => import('@/views/datacenter/points/gifts.vue')
    },
    {
        path: '/DC_PtsAccount',
        name: 'DC_PtsAccount',
        component: () => import('@/views/datacenter/points/accounts.vue')
    },
    {
        path: '/DC_PtsFlow',
        name: 'DC_PtsFlow',
        component: () => import('@/views/datacenter/points/flows.vue')
    },
    {
        path: '/DC_PtsGiftOrder',
        name: 'DC_PtsGiftOrder',
        component: () => import('@/views/datacenter/points/giftOrders.vue')
    },
    {
        path: '/DC_ActActivity',
        name: 'DC_ActActivity',
        component: () => import('@/views/datacenter/activities/activities.vue')
    },
    {
        path: '/DC_ActPrize',
        name: 'DC_ActPrize',
        component: () => import('@/views/datacenter/activities/prizes.vue')
    },
    {
        path: '/DC_ActAccount',
        name: 'DC_ActAccount',
        component: () => import('@/views/datacenter/activities/accounts.vue')
    },
    {
        path: '/DC_ActPartner',
        name: 'DC_ActPartner',
        component: () => import('@/views/datacenter/activities/partners.vue')
    },
    {
        path: '/DC_WebCustomer',
        name: 'DC_WebCustomer',
        component: () => import('@/views/datacenter/website/customers.vue')
    }]

//上面的demo、MES开头的都是示例菜单，可以任意删除 
export default viewgird
