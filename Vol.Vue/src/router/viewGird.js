let viewgird = [
   {
        path: '/Sys_Log',
        name: 'sys_Log',
        component: () => import('@/views/system/Sys_Log.vue')
    }
    ,{
        path: '/Sys_User',
        name: 'Sys_User',
        component: () => import('@/views/system/Sys_User.vue')
    }    ,{
        path: '/Sys_Dictionary',
        name: 'Sys_Dictionary',
        component: () => import('@/views/system/Sys_Dictionary.vue')
    }    ,{
        path: '/Sys_Role',
        name: 'Sys_Role',
        component: () => import('@/views/system/Sys_Role.vue')
    }
    ,{
        path: '/Sys_DictionaryList',
        name: 'Sys_DictionaryList',
        component: () => import('@/views/system/Sys_DictionaryList.vue')
    }
    ,{
        path: '/SellOrder',
        name: 'SellOrder',
        component: () => import('@/views/order/SellOrder.vue')
    }    ,{
      path: '/vSellOrderImg',
      name: 'vSellOrderImg',
      component: () => import('@/views/order/vSellOrderImg.vue')
      }     ,{
        path: '/App_Appointment',
        name: 'App_Appointment',
        component: () => import('@/views/order/App_Appointment.vue')
    }    ,{
        path: '/App_TransactionAvgPrice',
        name: 'App_TransactionAvgPrice',
        component: () => import('@/views/appmanager/App_TransactionAvgPrice.vue')
    }    ,{
        path: '/App_Expert',
        name: 'App_Expert',
        component: () => import('@/views/appmanager/App_Expert.vue')
    }    ,{
        path: '/App_Transaction',
        name: 'App_Transaction',
        component: () => import('@/views/appmanager/App_Transaction.vue')
    }    ,{
        path: '/App_ReportPrice',
        name: 'App_ReportPrice',
        component: () => import('@/views/appmanager/App_ReportPrice.vue')
    }    ,{
        path: '/App_News',
        name: 'App_News',
        component: () => import('@/views/appmanager/App_News.vue')
    }
    ,{
        path: '/Sys_Group',
        name: 'Sys_Group',
        component: () => import('@/views/system/Sys_Group.vue')
    }
    ,{
        path: '/Sys_Position',
        name: 'Sys_Position',
        component: () => import('@/views/system/Sys_Position.vue')
    }
    ,{
        path: '/Sys_Org',
        name: 'Sys_Org',
        component: () => import('@/views/system/Sys_Org.vue')
    }
    ,{
        path: '/Sys_Strategy',
        name: 'Sys_Strategy',
        component: () => import('@/views/system/Sys_Strategy.vue')
    }
    ,{
        path: '/Sys_File',
        name: 'Sys_File',
        component: () => import('@/views/system/Sys_File.vue')
    }
    ,{
        path: '/Sys_FileReference',
        name: 'Sys_FileReference',
        component: () => import('@/views/system/Sys_FileReference.vue')
    }
    ,{
        path: '/Sys_OperationLog',
        name: 'Sys_OperationLog',
        component: () => import('@/views/system/Sys_OperationLog.vue')
    }
    ,{
        path: '/Sys_UserLoginLog',
        name: 'Sys_UserLoginLog',
        component: () => import('@/views/system/Sys_UserLoginLog.vue')
    }
    ,{
        path: '/Mkt_Member',
        name: 'Mkt_Member',
        component: () => import('@/views/marketing/Mkt_Member.vue')
    }
    ,{
        path: '/Mkt_Level',
        name: 'Mkt_Level',
        component: () => import('@/views/marketing/Mkt_Level.vue')
    }
    ,{
        path: '/Mkt_Notice',
        name: 'Mkt_Notice',
        component: () => import('@/views/marketing/Mkt_Notice.vue')
    }
    ,{
        path: '/Mkt_MemberLoginLog',
        name: 'Mkt_MemberLoginLog',
        component: () => import('@/views/marketing/Mkt_MemberLoginLog.vue')
    }
    ,{
        path: '/Mkt_MemberStatistic',
        name: 'Mkt_MemberStatistic',
        component: () => import('@/views/marketing/Mkt_MemberStatistic.vue')
    }
    ,{
        path: '/Mkt_MemberDateStatistic',
        name: 'Mkt_MemberDateStatistic',
        component: () => import('@/views/marketing/Mkt_MemberDateStatistic.vue')
    }
    ,{
        path: '/Mkt_PerformanceStatistic',
        name: 'Mkt_PerformanceStatistic',
        component: () => import('@/views/marketing/Mkt_PerformanceStatistic.vue')
    }
    ,{
        path: '/Mkt_MemberDuplicateIp',
        name: 'Mkt_MemberDuplicateIp',
        component: () => import('@/views/marketing/Mkt_MemberDuplicateIp.vue')
    }
    ,{
        path: '/Mkt_WithdrawalAccountApproveLog',
        name: 'Mkt_WithdrawalAccountApproveLog',
        component: () => import('@/views/marketing/Mkt_WithdrawalAccountApproveLog.vue')
    }
    ,{
        path: '/Mkt_OrderDetail',
        name: 'Mkt_OrderDetail',
        component: () => import('@/views/marketing/Mkt_OrderDetail.vue')
    }
    ,{
        path: '/Mkt_RechargeRecord',
        name: 'Mkt_RechargeRecord',
        component: () => import('@/views/marketing/Mkt_RechargeRecord.vue')
    }
    ,{
        path: '/Mkt_WithdrawalRecord',
        name: 'Mkt_WithdrawalRecord',
        component: () => import('@/views/marketing/Mkt_WithdrawalRecord.vue')
    }
    ,{
        path: '/Mkt_TradingFlow',
        name: 'Mkt_TradingFlow',
        component: () => import('@/views/marketing/Mkt_TradingFlow.vue')
    }
    ,{
        path: '/Mkt_YuebaoAccount',
        name: 'Mkt_YuebaoAccount',
        component: () => import('@/views/marketing/Mkt_YuebaoAccount.vue')
    }
    ,{
        path: '/Mkt_YuebaoTradingFlow',
        name: 'Mkt_YuebaoTradingFlow',
        component: () => import('@/views/marketing/Mkt_YuebaoTradingFlow.vue')
    }
    ,{
        path: '/Mkt_Banner',
        name: 'Mkt_Banner',
        component: () => import('@/views/marketing/Mkt_Banner.vue')
    }
    ,{
        path: '/Mkt_Bulletin',
        name: 'Mkt_Bulletin',
        component: () => import('@/views/marketing/Mkt_Bulletin.vue')
    }
    ,{
        path: '/Mkt_CustomerService',
        name: 'Mkt_CustomerService',
        component: () => import('@/views/marketing/Mkt_CustomerService.vue')
    }
    ,{
        path: '/Mkt_Setting',
        name: 'Mkt_Setting',
        component: () => import('@/views/marketing/Mkt_Setting.vue')
    }
    ,{
        path: '/Mkt_Statistic',
        name: 'Mkt_Statistic',
        component: () => import('@/views/marketing/Mkt_Statistic.vue')
    }
    ,{
        path: '/Mkt_WithdrawalKind',
        name: 'Mkt_WithdrawalKind',
        component: () => import('@/views/marketing/Mkt_WithdrawalKind.vue')
    }
    ,{
        path: '/Mkt_Wallet',
        name: 'Mkt_Wallet',
        component: () => import('@/views/marketing/Mkt_Wallet.vue')
    }
    ,{
        path: '/Mkt_Recruitment',
        name: 'Mkt_Recruitment',
        component: () => import('@/views/marketing/Mkt_Recruitment.vue')
    }
    ,{
        path: '/Mkt_Spu',
        name: 'Mkt_Spu',
        component: () => import('@/views/marketing/Mkt_Spu.vue')
    }
    ,{
        path: '/Mkt_Category',
        name: 'Mkt_Category',
        component: () => import('@/views/marketing/Mkt_Category.vue')
    }
    ,{
        path: '/Pts_Gift',
        name: 'Pts_Gift',
        component: () => import('@/views/points/Pts_Gift.vue')
    }
    ,{
        path: '/Pts_GiftOrder',
        name: 'Pts_GiftOrder',
        component: () => import('@/views/points/Pts_GiftOrder.vue')
    }
    ,{
        path: '/Pts_Account',
        name: 'Pts_Account',
        component: () => import('@/views/points/Pts_Account.vue')
    }
    ,{
        path: '/Pts_Flow',
        name: 'Pts_Flow',
        component: () => import('@/views/points/Pts_Flow.vue')
    }
    ,{
        path: '/Act_Activity',
        name: 'Act_Activity',
        component: () => import('@/views/activities/Act_Activity.vue')
    }
    ,{
        path: '/Act_Prize',
        name: 'Act_Prize',
        component: () => import('@/views/activities/Act_Prize.vue')
    }
    ,{
        path: '/Act_Account',
        name: 'Act_Account',
        component: () => import('@/views/activities/Act_Account.vue')
    }
    ,{
        path: '/Act_Partner',
        name: 'Act_Partner',
        component: () => import('@/views/activities/Act_Partner.vue')
    }
    ,{
        path: '/Web_Customer',
        name: 'Web_Customer',
        component: () => import('@/views/websites/Web_Customer.vue')
    }]
export default viewgird
