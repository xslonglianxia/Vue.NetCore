-- ============================================================
-- DataCenter 管理系统 数据库脚本
-- 数据库: datacenter
-- 字符集: utf8mb4
-- 排序规则: utf8mb4_general_ci
-- 引擎: InnoDB
-- ============================================================

CREATE DATABASE IF NOT EXISTS `datacenter` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

USE `datacenter`;

-- ============================================================
-- 一、系统模块 (sys_*)
-- ============================================================

-- -----------------------------------------------------------
-- 1. sys_users - 系统用户表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_users`;
CREATE TABLE `sys_users` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `account` VARCHAR(64) NOT NULL COMMENT '登录账号',
  `password` VARCHAR(128) NOT NULL COMMENT '登录密码(MD5)',
  `name` VARCHAR(64) NOT NULL COMMENT '用户姓名',
  `phone` VARCHAR(20) DEFAULT NULL COMMENT '手机号码',
  `email` VARCHAR(128) DEFAULT NULL COMMENT '电子邮箱',
  `avatar` VARCHAR(512) DEFAULT NULL COMMENT '头像地址',
  `role_id` BIGINT DEFAULT NULL COMMENT '角色ID',
  `org_id` BIGINT DEFAULT NULL COMMENT '组织ID',
  `position_id` BIGINT DEFAULT NULL COMMENT '职位ID',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `locked` TINYINT NOT NULL DEFAULT 0 COMMENT '是否锁定(0:未锁定 1:已锁定)',
  `lock_count` INT NOT NULL DEFAULT 0 COMMENT '连续锁定次数',
  `lock_time` DATETIME DEFAULT NULL COMMENT '锁定时间',
  `last_login_time` DATETIME DEFAULT NULL COMMENT '最后登录时间',
  `last_login_ip` VARCHAR(64) DEFAULT NULL COMMENT '最后登录IP',
  `last_modify_pwd_time` DATETIME DEFAULT NULL COMMENT '最后修改密码时间',
  `mfa_secret` VARCHAR(64) DEFAULT NULL COMMENT 'MFA密钥',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_account` (`account`),
  KEY `idx_role_id` (`role_id`),
  KEY `idx_org_id` (`org_id`),
  KEY `idx_position_id` (`position_id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='系统用户表';

-- -----------------------------------------------------------
-- 2. sys_roles - 角色表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_roles`;
CREATE TABLE `sys_roles` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '角色名称',
  `code` VARCHAR(64) NOT NULL COMMENT '角色编码',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '角色描述',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色表';

-- -----------------------------------------------------------
-- 3. sys_groups - 权限分组表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_groups`;
CREATE TABLE `sys_groups` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '分组名称',
  `code` VARCHAR(64) NOT NULL COMMENT '分组编码',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '分组描述',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='权限分组表';

-- -----------------------------------------------------------
-- 4. sys_positions - 职位表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_positions`;
CREATE TABLE `sys_positions` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '职位名称',
  `code` VARCHAR(64) NOT NULL COMMENT '职位编码',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '职位描述',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='职位表';

-- -----------------------------------------------------------
-- 5. sys_orgs - 组织机构表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_orgs`;
CREATE TABLE `sys_orgs` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `parent_id` BIGINT DEFAULT 0 COMMENT '父级ID(0为顶级)',
  `name` VARCHAR(64) NOT NULL COMMENT '组织名称',
  `code` VARCHAR(64) NOT NULL COMMENT '组织编码',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '组织描述',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_parent_id` (`parent_id`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='组织机构表';

-- -----------------------------------------------------------
-- 6. sys_strategies - 权限策略表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_strategies`;
CREATE TABLE `sys_strategies` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '策略名称',
  `code` VARCHAR(64) NOT NULL COMMENT '策略编码',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '策略描述',
  `content` TEXT DEFAULT NULL COMMENT '策略内容(JSON)',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='权限策略表';

-- -----------------------------------------------------------
-- 7. sys_files - 文件表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_files`;
CREATE TABLE `sys_files` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(256) NOT NULL COMMENT '文件名称',
  `original_name` VARCHAR(256) NOT NULL COMMENT '原始文件名',
  `extension` VARCHAR(32) DEFAULT NULL COMMENT '文件扩展名',
  `size` BIGINT NOT NULL DEFAULT 0 COMMENT '文件大小(字节)',
  `mime_type` VARCHAR(128) DEFAULT NULL COMMENT 'MIME类型',
  `path` VARCHAR(512) NOT NULL COMMENT '文件存储路径',
  `hash` VARCHAR(128) DEFAULT NULL COMMENT '文件哈希值',
  `storage_type` VARCHAR(32) NOT NULL DEFAULT 'local' COMMENT '存储类型(local/oss/cos)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_hash` (`hash`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='文件表';

-- -----------------------------------------------------------
-- 8. sys_file_references - 文件引用表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_file_references`;
CREATE TABLE `sys_file_references` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `file_id` BIGINT NOT NULL COMMENT '文件ID',
  `entity_type` VARCHAR(64) NOT NULL COMMENT '实体类型',
  `entity_id` BIGINT NOT NULL COMMENT '实体ID',
  `field_name` VARCHAR(64) DEFAULT NULL COMMENT '字段名称',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_file_id` (`file_id`),
  KEY `idx_entity` (`entity_type`, `entity_id`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='文件引用表';

-- -----------------------------------------------------------
-- 9. sys_operation_logs - 操作日志表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_operation_logs`;
CREATE TABLE `sys_operation_logs` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `user_id` BIGINT DEFAULT NULL COMMENT '操作用户ID',
  `user_name` VARCHAR(64) DEFAULT NULL COMMENT '操作用户名',
  `module` VARCHAR(64) DEFAULT NULL COMMENT '操作模块',
  `action` VARCHAR(64) DEFAULT NULL COMMENT '操作动作',
  `method` VARCHAR(16) DEFAULT NULL COMMENT '请求方法',
  `url` VARCHAR(512) DEFAULT NULL COMMENT '请求URL',
  `ip` VARCHAR(64) DEFAULT NULL COMMENT '操作IP',
  `user_agent` VARCHAR(512) DEFAULT NULL COMMENT '用户代理',
  `request_data` TEXT DEFAULT NULL COMMENT '请求数据',
  `response_data` TEXT DEFAULT NULL COMMENT '响应数据',
  `duration` INT DEFAULT NULL COMMENT '耗时(毫秒)',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_user_id` (`user_id`),
  KEY `idx_module` (`module`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='操作日志表';

-- -----------------------------------------------------------
-- 10. sys_user_login_logs - 用户登录日志表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_login_logs`;
CREATE TABLE `sys_user_login_logs` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `user_id` BIGINT DEFAULT NULL COMMENT '用户ID',
  `user_name` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `login_type` VARCHAR(32) DEFAULT NULL COMMENT '登录类型',
  `ip` VARCHAR(64) DEFAULT NULL COMMENT '登录IP',
  `location` VARCHAR(128) DEFAULT NULL COMMENT '登录地点',
  `user_agent` VARCHAR(512) DEFAULT NULL COMMENT '用户代理',
  `browser` VARCHAR(64) DEFAULT NULL COMMENT '浏览器',
  `os` VARCHAR(64) DEFAULT NULL COMMENT '操作系统',
  `status` TINYINT NOT NULL DEFAULT 1 COMMENT '登录状态(0:失败 1:成功)',
  `message` VARCHAR(256) DEFAULT NULL COMMENT '提示消息',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_user_id` (`user_id`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='用户登录日志表';

-- -----------------------------------------------------------
-- 48. sys_menus - 菜单表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_menus`;
CREATE TABLE `sys_menus` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `parent_id` BIGINT DEFAULT 0 COMMENT '父级菜单ID(0为顶级)',
  `name` VARCHAR(64) NOT NULL COMMENT '菜单名称',
  `path` VARCHAR(256) DEFAULT NULL COMMENT '路由路径',
  `icon` VARCHAR(128) DEFAULT NULL COMMENT '菜单图标',
  `component` VARCHAR(256) DEFAULT NULL COMMENT '前端组件路径',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_parent_id` (`parent_id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='菜单表';

-- ============================================================
-- 二、关联表 (sys_role_*)
-- ============================================================

-- -----------------------------------------------------------
-- 45. sys_role_strategies - 角色-策略关联表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_role_strategies`;
CREATE TABLE `sys_role_strategies` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `role_id` BIGINT NOT NULL COMMENT '角色ID',
  `strategy_id` BIGINT NOT NULL COMMENT '策略ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_role_strategy` (`role_id`, `strategy_id`),
  KEY `idx_strategy_id` (`strategy_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色-策略关联表';

-- -----------------------------------------------------------
-- 46. sys_role_groups - 角色-分组关联表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_role_groups`;
CREATE TABLE `sys_role_groups` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `role_id` BIGINT NOT NULL COMMENT '角色ID',
  `group_id` BIGINT NOT NULL COMMENT '分组ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_role_group` (`role_id`, `group_id`),
  KEY `idx_group_id` (`group_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色-分组关联表';

-- -----------------------------------------------------------
-- 47. sys_role_menus - 角色-菜单关联表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `sys_role_menus`;
CREATE TABLE `sys_role_menus` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `role_id` BIGINT NOT NULL COMMENT '角色ID',
  `menu_id` BIGINT NOT NULL COMMENT '菜单ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_role_menu` (`role_id`, `menu_id`),
  KEY `idx_menu_id` (`menu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色-菜单关联表';

-- ============================================================
-- 三、营销模块 (mkt_*)
-- ============================================================

-- -----------------------------------------------------------
-- 11. mkt_members - 会员表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_members`;
CREATE TABLE `mkt_members` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `username` VARCHAR(64) NOT NULL COMMENT '用户名',
  `nickname` VARCHAR(64) DEFAULT NULL COMMENT '昵称',
  `phone` VARCHAR(20) DEFAULT NULL COMMENT '手机号码',
  `email` VARCHAR(128) DEFAULT NULL COMMENT '电子邮箱',
  `avatar` VARCHAR(512) DEFAULT NULL COMMENT '头像地址',
  `level_id` BIGINT DEFAULT NULL COMMENT '会员等级ID',
  `parent_id` BIGINT DEFAULT NULL COMMENT '上级会员ID',
  `balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '可用余额',
  `frozen_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '冻结余额',
  `commission_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金余额',
  `total_recharge` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '累计充值',
  `total_withdrawal` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '累计提现',
  `total_commission` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '累计佣金',
  `ip` VARCHAR(64) DEFAULT NULL COMMENT '注册IP',
  `last_login_time` DATETIME DEFAULT NULL COMMENT '最后登录时间',
  `last_login_ip` VARCHAR(64) DEFAULT NULL COMMENT '最后登录IP',
  `status` TINYINT NOT NULL DEFAULT 1 COMMENT '状态(0:禁用 1:正常 2:审核中)',
  `real_name` VARCHAR(64) DEFAULT NULL COMMENT '真实姓名',
  `id_card` VARCHAR(32) DEFAULT NULL COMMENT '身份证号',
  `bank_name` VARCHAR(64) DEFAULT NULL COMMENT '银行名称',
  `bank_account` VARCHAR(64) DEFAULT NULL COMMENT '银行账号',
  `bank_branch` VARCHAR(128) DEFAULT NULL COMMENT '银行支行',
  `invite_code` VARCHAR(32) DEFAULT NULL COMMENT '邀请码',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_username` (`username`),
  KEY `idx_phone` (`phone`),
  KEY `idx_level_id` (`level_id`),
  KEY `idx_parent_id` (`parent_id`),
  KEY `idx_invite_code` (`invite_code`),
  KEY `idx_status` (`status`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员表';

-- -----------------------------------------------------------
-- 12. mkt_levels - 会员等级表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_levels`;
CREATE TABLE `mkt_levels` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '等级名称',
  `icon` VARCHAR(512) DEFAULT NULL COMMENT '等级图标',
  `min_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '最低充值金额',
  `max_amount` DECIMAL(18,2) DEFAULT NULL COMMENT '最高充值金额',
  `discount` DECIMAL(5,2) NOT NULL DEFAULT 100.00 COMMENT '折扣(%)',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员等级表';

-- -----------------------------------------------------------
-- 13. mkt_notices - 公告表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_notices`;
CREATE TABLE `mkt_notices` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '公告标题',
  `content` TEXT DEFAULT NULL COMMENT '公告内容',
  `type` TINYINT NOT NULL DEFAULT 1 COMMENT '公告类型(1:通知 2:活动 3:系统)',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `publish_time` DATETIME DEFAULT NULL COMMENT '发布时间',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_type` (`type`),
  KEY `idx_enable` (`enable`),
  KEY `idx_publish_time` (`publish_time`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='公告表';

-- -----------------------------------------------------------
-- 14. mkt_member_login_logs - 会员登录日志表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_login_logs`;
CREATE TABLE `mkt_member_login_logs` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `ip` VARCHAR(64) DEFAULT NULL COMMENT '登录IP',
  `location` VARCHAR(128) DEFAULT NULL COMMENT '登录地点',
  `user_agent` VARCHAR(512) DEFAULT NULL COMMENT '用户代理',
  `browser` VARCHAR(64) DEFAULT NULL COMMENT '浏览器',
  `os` VARCHAR(64) DEFAULT NULL COMMENT '操作系统',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员登录日志表';

-- -----------------------------------------------------------
-- 15. mkt_member_statistics - 会员统计表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_statistics`;
CREATE TABLE `mkt_member_statistics` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `recharge_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '充值金额',
  `withdrawal_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '提现金额',
  `commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金金额',
  `give_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '赠送金额',
  `order_number` INT NOT NULL DEFAULT 0 COMMENT '订单数量',
  `date` DATE NOT NULL COMMENT '统计日期',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_date` (`date`),
  UNIQUE KEY `uk_member_date` (`member_id`, `date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员统计表';

-- -----------------------------------------------------------
-- 16. mkt_member_date_statistics - 会员日期统计表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_date_statistics`;
CREATE TABLE `mkt_member_date_statistics` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `date` DATE NOT NULL COMMENT '统计日期',
  `member_number` INT NOT NULL DEFAULT 0 COMMENT '新增会员数',
  `recharge_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '充值金额',
  `recharge_number` INT NOT NULL DEFAULT 0 COMMENT '充值笔数',
  `withdrawal_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '提现金额',
  `withdrawal_number` INT NOT NULL DEFAULT 0 COMMENT '提现笔数',
  `commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金金额',
  `commission_number` INT NOT NULL DEFAULT 0 COMMENT '佣金笔数',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '上级佣金金额',
  `parent_commission_number` INT NOT NULL DEFAULT 0 COMMENT '上级佣金笔数',
  `give_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '赠送金额',
  `give_number` INT NOT NULL DEFAULT 0 COMMENT '赠送笔数',
  `sign_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '签到金额',
  `sign_number` INT NOT NULL DEFAULT 0 COMMENT '签到笔数',
  `order_number` INT NOT NULL DEFAULT 0 COMMENT '订单数量',
  `bet_number` INT NOT NULL DEFAULT 0 COMMENT '投注数量',
  `task_complete_number` INT NOT NULL DEFAULT 0 COMMENT '任务完成数',
  `reset_number` INT NOT NULL DEFAULT 0 COMMENT '重置数量',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员日期统计表';

-- -----------------------------------------------------------
-- 17. mkt_performance_statistics - 业绩统计表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_performance_statistics`;
CREATE TABLE `mkt_performance_statistics` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `nickname` VARCHAR(64) DEFAULT NULL COMMENT '昵称',
  `level_name` VARCHAR(64) DEFAULT NULL COMMENT '等级名称',
  `parent_username` VARCHAR(64) DEFAULT NULL COMMENT '上级用户名',
  `recharge_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '充值金额',
  `withdrawal_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '提现金额',
  `commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金金额',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '上级佣金金额',
  `first_recharge_date` DATETIME DEFAULT NULL COMMENT '首次充值时间',
  `last_recharge_date` DATETIME DEFAULT NULL COMMENT '最后充值时间',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='业绩统计表';

-- -----------------------------------------------------------
-- 18. mkt_member_duplicate_ips - 会员重复IP表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_duplicate_ips`;
CREATE TABLE `mkt_member_duplicate_ips` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `ip` VARCHAR(64) NOT NULL COMMENT 'IP地址',
  `member_count` INT NOT NULL DEFAULT 0 COMMENT '关联会员数',
  `member_ids` TEXT DEFAULT NULL COMMENT '关联会员ID列表',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_ip` (`ip`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员重复IP表';

-- -----------------------------------------------------------
-- 19. mkt_withdrawal_account_approve_logs - 提现账户审核日志表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_account_approve_logs`;
CREATE TABLE `mkt_withdrawal_account_approve_logs` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `real_name` VARCHAR(64) DEFAULT NULL COMMENT '真实姓名',
  `bank_name` VARCHAR(64) DEFAULT NULL COMMENT '银行名称',
  `bank_account` VARCHAR(64) DEFAULT NULL COMMENT '银行账号',
  `status` TINYINT NOT NULL DEFAULT 0 COMMENT '审核状态(0:待审核 1:通过 2:拒绝)',
  `approve_user_id` BIGINT DEFAULT NULL COMMENT '审核人ID',
  `approve_user_name` VARCHAR(64) DEFAULT NULL COMMENT '审核人姓名',
  `approve_time` DATETIME DEFAULT NULL COMMENT '审核时间',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_status` (`status`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='提现账户审核日志表';

-- -----------------------------------------------------------
-- 20. mkt_order_details - 订单明细表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_order_details`;
CREATE TABLE `mkt_order_details` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `order_no` VARCHAR(64) NOT NULL COMMENT '订单编号',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `product_name` VARCHAR(128) DEFAULT NULL COMMENT '商品名称',
  `amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '订单金额',
  `commission_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT '佣金比例(%)',
  `commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金金额',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '上级佣金金额',
  `status` TINYINT NOT NULL DEFAULT 0 COMMENT '订单状态(0:待处理 1:进行中 2:已完成 3:已取消)',
  `type` TINYINT NOT NULL DEFAULT 1 COMMENT '订单类型(1:普通 2:加急)',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_order_no` (`order_no`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_status` (`status`),
  KEY `idx_type` (`type`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='订单明细表';

-- -----------------------------------------------------------
-- 21. mkt_recharge_records - 充值记录表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_recharge_records`;
CREATE TABLE `mkt_recharge_records` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `order_no` VARCHAR(64) NOT NULL COMMENT '订单编号',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '充值金额',
  `give_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '赠送金额',
  `payment_method` VARCHAR(32) DEFAULT NULL COMMENT '支付方式',
  `payment_channel` VARCHAR(32) DEFAULT NULL COMMENT '支付渠道',
  `status` TINYINT NOT NULL DEFAULT 0 COMMENT '状态(0:待支付 1:成功 2:失败 3:已关闭)',
  `audit_status` TINYINT NOT NULL DEFAULT 0 COMMENT '审核状态(0:待审核 1:通过 2:拒绝)',
  `audit_user_id` BIGINT DEFAULT NULL COMMENT '审核人ID',
  `audit_user_name` VARCHAR(64) DEFAULT NULL COMMENT '审核人姓名',
  `audit_time` DATETIME DEFAULT NULL COMMENT '审核时间',
  `visible` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可见(0:不可见 1:可见)',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_order_no` (`order_no`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_status` (`status`),
  KEY `idx_audit_status` (`audit_status`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='充值记录表';

-- -----------------------------------------------------------
-- 22. mkt_withdrawal_records - 提现记录表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_records`;
CREATE TABLE `mkt_withdrawal_records` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `order_no` VARCHAR(64) NOT NULL COMMENT '订单编号',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '提现金额',
  `fee` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '手续费',
  `real_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '实际到账金额',
  `bank_name` VARCHAR(64) DEFAULT NULL COMMENT '银行名称',
  `bank_account` VARCHAR(64) DEFAULT NULL COMMENT '银行账号',
  `real_name` VARCHAR(64) DEFAULT NULL COMMENT '真实姓名',
  `status` TINYINT NOT NULL DEFAULT 0 COMMENT '状态(0:待处理 1:成功 2:失败 3:已关闭)',
  `audit_status` TINYINT NOT NULL DEFAULT 0 COMMENT '审核状态(0:待审核 1:通过 2:拒绝)',
  `audit_user_id` BIGINT DEFAULT NULL COMMENT '审核人ID',
  `audit_user_name` VARCHAR(64) DEFAULT NULL COMMENT '审核人姓名',
  `audit_time` DATETIME DEFAULT NULL COMMENT '审核时间',
  `visible` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可见(0:不可见 1:可见)',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_order_no` (`order_no`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_status` (`status`),
  KEY `idx_audit_status` (`audit_status`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='提现记录表';

-- -----------------------------------------------------------
-- 23. mkt_trading_flows - 交易流水表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_trading_flows`;
CREATE TABLE `mkt_trading_flows` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `type` TINYINT NOT NULL COMMENT '交易类型(1:充值 2:提现 3:佣金 4:赠送 5:消费)',
  `amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易金额',
  `before_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易前余额',
  `after_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易后余额',
  `order_no` VARCHAR(64) DEFAULT NULL COMMENT '关联订单号',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `visible` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可见(0:不可见 1:可见)',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_type` (`type`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='交易流水表';

-- -----------------------------------------------------------
-- 24. mkt_yuebao_accounts - 余额宝账户表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_yuebao_accounts`;
CREATE TABLE `mkt_yuebao_accounts` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '账户余额',
  `yesterday_profit` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '昨日收益',
  `total_profit` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '累计收益',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='余额宝账户表';

-- -----------------------------------------------------------
-- 25. mkt_yuebao_trading_flows - 余额宝交易流水表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_yuebao_trading_flows`;
CREATE TABLE `mkt_yuebao_trading_flows` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `type` TINYINT NOT NULL COMMENT '交易类型(1:转入 2:转出 3:收益)',
  `amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易金额',
  `before_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易前余额',
  `after_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '交易后余额',
  `profit` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '收益金额',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `visible` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可见(0:不可见 1:可见)',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_type` (`type`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='余额宝交易流水表';

-- -----------------------------------------------------------
-- 26. mkt_banners - 轮播图表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_banners`;
CREATE TABLE `mkt_banners` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '标题',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '图片地址',
  `link` VARCHAR(512) DEFAULT NULL COMMENT '跳转链接',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='轮播图表';

-- -----------------------------------------------------------
-- 27. mkt_bulletins - 公告栏表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_bulletins`;
CREATE TABLE `mkt_bulletins` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '标题',
  `content` TEXT DEFAULT NULL COMMENT '内容',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `publish_time` DATETIME DEFAULT NULL COMMENT '发布时间',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_publish_time` (`publish_time`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='公告栏表';

-- -----------------------------------------------------------
-- 28. mkt_customer_services - 客服配置表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_customer_services`;
CREATE TABLE `mkt_customer_services` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '标题',
  `content` TEXT DEFAULT NULL COMMENT '内容',
  `type` TINYINT NOT NULL DEFAULT 1 COMMENT '类型(1:在线客服 2:电话客服 3:邮件客服)',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_type` (`type`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='客服配置表';

-- -----------------------------------------------------------
-- 29. mkt_settings - 营销设置表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_settings`;
CREATE TABLE `mkt_settings` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `key` VARCHAR(128) NOT NULL COMMENT '设置键',
  `value` TEXT DEFAULT NULL COMMENT '设置值',
  `description` VARCHAR(256) DEFAULT NULL COMMENT '设置描述',
  `group_name` VARCHAR(64) DEFAULT NULL COMMENT '分组名称',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_key` (`key`),
  KEY `idx_group_name` (`group_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='营销设置表';

-- -----------------------------------------------------------
-- 30. mkt_statistics - 营销统计表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_statistics`;
CREATE TABLE `mkt_statistics` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `date` DATE NOT NULL COMMENT '统计日期',
  `recharge_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '充值金额',
  `withdrawal_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '提现金额',
  `commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金金额',
  `member_number` INT NOT NULL DEFAULT 0 COMMENT '新增会员数',
  `order_number` INT NOT NULL DEFAULT 0 COMMENT '订单数量',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='营销统计表';

-- -----------------------------------------------------------
-- 31. mkt_withdrawal_kinds - 提现方式表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_kinds`;
CREATE TABLE `mkt_withdrawal_kinds` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '方式名称',
  `code` VARCHAR(64) NOT NULL COMMENT '方式编码',
  `min_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '最低提现金额',
  `max_amount` DECIMAL(18,2) DEFAULT NULL COMMENT '最高提现金额',
  `fee_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT '手续费率(%)',
  `fee_fixed` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '固定手续费',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_code` (`code`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='提现方式表';

-- -----------------------------------------------------------
-- 32. mkt_wallets - 钱包表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_wallets`;
CREATE TABLE `mkt_wallets` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '可用余额',
  `frozen_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '冻结余额',
  `commission_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '佣金余额',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='钱包表';

-- -----------------------------------------------------------
-- 33. mkt_recruitments - 招募信息表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_recruitments`;
CREATE TABLE `mkt_recruitments` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '标题',
  `content` TEXT DEFAULT NULL COMMENT '内容',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '图片地址',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='招募信息表';

-- -----------------------------------------------------------
-- 34. mkt_spus - 商品SPU表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_spus`;
CREATE TABLE `mkt_spus` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(128) NOT NULL COMMENT '商品名称',
  `category_id` BIGINT DEFAULT NULL COMMENT '分类ID',
  `price` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT '商品价格',
  `commission_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT '佣金比例(%)',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '商品图片',
  `description` TEXT DEFAULT NULL COMMENT '商品描述',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_category_id` (`category_id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='商品SPU表';

-- -----------------------------------------------------------
-- 35. mkt_categories - 商品分类表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `mkt_categories`;
CREATE TABLE `mkt_categories` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(64) NOT NULL COMMENT '分类名称',
  `icon` VARCHAR(512) DEFAULT NULL COMMENT '分类图标',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='商品分类表';

-- ============================================================
-- 四、积分模块 (pts_*)
-- ============================================================

-- -----------------------------------------------------------
-- 36. pts_gifts - 积分礼品表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `pts_gifts`;
CREATE TABLE `pts_gifts` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(128) NOT NULL COMMENT '礼品名称',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '礼品图片',
  `points` INT NOT NULL DEFAULT 0 COMMENT '所需积分',
  `stock` INT NOT NULL DEFAULT 0 COMMENT '库存数量',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_enable` (`enable`),
  KEY `idx_sort` (`sort`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='积分礼品表';

-- -----------------------------------------------------------
-- 37. pts_gift_orders - 积分礼品订单表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `pts_gift_orders`;
CREATE TABLE `pts_gift_orders` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `order_no` VARCHAR(64) NOT NULL COMMENT '订单编号',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `gift_id` BIGINT NOT NULL COMMENT '礼品ID',
  `gift_name` VARCHAR(128) DEFAULT NULL COMMENT '礼品名称',
  `gift_image` VARCHAR(512) DEFAULT NULL COMMENT '礼品图片',
  `points` INT NOT NULL DEFAULT 0 COMMENT '兑换积分',
  `quantity` INT NOT NULL DEFAULT 1 COMMENT '兑换数量',
  `total_points` INT NOT NULL DEFAULT 0 COMMENT '总消耗积分',
  `status` TINYINT NOT NULL DEFAULT 0 COMMENT '订单状态(0:待发货 1:已发货 2:已完成 3:已取消)',
  `shipping_name` VARCHAR(64) DEFAULT NULL COMMENT '收货人姓名',
  `shipping_phone` VARCHAR(20) DEFAULT NULL COMMENT '收货人电话',
  `shipping_address` VARCHAR(256) DEFAULT NULL COMMENT '收货地址',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_order_no` (`order_no`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_gift_id` (`gift_id`),
  KEY `idx_status` (`status`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='积分礼品订单表';

-- -----------------------------------------------------------
-- 38. pts_accounts - 积分账户表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `pts_accounts`;
CREATE TABLE `pts_accounts` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `balance` INT NOT NULL DEFAULT 0 COMMENT '可用积分',
  `total_earned` INT NOT NULL DEFAULT 0 COMMENT '累计获得积分',
  `total_spent` INT NOT NULL DEFAULT 0 COMMENT '累计消费积分',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='积分账户表';

-- -----------------------------------------------------------
-- 39. pts_flows - 积分流水表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `pts_flows`;
CREATE TABLE `pts_flows` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `type` TINYINT NOT NULL COMMENT '流水类型(1:获得 2:消费 3:过期 4:管理员调整)',
  `points` INT NOT NULL DEFAULT 0 COMMENT '积分变动量',
  `before_balance` INT NOT NULL DEFAULT 0 COMMENT '变动前积分',
  `after_balance` INT NOT NULL DEFAULT 0 COMMENT '变动后积分',
  `order_no` VARCHAR(64) DEFAULT NULL COMMENT '关联订单号',
  `remark` VARCHAR(256) DEFAULT NULL COMMENT '备注',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_type` (`type`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='积分流水表';

-- ============================================================
-- 五、活动模块 (act_*)
-- ============================================================

-- -----------------------------------------------------------
-- 40. act_activities - 活动表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `act_activities`;
CREATE TABLE `act_activities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `title` VARCHAR(128) NOT NULL COMMENT '活动标题',
  `description` TEXT DEFAULT NULL COMMENT '活动描述',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '活动图片',
  `type` TINYINT NOT NULL DEFAULT 1 COMMENT '活动类型(1:抽奖 2:签到 3:任务 4:推广)',
  `start_time` DATETIME DEFAULT NULL COMMENT '开始时间',
  `end_time` DATETIME DEFAULT NULL COMMENT '结束时间',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_type` (`type`),
  KEY `idx_enable` (`enable`),
  KEY `idx_start_time` (`start_time`),
  KEY `idx_end_time` (`end_time`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='活动表';

-- -----------------------------------------------------------
-- 41. act_prizes - 活动奖品表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `act_prizes`;
CREATE TABLE `act_prizes` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `activity_id` BIGINT NOT NULL COMMENT '活动ID',
  `name` VARCHAR(128) NOT NULL COMMENT '奖品名称',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '奖品图片',
  `probability` DECIMAL(8,4) NOT NULL DEFAULT 0.0000 COMMENT '中奖概率(%)',
  `quantity` INT NOT NULL DEFAULT 0 COMMENT '奖品总量',
  `remaining` INT NOT NULL DEFAULT 0 COMMENT '剩余数量',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `enable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否启用(0:禁用 1:启用)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_activity_id` (`activity_id`),
  KEY `idx_enable` (`enable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='活动奖品表';

-- -----------------------------------------------------------
-- 42. act_accounts - 活动参与记录表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `act_accounts`;
CREATE TABLE `act_accounts` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `activity_id` BIGINT NOT NULL COMMENT '活动ID',
  `member_id` BIGINT NOT NULL COMMENT '会员ID',
  `username` VARCHAR(64) DEFAULT NULL COMMENT '用户名',
  `participate_time` DATETIME DEFAULT NULL COMMENT '参与时间',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  KEY `idx_activity_id` (`activity_id`),
  KEY `idx_member_id` (`member_id`),
  KEY `idx_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='活动参与记录表';

-- -----------------------------------------------------------
-- 43. act_partners - 活动合作方表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `act_partners`;
CREATE TABLE `act_partners` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `activity_id` BIGINT NOT NULL COMMENT '活动ID',
  `name` VARCHAR(128) NOT NULL COMMENT '合作方名称',
  `image` VARCHAR(512) DEFAULT NULL COMMENT '合作方图片',
  `link` VARCHAR(512) DEFAULT NULL COMMENT '合作方链接',
  `sort` INT NOT NULL DEFAULT 0 COMMENT '排序',
  `visible` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可见(0:不可见 1:可见)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_activity_id` (`activity_id`),
  KEY `idx_visible` (`visible`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='活动合作方表';

-- ============================================================
-- 六、网站模块 (web_*)
-- ============================================================

-- -----------------------------------------------------------
-- 44. web_customers - 网站客户表
-- -----------------------------------------------------------
DROP TABLE IF EXISTS `web_customers`;
CREATE TABLE `web_customers` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` VARCHAR(128) NOT NULL COMMENT '客户名称',
  `domain` VARCHAR(256) DEFAULT NULL COMMENT '域名',
  `logo` VARCHAR(512) DEFAULT NULL COMMENT 'Logo地址',
  `contact_name` VARCHAR(64) DEFAULT NULL COMMENT '联系人姓名',
  `contact_phone` VARCHAR(20) DEFAULT NULL COMMENT '联系人电话',
  `contact_email` VARCHAR(128) DEFAULT NULL COMMENT '联系人邮箱',
  `status` TINYINT NOT NULL DEFAULT 1 COMMENT '状态(0:禁用 1:正常 2:到期)',
  `create_id` BIGINT DEFAULT NULL COMMENT '创建人ID',
  `creator` VARCHAR(64) DEFAULT NULL COMMENT '创建人姓名',
  `create_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_id` BIGINT DEFAULT NULL COMMENT '修改人ID',
  `modifier` VARCHAR(64) DEFAULT NULL COMMENT '修改人姓名',
  `modify_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `idx_domain` (`domain`),
  KEY `idx_status` (`status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='网站客户表';

-- ============================================================
-- 七、初始数据
-- ============================================================

-- -----------------------------------------------------------
-- 初始组织
-- -----------------------------------------------------------
INSERT INTO `sys_orgs` (`id`, `parent_id`, `name`, `code`, `description`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, 0, '总公司', 'HQ', '总部组织', 1, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始职位
-- -----------------------------------------------------------
INSERT INTO `sys_positions` (`id`, `name`, `code`, `description`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '超级管理员', 'SUPER_ADMIN', '系统超级管理员', 1, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始角色
-- -----------------------------------------------------------
INSERT INTO `sys_roles` (`id`, `name`, `code`, `description`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '超级管理员', 'SUPER_ADMIN', '拥有系统所有权限', 1, 1, NULL, 'system', NOW()),
(2, '管理员', 'ADMIN', '普通管理员', 2, 1, NULL, 'system', NOW()),
(3, '操作员', 'OPERATOR', '日常操作人员', 3, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始权限分组
-- -----------------------------------------------------------
INSERT INTO `sys_groups` (`id`, `name`, `code`, `description`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '系统管理', 'SYS_MGMT', '系统管理相关权限', 1, 1, NULL, 'system', NOW()),
(2, '营销管理', 'MKT_MGMT', '营销管理相关权限', 2, 1, NULL, 'system', NOW()),
(3, '积分管理', 'PTS_MGMT', '积分管理相关权限', 3, 1, NULL, 'system', NOW()),
(4, '活动管理', 'ACT_MGMT', '活动管理相关权限', 4, 1, NULL, 'system', NOW()),
(5, '网站管理', 'WEB_MGMT', '网站管理相关权限', 5, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始权限策略
-- -----------------------------------------------------------
INSERT INTO `sys_strategies` (`id`, `name`, `code`, `description`, `content`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '全部权限', 'ALL_PERMISSION', '拥有所有模块的权限', '{"permission":"*"}', 1, 1, NULL, 'system', NOW()),
(2, '只读权限', 'READ_ONLY', '仅查看权限，无增删改操作', '{"permission":"read"}', 2, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始管理员用户
-- 密码: lS3%kC6.eP4~dW9 的MD5哈希
-- -----------------------------------------------------------
INSERT INTO `sys_users` (`id`, `account`, `password`, `name`, `phone`, `email`, `avatar`, `role_id`, `org_id`, `position_id`, `enable`, `locked`, `lock_count`, `create_id`, `creator`, `create_date`) VALUES
(1, 'admin', MD5('lS3%kC6.eP4~dW9'), '超级管理员', NULL, NULL, NULL, 1, 1, 1, 1, 0, 0, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 一级菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1,  0, '系统管理',   '/system',       'setting',       NULL,                          1, 1, NULL, 'system', NOW()),
(2,  0, '营销管理',   '/marketing',    'shopping',      NULL,                          2, 1, NULL, 'system', NOW()),
(3,  0, '积分管理',   '/points',       'star',          NULL,                          3, 1, NULL, 'system', NOW()),
(4,  0, '活动管理',   '/activity',     'gift',          NULL,                          4, 1, NULL, 'system', NOW()),
(5,  0, '网站管理',   '/website',      'global',        NULL,                          5, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 系统管理子菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(101, 1, '用户管理',   '/system/user',         'user',          'system/user/index',         1, 1, NULL, 'system', NOW()),
(102, 1, '角色管理',   '/system/role',         'team',          'system/role/index',         2, 1, NULL, 'system', NOW()),
(103, 1, '权限分组',   '/system/group',        'group',         'system/group/index',        3, 1, NULL, 'system', NOW()),
(104, 1, '职位管理',   '/system/position',     'idcard',        'system/position/index',     4, 1, NULL, 'system', NOW()),
(105, 1, '组织管理',   '/system/org',          'apartment',     'system/org/index',          5, 1, NULL, 'system', NOW()),
(106, 1, '权限策略',   '/system/strategy',     'safety',        'system/strategy/index',     6, 1, NULL, 'system', NOW()),
(107, 1, '菜单管理',   '/system/menu',         'menu',          'system/menu/index',         7, 1, NULL, 'system', NOW()),
(108, 1, '文件管理',   '/system/file',         'file',          'system/file/index',         8, 1, NULL, 'system', NOW()),
(109, 1, '操作日志',   '/system/operation-log','profile',       'system/operation-log/index',9, 1, NULL, 'system', NOW()),
(110, 1, '登录日志',   '/system/login-log',    'loginlog',      'system/login-log/index',   10, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 营销管理子菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(201, 2, '会员管理',     '/marketing/member',            'user',       'marketing/member/index',              1, 1, NULL, 'system', NOW()),
(202, 2, '会员等级',     '/marketing/level',             'crown',      'marketing/level/index',               2, 1, NULL, 'system', NOW()),
(203, 2, '充值管理',     '/marketing/recharge',          'pay-circle', 'marketing/recharge/index',            3, 1, NULL, 'system', NOW()),
(204, 2, '提现管理',     '/marketing/withdrawal',        'withdraw',   'marketing/withdrawal/index',          4, 1, NULL, 'system', NOW()),
(205, 2, '订单管理',     '/marketing/order',             'order',      'marketing/order/index',               5, 1, NULL, 'system', NOW()),
(206, 2, '交易流水',     '/marketing/trading-flow',      'transaction','marketing/trading-flow/index',        6, 1, NULL, 'system', NOW()),
(207, 2, '余额宝管理',   '/marketing/yuebao',            'fund',       'marketing/yuebao/index',              7, 1, NULL, 'system', NOW()),
(208, 2, '钱包管理',     '/marketing/wallet',            'wallet',     'marketing/wallet/index',              8, 1, NULL, 'system', NOW()),
(209, 2, '提现方式',     '/marketing/withdrawal-kind',   'bank',       'marketing/withdrawal-kind/index',      9, 1, NULL, 'system', NOW()),
(210, 2, '商品管理',     '/marketing/spu',               'shop',       'marketing/spu/index',                10, 1, NULL, 'system', NOW()),
(211, 2, '商品分类',     '/marketing/category',          'appstore',   'marketing/category/index',           11, 1, NULL, 'system', NOW()),
(212, 2, '轮播图管理',   '/marketing/banner',            'picture',    'marketing/banner/index',             12, 1, NULL, 'system', NOW()),
(213, 2, '公告管理',     '/marketing/notice',            'notification','marketing/notice/index',            13, 1, NULL, 'system', NOW()),
(214, 2, '公告栏管理',   '/marketing/bulletin',          'bell',       'marketing/bulletin/index',           14, 1, NULL, 'system', NOW()),
(215, 2, '客服配置',     '/marketing/customer-service',  'customer-service','marketing/customer-service/index',15,1,NULL,'system',NOW()),
(216, 2, '招募管理',     '/marketing/recruitment',       'solution',   'marketing/recruitment/index',        16, 1, NULL, 'system', NOW()),
(217, 2, '系统设置',     '/marketing/setting',           'tool',       'marketing/setting/index',            17, 1, NULL, 'system', NOW()),
(218, 2, '数据统计',     '/marketing/statistics',        'bar-chart',  'marketing/statistics/index',         18, 1, NULL, 'system', NOW()),
(219, 2, '会员统计',     '/marketing/member-statistics', 'pie-chart',  'marketing/member-statistics/index',  19, 1, NULL, 'system', NOW()),
(220, 2, '业绩统计',     '/marketing/performance',       'rise',       'marketing/performance/index',        20, 1, NULL, 'system', NOW()),
(221, 2, '重复IP管理',   '/marketing/duplicate-ip',      'link',       'marketing/duplicate-ip/index',       21, 1, NULL, 'system', NOW()),
(222, 2, '会员登录日志', '/marketing/member-login-log',  'loginlog',   'marketing/member-login-log/index',   22, 1, NULL, 'system', NOW()),
(223, 2, '提现账户审核', '/marketing/withdrawal-approve','audit',      'marketing/withdrawal-approve/index', 23, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 积分管理子菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(301, 3, '积分礼品',   '/points/gift',       'gift',      'points/gift/index',       1, 1, NULL, 'system', NOW()),
(302, 3, '礼品订单',   '/points/gift-order', 'shopping',  'points/gift-order/index',  2, 1, NULL, 'system', NOW()),
(303, 3, '积分账户',   '/points/account',    'account',   'points/account/index',     3, 1, NULL, 'system', NOW()),
(304, 3, '积分流水',   '/points/flow',       'swap',      'points/flow/index',        4, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 活动管理子菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(401, 4, '活动列表',   '/activity/list',     'calendar',  'activity/list/index',      1, 1, NULL, 'system', NOW()),
(402, 4, '奖品管理',   '/activity/prize',    'trophy',    'activity/prize/index',     2, 1, NULL, 'system', NOW()),
(403, 4, '参与记录',   '/activity/record',   'team',      'activity/record/index',    3, 1, NULL, 'system', NOW()),
(404, 4, '合作方管理', '/activity/partner',  'partner',   'activity/partner/index',   4, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始菜单 - 网站管理子菜单
-- -----------------------------------------------------------
INSERT INTO `sys_menus` (`id`, `parent_id`, `name`, `path`, `icon`, `component`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(501, 5, '客户管理',   '/website/customer',  'home',      'website/customer/index',   1, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 角色-菜单关联 (超级管理员拥有所有菜单)
-- -----------------------------------------------------------
INSERT INTO `sys_role_menus` (`role_id`, `menu_id`) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
(1, 101), (1, 102), (1, 103), (1, 104), (1, 105), (1, 106), (1, 107), (1, 108), (1, 109), (1, 110),
(1, 201), (1, 202), (1, 203), (1, 204), (1, 205), (1, 206), (1, 207), (1, 208), (1, 209), (1, 210),
(1, 211), (1, 212), (1, 213), (1, 214), (1, 215), (1, 216), (1, 217), (1, 218), (1, 219), (1, 220),
(1, 221), (1, 222), (1, 223),
(1, 301), (1, 302), (1, 303), (1, 304),
(1, 401), (1, 402), (1, 403), (1, 404),
(1, 501);

-- -----------------------------------------------------------
-- 角色-策略关联 (超级管理员拥有全部权限策略)
-- -----------------------------------------------------------
INSERT INTO `sys_role_strategies` (`role_id`, `strategy_id`) VALUES
(1, 1);

-- -----------------------------------------------------------
-- 角色-分组关联 (超级管理员拥有所有权限分组)
-- -----------------------------------------------------------
INSERT INTO `sys_role_groups` (`role_id`, `group_id`) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5);

-- -----------------------------------------------------------
-- 初始会员等级
-- -----------------------------------------------------------
INSERT INTO `mkt_levels` (`id`, `name`, `icon`, `min_amount`, `max_amount`, `discount`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '普通会员', NULL, 0.00,       9999.99,  100.00, 1, 1, NULL, 'system', NOW()),
(2, '银牌会员', NULL, 10000.00,   49999.99,  95.00, 2, 1, NULL, 'system', NOW()),
(3, '金牌会员', NULL, 50000.00,  199999.99,  90.00, 3, 1, NULL, 'system', NOW()),
(4, '钻石会员', NULL, 200000.00,     NULL,    85.00, 4, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始提现方式
-- -----------------------------------------------------------
INSERT INTO `mkt_withdrawal_kinds` (`id`, `name`, `code`, `min_amount`, `max_amount`, `fee_rate`, `fee_fixed`, `sort`, `enable`, `create_id`, `creator`, `create_date`) VALUES
(1, '银行卡转账', 'BANK_TRANSFER', 100.00, 500000.00, 1.00, 0.00, 1, 1, NULL, 'system', NOW()),
(2, '支付宝',     'ALIPAY',        50.00,  100000.00, 0.50, 0.00, 2, 1, NULL, 'system', NOW()),
(3, '微信',       'WECHAT',        50.00,  100000.00, 0.50, 0.00, 3, 1, NULL, 'system', NOW());

-- -----------------------------------------------------------
-- 初始营销设置
-- -----------------------------------------------------------
INSERT INTO `mkt_settings` (`id`, `key`, `value`, `description`, `group_name`, `sort`, `create_id`, `creator`, `create_date`) VALUES
(1,  'min_recharge_amount',       '10',     '最低充值金额',         '充值设置', 1, NULL, 'system', NOW()),
(2,  'max_recharge_amount',       '500000', '最高充值金额',         '充值设置', 2, NULL, 'system', NOW()),
(3,  'min_withdrawal_amount',     '100',    '最低提现金额',         '提现设置', 1, NULL, 'system', NOW()),
(4,  'max_withdrawal_amount',     '500000', '最高提现金额',         '提现设置', 2, NULL, 'system', NOW()),
(5,  'withdrawal_audit_enabled',  'true',   '提现是否需要审核',     '提现设置', 3, NULL, 'system', NOW()),
(6,  'commission_rate',           '5',      '默认佣金比例(%)',      '佣金设置', 1, NULL, 'system', NOW()),
(7,  'parent_commission_rate',    '1',      '上级佣金比例(%)',      '佣金设置', 2, NULL, 'system', NOW()),
(8,  'register_give_amount',      '0',      '注册赠送金额',         '注册设置', 1, NULL, 'system', NOW()),
(9,  'invite_reward_amount',      '0',      '邀请奖励金额',         '注册设置', 2, NULL, 'system', NOW()),
(10, 'yuebao_rate',               '0.01',   '余额宝日利率(%)',      '余额宝设置',1, NULL, 'system', NOW()),
(11, 'sign_points',               '10',     '每日签到积分',         '积分设置', 1, NULL, 'system', NOW()),
(12, 'order_points_rate',         '1',      '订单积分返还比例(%)',  '积分设置', 2, NULL, 'system', NOW());

-- ============================================================
-- 脚本结束
-- ============================================================
