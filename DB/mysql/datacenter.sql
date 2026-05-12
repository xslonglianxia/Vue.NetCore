-- ============================================================================
-- DataCenter Database Schema
-- Generated for DataCenter Application
-- Charset: utf8mb4 | Collation: utf8mb4_general_ci
-- ============================================================================

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;
SET SQL_MODE = 'NO_AUTO_VALUE_ON_ZERO';
SET TIME_ZONE = '+00:00';

-- ============================================================================
-- Database Creation
-- ============================================================================

CREATE DATABASE IF NOT EXISTS `datacenter` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `datacenter`;

-- ============================================================================
-- Section 1: System Management Tables (sys_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: sys_user - System Users
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `username`        VARCHAR(50)  NOT NULL                COMMENT 'Login username',
  `password`        VARCHAR(200) NOT NULL                COMMENT 'Login password (hashed)',
  `name`            VARCHAR(50)  DEFAULT NULL            COMMENT 'Display name',
  `avatar`          VARCHAR(500) DEFAULT NULL            COMMENT 'Avatar URL',
  `email`           VARCHAR(100) DEFAULT NULL            COMMENT 'Email address',
  `phone`           VARCHAR(20)  DEFAULT NULL            COMMENT 'Phone number',
  `gender`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Gender: 0=Unknown, 1=Male, 2=Female',
  `org_id`          BIGINT       DEFAULT NULL            COMMENT 'Organization ID',
  `enabled`         TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `builtin`         TINYINT      NOT NULL DEFAULT 0      COMMENT 'Built-in: 0=No, 1=Yes',
  `locked_status`   TINYINT      NOT NULL DEFAULT 0      COMMENT 'Locked: 0=Unlocked, 1=Locked',
  `online_status`   TINYINT      NOT NULL DEFAULT 0      COMMENT 'Online: 0=Offline, 1=Online',
  `last_login_ip`   VARCHAR(50)  DEFAULT NULL            COMMENT 'Last login IP address',
  `last_login_date` DATETIME     DEFAULT NULL            COMMENT 'Last login datetime',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  `version`         INT          NOT NULL DEFAULT 0      COMMENT 'Optimistic lock version',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_user_username` (`username`),
  KEY `idx_sys_user_org_id` (`org_id`),
  KEY `idx_sys_user_enabled` (`enabled`),
  KEY `idx_sys_user_phone` (`phone`),
  KEY `idx_sys_user_email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='System users';

-- ----------------------------------------------------------------------------
-- Table: sys_org - Organizations
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_org`;
CREATE TABLE `sys_org` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Organization name',
  `parent_id`   BIGINT       NOT NULL DEFAULT 0      COMMENT 'Parent organization ID (0=root)',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_org_parent_id` (`parent_id`),
  KEY `idx_sys_org_seq` (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Organizations';

-- ----------------------------------------------------------------------------
-- Table: sys_position - Positions
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_position`;
CREATE TABLE `sys_position` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Position name',
  `org_id`      BIGINT       DEFAULT NULL            COMMENT 'Organization ID',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_position_org_id` (`org_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Positions';

-- ----------------------------------------------------------------------------
-- Table: sys_role - Roles
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `id`            BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`          VARCHAR(100) NOT NULL                COMMENT 'Role name',
  `code`          VARCHAR(100) NOT NULL                COMMENT 'Role code',
  `kind`          TINYINT      DEFAULT NULL            COMMENT 'Role kind',
  `builtin`       TINYINT      NOT NULL DEFAULT 0      COMMENT 'Built-in: 0=No, 1=Yes',
  `resource_code` VARCHAR(200) DEFAULT NULL            COMMENT 'Resource code scope',
  `remark`        VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`     INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`       VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`   DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`     INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`   DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_role_code` (`code`),
  KEY `idx_sys_role_kind` (`kind`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Roles';

-- ----------------------------------------------------------------------------
-- Table: sys_group - Groups
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_group`;
CREATE TABLE `sys_group` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Group name',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Groups';

-- ----------------------------------------------------------------------------
-- Table: sys_strategy - Strategies
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_strategy`;
CREATE TABLE `sys_strategy` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Strategy name',
  `code`        VARCHAR(100) NOT NULL                COMMENT 'Strategy code',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_strategy_code` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Strategies';

-- ----------------------------------------------------------------------------
-- Table: sys_operation_log - Operation Logs
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_operation_log`;
CREATE TABLE `sys_operation_log` (
  `id`            BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `username`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Operator username',
  `resource_code` VARCHAR(200) DEFAULT NULL            COMMENT 'Resource code',
  `method`        VARCHAR(10)  DEFAULT NULL            COMMENT 'HTTP method',
  `url`           VARCHAR(500) DEFAULT NULL            COMMENT 'Request URL',
  `parameter`     TEXT         DEFAULT NULL            COMMENT 'Request parameters',
  `query`         TEXT         DEFAULT NULL            COMMENT 'Query string',
  `body`          TEXT         DEFAULT NULL            COMMENT 'Request body',
  `headers`       TEXT         DEFAULT NULL            COMMENT 'Request headers',
  `ip`            VARCHAR(50)  DEFAULT NULL            COMMENT 'Request IP',
  `address`       VARCHAR(200) DEFAULT NULL            COMMENT 'Request address',
  `status`        INT          DEFAULT NULL            COMMENT 'Response status code',
  `message`       TEXT         DEFAULT NULL            COMMENT 'Error message',
  `duration`      BIGINT       DEFAULT NULL            COMMENT 'Duration in milliseconds',
  `create_date`   DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_operation_log_username` (`username`),
  KEY `idx_sys_operation_log_resource_code` (`resource_code`),
  KEY `idx_sys_operation_log_create_date` (`create_date`),
  KEY `idx_sys_operation_log_status` (`status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='System operation logs';

-- ----------------------------------------------------------------------------
-- Table: sys_user_login_log - User Login Logs
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_login_log`;
CREATE TABLE `sys_user_login_log` (
  `id`          BIGINT      NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `username`    VARCHAR(50) DEFAULT NULL            COMMENT 'Login username',
  `param`       TEXT        DEFAULT NULL            COMMENT 'Login parameters',
  `headers`     TEXT        DEFAULT NULL            COMMENT 'Request headers',
  `ip`          VARCHAR(50) DEFAULT NULL            COMMENT 'Login IP',
  `address`     VARCHAR(200) DEFAULT NULL           COMMENT 'Login address',
  `success`     TINYINT     DEFAULT NULL            COMMENT 'Success: 0=Failed, 1=Success',
  `create_date` DATETIME    DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_user_login_log_username` (`username`),
  KEY `idx_sys_user_login_log_create_date` (`create_date`),
  KEY `idx_sys_user_login_log_success` (`success`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='System user login logs';

-- ----------------------------------------------------------------------------
-- Table: sys_file_reference - File References
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_file_reference`;
CREATE TABLE `sys_file_reference` (
  `id`            BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`          VARCHAR(200) DEFAULT NULL            COMMENT 'Reference name',
  `file_id`       VARCHAR(200) DEFAULT NULL            COMMENT 'File ID',
  `related_kind`  VARCHAR(50)  DEFAULT NULL            COMMENT 'Related entity kind',
  `related_id`    VARCHAR(100) DEFAULT NULL            COMMENT 'Related entity ID',
  `presigned_url` VARCHAR(1000) DEFAULT NULL           COMMENT 'Presigned URL',
  `remark`        VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`     INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`       VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`   DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`     INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`   DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_file_reference_file_id` (`file_id`),
  KEY `idx_sys_file_reference_related` (`related_kind`, `related_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='File references';

-- ----------------------------------------------------------------------------
-- Table: sys_file - Files
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_file`;
CREATE TABLE `sys_file` (
  `id`           BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`         VARCHAR(200) DEFAULT NULL            COMMENT 'File name',
  `size`         BIGINT       DEFAULT NULL            COMMENT 'File size in bytes',
  `content_type` VARCHAR(100) DEFAULT NULL            COMMENT 'MIME content type',
  `path`         VARCHAR(500) DEFAULT NULL            COMMENT 'Storage path',
  `create_id`    INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`  DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`    INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`  DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_sys_file_content_type` (`content_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Files';

-- ============================================================================
-- Section 2: Application Management Tables (app_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: app_app - Applications
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `app_app`;
CREATE TABLE `app_app` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Application name',
  `code`        VARCHAR(100) NOT NULL                COMMENT 'Application code',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_app_app_code` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Applications';

-- ----------------------------------------------------------------------------
-- Table: app_resource - Resources
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `app_resource`;
CREATE TABLE `app_resource` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `app_id`      BIGINT       NOT NULL                COMMENT 'Application ID',
  `parent_id`   BIGINT       NOT NULL DEFAULT 0      COMMENT 'Parent resource ID (0=root)',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Resource name',
  `code`        VARCHAR(200) NOT NULL                COMMENT 'Resource code',
  `kind`        TINYINT      DEFAULT NULL            COMMENT 'Resource kind',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_app_resource_code` (`code`),
  KEY `idx_app_resource_app_id` (`app_id`),
  KEY `idx_app_resource_parent_id` (`parent_id`),
  KEY `idx_app_resource_kind` (`kind`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Application resources';

-- ============================================================================
-- Section 3: Marketing Tables (mkt_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: mkt_member - Marketing Members
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member`;
CREATE TABLE `mkt_member` (
  `id`                                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username`                         VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`                            VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `email`                                   VARCHAR(100) DEFAULT NULL            COMMENT 'Email address',
  `password`                                VARCHAR(200) NOT NULL                COMMENT 'Password (hashed)',
  `gender`                                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Gender: 0=Unknown, 1=Male, 2=Female',
  `birthday`                                DATE         DEFAULT NULL            COMMENT 'Birthday',
  `level_id`                                BIGINT       DEFAULT NULL            COMMENT 'Member level ID',
  `invite_code`                             VARCHAR(50)  DEFAULT NULL            COMMENT 'Invite code',
  `parent_username`                         VARCHAR(50)  DEFAULT NULL            COMMENT 'Parent (inviter) username',
  `parent_invite_code`                      VARCHAR(50)  DEFAULT NULL            COMMENT 'Parent invite code',
  `balance`                                 DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Total balance',
  `available_balance`                       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Available balance',
  `freeze_balance`                          DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Frozen balance',
  `reputation_scope`                        DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Reputation scope',
  `enabled`                                 TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `locked_status`                           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Locked: 0=Unlocked, 1=Locked',
  `virtual_status`                          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Virtual: 0=Real, 1=Virtual',
  `online_status`                           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Online: 0=Offline, 1=Online',
  `last_login_date`                         DATETIME     DEFAULT NULL            COMMENT 'Last login datetime',
  `last_login_ip`                           VARCHAR(50)  DEFAULT NULL            COMMENT 'Last login IP',
  `allow_invitations`                       TINYINT      NOT NULL DEFAULT 1      COMMENT 'Allow invitations: 0=No, 1=Yes',
  `order_seq`                               INT          NOT NULL DEFAULT 0      COMMENT 'Order sequence count',
  `sign_seq`                                INT          NOT NULL DEFAULT 0      COMMENT 'Sign-in sequence count',
  `sign_number`                             INT          NOT NULL DEFAULT 0      COMMENT 'Total sign-in count',
  `reset_number`                            INT          NOT NULL DEFAULT 0      COMMENT 'Reset count',
  `task_complete_number`                    INT          NOT NULL DEFAULT 0      COMMENT 'Task complete count',
  `children_number`                         INT          NOT NULL DEFAULT 0      COMMENT 'Children (invitees) count',
  `product_match_enabled`                   TINYINT      NOT NULL DEFAULT 0      COMMENT 'Product match enabled: 0=No, 1=Yes',
  `account_enabled`                         TINYINT      NOT NULL DEFAULT 1      COMMENT 'Account enabled: 0=No, 1=Yes',
  `account_trading_status`                  TINYINT      NOT NULL DEFAULT 1      COMMENT 'Account trading status: 0=Stopped, 1=Active',
  `account_withdrawal_status`               TINYINT      NOT NULL DEFAULT 1      COMMENT 'Account withdrawal status: 0=Stopped, 1=Active',
  `account_withdrawal_disabled`             TINYINT      NOT NULL DEFAULT 0      COMMENT 'Account withdrawal disabled: 0=No, 1=Yes',
  `account_assistance_withdrawal_status`    TINYINT      NOT NULL DEFAULT 1      COMMENT 'Assistance withdrawal status: 0=Stopped, 1=Active',
  `withdrawal_amount_max`                   DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Max withdrawal amount',
  `withdrawal_disabled_remark`              VARCHAR(500) DEFAULT NULL            COMMENT 'Withdrawal disabled remark',
  `withdrawal_notice_disabled`              TINYINT      NOT NULL DEFAULT 0      COMMENT 'Withdrawal notice disabled: 0=No, 1=Yes',
  `disabled_withdrawal_failed_count`        INT          NOT NULL DEFAULT 0      COMMENT 'Withdrawal failed count',
  `disabled_withdrawal_continuous_failed_count` INT     NOT NULL DEFAULT 0      COMMENT 'Withdrawal continuous failed count',
  `work_disabled`                           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Work disabled: 0=No, 1=Yes',
  `work_limit`                              INT          NOT NULL DEFAULT 0      COMMENT 'Work limit',
  `formal_contract_enabled`                 TINYINT      NOT NULL DEFAULT 0      COMMENT 'Formal contract enabled: 0=No, 1=Yes',
  `formal_contract_status`                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Formal contract status',
  `user_contract_enabled`                   TINYINT      NOT NULL DEFAULT 0      COMMENT 'User contract enabled: 0=No, 1=Yes',
  `user_contract_status`                    TINYINT      NOT NULL DEFAULT 0      COMMENT 'User contract status',
  `enable_web3_approve`                     TINYINT      NOT NULL DEFAULT 0      COMMENT 'Web3 approve enabled: 0=No, 1=Yes',
  `wallet_address`                          VARCHAR(200) DEFAULT NULL            COMMENT 'Wallet address',
  `verified`                                TINYINT      NOT NULL DEFAULT 0      COMMENT 'Verified: 0=No, 1=Yes',
  `today_commission_amount`                 DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Today commission amount',
  `today_withdrawal_number`                 INT          NOT NULL DEFAULT 0      COMMENT 'Today withdrawal count',
  `today_reset_number`                      INT          NOT NULL DEFAULT 0      COMMENT 'Today reset count',
  `recharge_amount`                         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Total recharge amount',
  `withdrawal_amount`                       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Total withdrawal amount',
  `create_id`                               INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                                 VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`                             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`                               INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                                VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`                             DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  `version`                                 INT          NOT NULL DEFAULT 0      COMMENT 'Optimistic lock version',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_member_username` (`member_username`),
  KEY `idx_mkt_member_phone` (`member_phone`),
  KEY `idx_mkt_member_email` (`email`),
  KEY `idx_mkt_member_level_id` (`level_id`),
  KEY `idx_mkt_member_invite_code` (`invite_code`),
  KEY `idx_mkt_member_parent_username` (`parent_username`),
  KEY `idx_mkt_member_enabled` (`enabled`),
  KEY `idx_mkt_member_locked_status` (`locked_status`),
  KEY `idx_mkt_member_create_date` (`create_date`),
  KEY `idx_mkt_member_wallet_address` (`wallet_address`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Marketing members';

-- ----------------------------------------------------------------------------
-- Table: mkt_level - Member Levels
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_level`;
CREATE TABLE `mkt_level` (
  `id`                            BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`                          VARCHAR(50)  NOT NULL                COMMENT 'Level name',
  `icon`                          VARCHAR(500) DEFAULT NULL            COMMENT 'Level icon URL',
  `seq`                           INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `price`                         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Level price',
  `balance_min`                   DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Minimum balance for level',
  `order_limit`                   INT          NOT NULL DEFAULT 0      COMMENT 'Daily order limit',
  `complete_limit`                INT          NOT NULL DEFAULT 0      COMMENT 'Daily complete limit',
  `withdrawal_limit`              INT          NOT NULL DEFAULT 0      COMMENT 'Daily withdrawal limit',
  `withdrawal_order_seq_limit`    INT          NOT NULL DEFAULT 0      COMMENT 'Withdrawal order seq limit',
  `withdrawal_amount_min`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Min withdrawal amount',
  `withdrawal_amount_max`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Max withdrawal amount',
  `withdrawal_fee_rate`           DECIMAL(5,4) NOT NULL DEFAULT 0.0000 COMMENT 'Withdrawal fee rate',
  `min_commission_percentage`     DECIMAL(5,2) NOT NULL DEFAULT 0.00  COMMENT 'Min commission percentage',
  `max_commission_percentage`     DECIMAL(5,2) NOT NULL DEFAULT 0.00  COMMENT 'Max commission percentage',
  `min_even_commission_percentage` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT 'Min even commission percentage',
  `max_even_commission_percentage` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT 'Max even commission percentage',
  `invite_quantity_min`           INT          NOT NULL DEFAULT 0      COMMENT 'Min invite quantity',
  `sign_in_bonus`                 DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Sign-in bonus amount',
  `task_groups_bonus`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Task groups bonus amount',
  `number_of_completed_task_groups` INT        NOT NULL DEFAULT 0      COMMENT 'Number of completed task groups',
  `product_match_enabled`         TINYINT      NOT NULL DEFAULT 0      COMMENT 'Product match enabled: 0=No, 1=Yes',
  `remark`                        VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`                     INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                       VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`                   DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`                     INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                      VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`                   DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_level_seq` (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Member levels';

-- ----------------------------------------------------------------------------
-- Table: mkt_category - SPU Categories
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_category`;
CREATE TABLE `mkt_category` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `title`       VARCHAR(100) NOT NULL                COMMENT 'Category title',
  `subtitle`    VARCHAR(200) DEFAULT NULL            COMMENT 'Category subtitle',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Category picture URL',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_category_seq` (`seq`),
  KEY `idx_mkt_category_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='SPU categories';

-- ----------------------------------------------------------------------------
-- Table: mkt_spu - Products (SPU)
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_spu`;
CREATE TABLE `mkt_spu` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `category_id` BIGINT       NOT NULL                COMMENT 'Category ID',
  `title`       VARCHAR(200) NOT NULL                COMMENT 'Product title',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Product name',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Product picture URL',
  `price`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Product price',
  `value`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Product value',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_spu_category_id` (`category_id`),
  KEY `idx_mkt_spu_enabled` (`enabled`),
  KEY `idx_mkt_spu_seq` (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Products (SPU)';

-- ----------------------------------------------------------------------------
-- Table: mkt_order_detail - Order Details
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_order_detail`;
CREATE TABLE `mkt_order_detail` (
  `id`                          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `detail_no`                   VARCHAR(50)  NOT NULL                COMMENT 'Detail number',
  `member_username`             VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `kind`                        TINYINT      DEFAULT NULL            COMMENT 'Order kind',
  `spu_id`                      BIGINT       DEFAULT NULL            COMMENT 'SPU ID',
  `spu_title`                   VARCHAR(200) DEFAULT NULL            COMMENT 'SPU title',
  `spu_pic`                     VARCHAR(500) DEFAULT NULL            COMMENT 'SPU picture URL',
  `seq`                         INT          NOT NULL DEFAULT 0      COMMENT 'Sequence',
  `amount`                      DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Order amount',
  `commission_percentage`       DECIMAL(5,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission percentage',
  `commission`                  DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission amount',
  `parent_commission_percentage` DECIMAL(5,2) NOT NULL DEFAULT 0.00 COMMENT 'Parent commission percentage',
  `parent_commission`           DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Parent commission amount',
  `additional_commission`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Additional commission',
  `status`                      TINYINT      NOT NULL DEFAULT 0      COMMENT 'Status: 0=Pending, 1=Completed, 2=Expired',
  `expired_date`                DATETIME     DEFAULT NULL            COMMENT 'Expiration datetime',
  `remark`                      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`                   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`                 DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`                   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`                 DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  `version`                     INT          NOT NULL DEFAULT 0      COMMENT 'Optimistic lock version',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_order_detail_no` (`detail_no`),
  KEY `idx_mkt_order_detail_member_username` (`member_username`),
  KEY `idx_mkt_order_detail_spu_id` (`spu_id`),
  KEY `idx_mkt_order_detail_status` (`status`),
  KEY `idx_mkt_order_detail_create_date` (`create_date`),
  KEY `idx_mkt_order_detail_expired_date` (`expired_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Order details';

-- ----------------------------------------------------------------------------
-- Table: mkt_order_detail_comment - Order Detail Comments
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_order_detail_comment`;
CREATE TABLE `mkt_order_detail_comment` (
  `id`               BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `order_detail_id`  BIGINT       NOT NULL                COMMENT 'Order detail ID',
  `comment`          VARCHAR(1000) DEFAULT NULL            COMMENT 'Comment content',
  `score`            INT          DEFAULT NULL            COMMENT 'Score rating',
  `create_id`        INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`          VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`      DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`        INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`      DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_order_detail_comment_order_detail_id` (`order_detail_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Order detail comments';

-- ----------------------------------------------------------------------------
-- Table: mkt_recharge_record - Recharge Records
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_recharge_record`;
CREATE TABLE `mkt_recharge_record` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `order_no`                VARCHAR(50)  NOT NULL                COMMENT 'Order number',
  `member_username`         VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`            VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `parent_member_username`  VARCHAR(50)  DEFAULT NULL            COMMENT 'Parent member username',
  `kind_id`                 BIGINT       DEFAULT NULL            COMMENT 'Withdrawal kind ID',
  `trading_kind`            TINYINT      DEFAULT NULL            COMMENT 'Trading kind',
  `wallet_address`          VARCHAR(200) DEFAULT NULL            COMMENT 'Wallet address',
  `amount`                  DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Recharge amount',
  `real_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Real amount received',
  `amount_after_conversion` DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Amount after conversion',
  `give_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Bonus/gift amount',
  `status`                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Status: 0=Pending, 1=Success, 2=Failed',
  `virtual_status`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Virtual status: 0=Real, 1=Virtual',
  `hidden`                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hidden: 0=No, 1=Yes',
  `remark`                  VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`               INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                 VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`               INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`             DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_recharge_record_order_no` (`order_no`),
  KEY `idx_mkt_recharge_record_member_username` (`member_username`),
  KEY `idx_mkt_recharge_record_status` (`status`),
  KEY `idx_mkt_recharge_record_create_date` (`create_date`),
  KEY `idx_mkt_recharge_record_kind_id` (`kind_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Recharge records';

-- ----------------------------------------------------------------------------
-- Table: mkt_withdrawal_record - Withdrawal Records
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_record`;
CREATE TABLE `mkt_withdrawal_record` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `order_no`                VARCHAR(50)  NOT NULL                COMMENT 'Order number',
  `member_username`         VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`            VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `parent_member_username`  VARCHAR(50)  DEFAULT NULL            COMMENT 'Parent member username',
  `kind_id`                 BIGINT       DEFAULT NULL            COMMENT 'Withdrawal kind ID',
  `trading_kind`            TINYINT      DEFAULT NULL            COMMENT 'Trading kind',
  `wallet_address`          VARCHAR(200) DEFAULT NULL            COMMENT 'Wallet address',
  `amount`                  DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal amount',
  `fee`                     DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal fee',
  `amount_after_conversion` DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Amount after conversion',
  `attachment`              VARCHAR(500) DEFAULT NULL            COMMENT 'Attachment URL',
  `status`                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Status: 0=Pending, 1=Success, 2=Failed',
  `virtual_status`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Virtual status: 0=Real, 1=Virtual',
  `hidden`                  TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hidden: 0=No, 1=Yes',
  `remark`                  VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`               INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                 VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`               INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`             DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_withdrawal_record_order_no` (`order_no`),
  KEY `idx_mkt_withdrawal_record_member_username` (`member_username`),
  KEY `idx_mkt_withdrawal_record_status` (`status`),
  KEY `idx_mkt_withdrawal_record_create_date` (`create_date`),
  KEY `idx_mkt_withdrawal_record_kind_id` (`kind_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Withdrawal records';

-- ----------------------------------------------------------------------------
-- Table: mkt_trading_flow - Trading Flows
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_trading_flow`;
CREATE TABLE `mkt_trading_flow` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `flow_no`         VARCHAR(50)  NOT NULL                COMMENT 'Flow number',
  `trading_no`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Trading number',
  `trading_kind`    TINYINT      DEFAULT NULL            COMMENT 'Trading kind',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `amount`          DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Trading amount',
  `before_balance`  DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Balance before trading',
  `after_balance`   DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Balance after trading',
  `hidden`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hidden: 0=No, 1=Yes',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_trading_flow_no` (`flow_no`),
  KEY `idx_mkt_trading_flow_member_username` (`member_username`),
  KEY `idx_mkt_trading_flow_trading_no` (`trading_no`),
  KEY `idx_mkt_trading_flow_trading_kind` (`trading_kind`),
  KEY `idx_mkt_trading_flow_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Trading flows';

-- ----------------------------------------------------------------------------
-- Table: mkt_yuebao_account - Yuebao Accounts
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_yuebao_account`;
CREATE TABLE `mkt_yuebao_account` (
  `id`               BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username`  VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`     VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `balance`          DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Total balance',
  `available_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Available balance',
  `freeze_balance`   DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Frozen balance',
  `hike`             DECIMAL(18,4) NOT NULL DEFAULT 0.0000 COMMENT 'Interest rate hike',
  `hike_enabled`     TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hike enabled: 0=No, 1=Yes',
  `enabled`          TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`           VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`        INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`          VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`      DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`        INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`      DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_yuebao_account_member_username` (`member_username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Yuebao accounts';

-- ----------------------------------------------------------------------------
-- Table: mkt_yuebao_trading_flow - Yuebao Trading Flows
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_yuebao_trading_flow`;
CREATE TABLE `mkt_yuebao_trading_flow` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `flow_no`         VARCHAR(50)  NOT NULL                COMMENT 'Flow number',
  `trading_no`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Trading number',
  `trading_kind`    TINYINT      DEFAULT NULL            COMMENT 'Trading kind',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `amount`          DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Trading amount',
  `before_balance`  DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Balance before trading',
  `after_balance`   DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Balance after trading',
  `hidden`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hidden: 0=No, 1=Yes',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_yuebao_trading_flow_no` (`flow_no`),
  KEY `idx_mkt_yuebao_trading_flow_member_username` (`member_username`),
  KEY `idx_mkt_yuebao_trading_flow_trading_no` (`trading_no`),
  KEY `idx_mkt_yuebao_trading_flow_trading_kind` (`trading_kind`),
  KEY `idx_mkt_yuebao_trading_flow_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Yuebao trading flows';

-- ----------------------------------------------------------------------------
-- Table: mkt_banner - Banners
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_banner`;
CREATE TABLE `mkt_banner` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Banner name',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Banner picture URL',
  `link`        VARCHAR(500) DEFAULT NULL            COMMENT 'Banner link URL',
  `kind`        TINYINT      DEFAULT NULL            COMMENT 'Banner kind',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_banner_kind` (`kind`),
  KEY `idx_mkt_banner_seq` (`seq`),
  KEY `idx_mkt_banner_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Banners';

-- ----------------------------------------------------------------------------
-- Table: mkt_bulletin - Bulletins
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_bulletin`;
CREATE TABLE `mkt_bulletin` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `title`       VARCHAR(200) NOT NULL                COMMENT 'Bulletin title',
  `content`     TEXT         DEFAULT NULL            COMMENT 'Bulletin content',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_bulletin_seq` (`seq`),
  KEY `idx_mkt_bulletin_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Bulletins';

-- ----------------------------------------------------------------------------
-- Table: mkt_customer_service - Customer Services
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_customer_service`;
CREATE TABLE `mkt_customer_service` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Service name',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Service picture URL',
  `link`        VARCHAR(500) DEFAULT NULL            COMMENT 'Service link URL',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_customer_service_seq` (`seq`),
  KEY `idx_mkt_customer_service_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Customer services';

-- ----------------------------------------------------------------------------
-- Table: mkt_setting - Settings
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_setting`;
CREATE TABLE `mkt_setting` (
  `id`                BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `code`              VARCHAR(100) NOT NULL                COMMENT 'Setting code',
  `kind`              TINYINT      DEFAULT NULL            COMMENT 'Setting kind',
  `value`             TEXT         DEFAULT NULL            COMMENT 'Setting value',
  `level_seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Level sequence',
  `amount`            DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Amount',
  `bonus`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Bonus amount',
  `seq`               INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `url`               VARCHAR(500) DEFAULT NULL            COMMENT 'URL',
  `message`           VARCHAR(500) DEFAULT NULL            COMMENT 'Message',
  `interval`          INT          NOT NULL DEFAULT 0      COMMENT 'Interval',
  `limit`             INT          NOT NULL DEFAULT 0      COMMENT 'Limit',
  `daily_interest_rate` DECIMAL(10,6) NOT NULL DEFAULT 0.000000 COMMENT 'Daily interest rate',
  `order_number`      INT          NOT NULL DEFAULT 0      COMMENT 'Order number',
  `remark`            VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`         INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`           VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`       DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`         INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`          VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`       DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_setting_code` (`code`),
  KEY `idx_mkt_setting_kind` (`kind`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Marketing settings';

-- ----------------------------------------------------------------------------
-- Table: mkt_withdrawal_kind - Withdrawal Kinds
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_kind`;
CREATE TABLE `mkt_withdrawal_kind` (
  `id`                     BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`                   VARCHAR(100) NOT NULL                COMMENT 'Kind name',
  `kind`                   TINYINT      DEFAULT NULL            COMMENT 'Kind type',
  `icon`                   VARCHAR(500) DEFAULT NULL            COMMENT 'Kind icon URL',
  `exchange_rate`          DECIMAL(10,6) NOT NULL DEFAULT 0.000000 COMMENT 'Exchange rate',
  `fee_private_key_config` VARCHAR(500) DEFAULT NULL            COMMENT 'Fee private key config',
  `param`                  TEXT         DEFAULT NULL            COMMENT 'Parameters (JSON)',
  `seq`                    INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `remark`                 VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`              INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`            DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`              INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`               VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`            DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_withdrawal_kind_kind` (`kind`),
  KEY `idx_mkt_withdrawal_kind_seq` (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Withdrawal kinds';

-- ----------------------------------------------------------------------------
-- Table: mkt_wallet - Wallets
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_wallet`;
CREATE TABLE `mkt_wallet` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Wallet name',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Wallet picture URL',
  `link`        VARCHAR(500) DEFAULT NULL            COMMENT 'Wallet link URL',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_wallet_seq` (`seq`),
  KEY `idx_mkt_wallet_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Wallets';

-- ----------------------------------------------------------------------------
-- Table: mkt_recruitment - Recruitments
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_recruitment`;
CREATE TABLE `mkt_recruitment` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `name`        VARCHAR(100) NOT NULL                COMMENT 'Recruitment name',
  `icon`        VARCHAR(500) DEFAULT NULL            COMMENT 'Recruitment icon URL',
  `salary`      VARCHAR(100) DEFAULT NULL            COMMENT 'Salary description',
  `number`      INT          NOT NULL DEFAULT 0      COMMENT 'Number of positions',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_recruitment_seq` (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Recruitments';

-- ----------------------------------------------------------------------------
-- Table: mkt_notice - Notices
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_notice`;
CREATE TABLE `mkt_notice` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `title`       VARCHAR(200) NOT NULL                COMMENT 'Notice title',
  `content`     TEXT         DEFAULT NULL            COMMENT 'Notice content',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `mid_list`    TEXT         DEFAULT NULL            COMMENT 'Member ID list (JSON)',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_notice_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Notices';

-- ----------------------------------------------------------------------------
-- Table: mkt_member_login_log - Member Login Logs
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_login_log`;
CREATE TABLE `mkt_member_login_log` (
  `id`              BIGINT      NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username` VARCHAR(50) DEFAULT NULL            COMMENT 'Member username',
  `param`           TEXT        DEFAULT NULL            COMMENT 'Login parameters',
  `headers`         TEXT        DEFAULT NULL            COMMENT 'Request headers',
  `ip`              VARCHAR(50) DEFAULT NULL            COMMENT 'Login IP',
  `address`         VARCHAR(200) DEFAULT NULL           COMMENT 'Login address',
  `success`         TINYINT     DEFAULT NULL            COMMENT 'Success: 0=Failed, 1=Success',
  `create_date`     DATETIME    DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_member_login_log_member_username` (`member_username`),
  KEY `idx_mkt_member_login_log_create_date` (`create_date`),
  KEY `idx_mkt_member_login_log_success` (`success`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Member login logs';

-- ----------------------------------------------------------------------------
-- Table: mkt_withdrawal_account_approve_log - Withdrawal Account Approve Logs
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_withdrawal_account_approve_log`;
CREATE TABLE `mkt_withdrawal_account_approve_log` (
  `id`                                  BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username`                     VARCHAR(50)  DEFAULT NULL            COMMENT 'Member username',
  `member_phone`                        VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `parent_member_username`              VARCHAR(50)  DEFAULT NULL            COMMENT 'Parent member username',
  `wallet_address`                      VARCHAR(200) DEFAULT NULL            COMMENT 'Wallet address',
  `kind_name`                           VARCHAR(100) DEFAULT NULL            COMMENT 'Withdrawal kind name',
  `approve_amount`                      DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Approve amount',
  `account_balance`                     DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Account balance',
  `verified`                            TINYINT      NOT NULL DEFAULT 0      COMMENT 'Verified: 0=No, 1=Yes',
  `verified_wallet_address`             VARCHAR(200) DEFAULT NULL            COMMENT 'Verified wallet address',
  `verified_currency_contract_address`  VARCHAR(200) DEFAULT NULL            COMMENT 'Verified currency contract address',
  `verified_hash`                       VARCHAR(200) DEFAULT NULL            COMMENT 'Verified hash',
  `auto_sync`                           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Auto sync: 0=No, 1=Yes',
  `remark`                              VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`                           INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`                             VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`                         DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`                           INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`                            VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`                         DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_mkt_wal_approve_member_username` (`member_username`),
  KEY `idx_mkt_wal_approve_wallet_address` (`wallet_address`),
  KEY `idx_mkt_wal_approve_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Withdrawal account approve logs';

-- ----------------------------------------------------------------------------
-- Table: mkt_member_date_statistic - Member Date Statistics
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_date_statistic`;
CREATE TABLE `mkt_member_date_statistic` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `date`                    DATE         NOT NULL                COMMENT 'Statistic date',
  `member_username`         VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `enabled`                 TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `locked_status`           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Locked: 0=Unlocked, 1=Locked',
  `virtual_status`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Virtual: 0=Real, 1=Virtual',
  `allow_invitations`       TINYINT      NOT NULL DEFAULT 1      COMMENT 'Allow invitations: 0=No, 1=Yes',
  `recharge_amount`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Recharge amount',
  `recharge_number`         INT          NOT NULL DEFAULT 0      COMMENT 'Recharge count',
  `withdrawal_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal amount',
  `withdrawal_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Withdrawal count',
  `commission_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission amount',
  `commission_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Commission count',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Parent commission amount',
  `parent_commission_number` INT         NOT NULL DEFAULT 0      COMMENT 'Parent commission count',
  `give_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Gift amount',
  `give_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Gift count',
  `sign_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Sign-in amount',
  `sign_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Sign-in count',
  `order_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Order count',
  `task_complete_number`    INT          NOT NULL DEFAULT 0      COMMENT 'Task complete count',
  `reset_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Reset count',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_member_date_statistic_date_username` (`date`, `member_username`),
  KEY `idx_mkt_member_date_statistic_date` (`date`),
  KEY `idx_mkt_member_date_statistic_member_username` (`member_username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Member date statistics';

-- ----------------------------------------------------------------------------
-- Table: mkt_member_statistic - Member Statistics
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_member_statistic`;
CREATE TABLE `mkt_member_statistic` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username`         VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `enabled`                 TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `locked_status`           TINYINT      NOT NULL DEFAULT 0      COMMENT 'Locked: 0=Unlocked, 1=Locked',
  `virtual_status`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Virtual: 0=Real, 1=Virtual',
  `allow_invitations`       TINYINT      NOT NULL DEFAULT 1      COMMENT 'Allow invitations: 0=No, 1=Yes',
  `order_seq`               INT          NOT NULL DEFAULT 0      COMMENT 'Order sequence count',
  `sign_seq`                INT          NOT NULL DEFAULT 0      COMMENT 'Sign-in sequence count',
  `pop_up_number`           INT          NOT NULL DEFAULT 0      COMMENT 'Pop-up count',
  `recharge_amount`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Recharge amount',
  `recharge_number`         INT          NOT NULL DEFAULT 0      COMMENT 'Recharge count',
  `withdrawal_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal amount',
  `withdrawal_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Withdrawal count',
  `commission_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission amount',
  `commission_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Commission count',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Parent commission amount',
  `parent_commission_number` INT         NOT NULL DEFAULT 0      COMMENT 'Parent commission count',
  `give_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Gift amount',
  `give_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Gift count',
  `sign_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Sign-in amount',
  `sign_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Sign-in count',
  `order_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Order count',
  `task_complete_number`    INT          NOT NULL DEFAULT 0      COMMENT 'Task complete count',
  `reset_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Reset count',
  `last_sign_date`          DATETIME     DEFAULT NULL            COMMENT 'Last sign-in datetime',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_member_statistic_member_username` (`member_username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Member statistics';

-- ----------------------------------------------------------------------------
-- Table: mkt_performance_statistic - Performance Statistics
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_performance_statistic`;
CREATE TABLE `mkt_performance_statistic` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `date`                    DATE         NOT NULL                COMMENT 'Statistic date',
  `permission_username`     VARCHAR(50)  NOT NULL                COMMENT 'Permission username',
  `member_number`           INT          NOT NULL DEFAULT 0      COMMENT 'Member count',
  `recharge_amount`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Recharge amount',
  `withdrawal_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal amount',
  `commission_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission amount',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Parent commission amount',
  `give_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Gift amount',
  `sign_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Sign-in amount',
  `order_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Order count',
  `bet_number`              INT          NOT NULL DEFAULT 0      COMMENT 'Bet count',
  `task_complete_number`    INT          NOT NULL DEFAULT 0      COMMENT 'Task complete count',
  `reset_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Reset count',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_performance_statistic_date_permission` (`date`, `permission_username`),
  KEY `idx_mkt_performance_statistic_date` (`date`),
  KEY `idx_mkt_performance_statistic_permission_username` (`permission_username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Performance statistics';

-- ----------------------------------------------------------------------------
-- Table: mkt_statistic - Statistics
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `mkt_statistic`;
CREATE TABLE `mkt_statistic` (
  `id`                      BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `date`                    DATE         NOT NULL                COMMENT 'Statistic date',
  `recharge_amount`         DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Recharge amount',
  `recharge_number`         INT          NOT NULL DEFAULT 0      COMMENT 'Recharge count',
  `withdrawal_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Withdrawal amount',
  `withdrawal_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Withdrawal count',
  `commission_amount`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Commission amount',
  `commission_number`       INT          NOT NULL DEFAULT 0      COMMENT 'Commission count',
  `parent_commission_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Parent commission amount',
  `parent_commission_number` INT         NOT NULL DEFAULT 0      COMMENT 'Parent commission count',
  `give_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Gift amount',
  `give_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Gift count',
  `sign_amount`             DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Sign-in amount',
  `sign_number`             INT          NOT NULL DEFAULT 0      COMMENT 'Sign-in count',
  `order_number`            INT          NOT NULL DEFAULT 0      COMMENT 'Order count',
  `task_complete_number`    INT          NOT NULL DEFAULT 0      COMMENT 'Task complete count',
  `create_date`             DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_mkt_statistic_date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Statistics';

-- ============================================================================
-- Section 4: Points Tables (pts_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: pts_gift - Points Gifts
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `pts_gift`;
CREATE TABLE `pts_gift` (
  `id`                    BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `title`                 VARCHAR(200) NOT NULL                COMMENT 'Gift title',
  `pic`                   VARCHAR(500) DEFAULT NULL            COMMENT 'Gift picture URL',
  `kind`                  TINYINT      DEFAULT NULL            COMMENT 'Gift kind',
  `points`                INT          NOT NULL DEFAULT 0      COMMENT 'Required points',
  `price`                 DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Gift price',
  `gift_stock`            INT          NOT NULL DEFAULT 0      COMMENT 'Total stock',
  `gift_available_stock`  INT          NOT NULL DEFAULT 0      COMMENT 'Available stock',
  `gift_freeze_stock`     INT          NOT NULL DEFAULT 0      COMMENT 'Frozen stock',
  `gift_sale_volume`      INT          NOT NULL DEFAULT 0      COMMENT 'Sale volume',
  `enabled`               TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`                VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`             INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`               VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`           DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`             INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`              VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`           DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_pts_gift_enabled` (`enabled`),
  KEY `idx_pts_gift_kind` (`kind`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Points gifts';

-- ----------------------------------------------------------------------------
-- Table: pts_account - Points Accounts
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `pts_account`;
CREATE TABLE `pts_account` (
  `id`               BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `member_username`  VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`     VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `points`           INT          NOT NULL DEFAULT 0      COMMENT 'Total points',
  `available_points` INT          NOT NULL DEFAULT 0      COMMENT 'Available points',
  `freeze_points`    INT          NOT NULL DEFAULT 0      COMMENT 'Frozen points',
  `remark`           VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`        INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`          VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`      DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`        INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`      DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_pts_account_member_username` (`member_username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Points accounts';

-- ----------------------------------------------------------------------------
-- Table: pts_flow - Points Flows
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `pts_flow`;
CREATE TABLE `pts_flow` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `flow_no`         VARCHAR(50)  NOT NULL                COMMENT 'Flow number',
  `trading_no`      VARCHAR(50)  DEFAULT NULL            COMMENT 'Trading number',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`    VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `points`          INT          NOT NULL DEFAULT 0      COMMENT 'Points amount',
  `before_points`   INT          NOT NULL DEFAULT 0      COMMENT 'Points before',
  `after_points`    INT          NOT NULL DEFAULT 0      COMMENT 'Points after',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_pts_flow_no` (`flow_no`),
  KEY `idx_pts_flow_member_username` (`member_username`),
  KEY `idx_pts_flow_trading_no` (`trading_no`),
  KEY `idx_pts_flow_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Points flows';

-- ----------------------------------------------------------------------------
-- Table: pts_gift_order - Points Gift Orders
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `pts_gift_order`;
CREATE TABLE `pts_gift_order` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `order_no`        VARCHAR(50)  NOT NULL                COMMENT 'Order number',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `gift_title`      VARCHAR(200) DEFAULT NULL            COMMENT 'Gift title',
  `gift_pic`        VARCHAR(500) DEFAULT NULL            COMMENT 'Gift picture URL',
  `points`          INT          NOT NULL DEFAULT 0      COMMENT 'Points spent',
  `consignee`       VARCHAR(100) DEFAULT NULL            COMMENT 'Consignee name',
  `telephone`       VARCHAR(20)  DEFAULT NULL            COMMENT 'Consignee phone',
  `delivery_address` VARCHAR(500) DEFAULT NULL           COMMENT 'Delivery address',
  `status`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Status: 0=Pending, 1=Shipped, 2=Completed, 3=Cancelled',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_pts_gift_order_no` (`order_no`),
  KEY `idx_pts_gift_order_member_username` (`member_username`),
  KEY `idx_pts_gift_order_status` (`status`),
  KEY `idx_pts_gift_order_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Points gift orders';

-- ============================================================================
-- Section 5: Activity Tables (act_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: act_activity - Activities
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `act_activity`;
CREATE TABLE `act_activity` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `title`           VARCHAR(200) NOT NULL                COMMENT 'Activity title',
  `pic`             VARCHAR(500) DEFAULT NULL            COMMENT 'Activity picture URL',
  `no_winning_tips` VARCHAR(500) DEFAULT NULL            COMMENT 'No winning tips message',
  `seq`             INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`         TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_act_activity_seq` (`seq`),
  KEY `idx_act_activity_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Activities';

-- ----------------------------------------------------------------------------
-- Table: act_prize - Activity Prizes
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `act_prize`;
CREATE TABLE `act_prize` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `activity_id` BIGINT       NOT NULL                COMMENT 'Activity ID',
  `title`       VARCHAR(200) NOT NULL                COMMENT 'Prize title',
  `pic`         VARCHAR(500) DEFAULT NULL            COMMENT 'Prize picture URL',
  `kind`        TINYINT      DEFAULT NULL            COMMENT 'Prize kind',
  `price`       DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Prize price/value',
  `probability` DECIMAL(5,2) NOT NULL DEFAULT 0.00  COMMENT 'Winning probability',
  `seq`         INT          NOT NULL DEFAULT 0      COMMENT 'Sort sequence',
  `enabled`     TINYINT      NOT NULL DEFAULT 1      COMMENT 'Enabled: 0=Disabled, 1=Enabled',
  `remark`      VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_act_prize_activity_id` (`activity_id`),
  KEY `idx_act_prize_kind` (`kind`),
  KEY `idx_act_prize_enabled` (`enabled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Activity prizes';

-- ----------------------------------------------------------------------------
-- Table: act_account - Activity Accounts
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `act_account`;
CREATE TABLE `act_account` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `activity_id`     BIGINT       NOT NULL                COMMENT 'Activity ID',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`    VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `available_times` INT          NOT NULL DEFAULT 0      COMMENT 'Available draw times',
  `used_times`      INT          NOT NULL DEFAULT 0      COMMENT 'Used draw times',
  `winning`         TINYINT      NOT NULL DEFAULT 0      COMMENT 'Winning: 0=No, 1=Yes',
  `prize_kind`      TINYINT      DEFAULT NULL            COMMENT 'Prize kind',
  `prize_title`     VARCHAR(200) DEFAULT NULL            COMMENT 'Prize title',
  `prize_pic`       VARCHAR(500) DEFAULT NULL            COMMENT 'Prize picture URL',
  `prize_price`     DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Prize price',
  `seq`             INT          NOT NULL DEFAULT 0      COMMENT 'Sequence',
  `verified`        TINYINT      NOT NULL DEFAULT 0      COMMENT 'Verified: 0=No, 1=Yes',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_act_account_activity_id` (`activity_id`),
  KEY `idx_act_account_member_username` (`member_username`),
  KEY `idx_act_account_winning` (`winning`),
  KEY `idx_act_account_verified` (`verified`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Activity accounts';

-- ----------------------------------------------------------------------------
-- Table: act_partner - Activity Partners
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `act_partner`;
CREATE TABLE `act_partner` (
  `id`              BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `activity_id`     BIGINT       NOT NULL                COMMENT 'Activity ID',
  `member_username` VARCHAR(50)  NOT NULL                COMMENT 'Member username',
  `member_phone`    VARCHAR(20)  DEFAULT NULL            COMMENT 'Member phone',
  `winning`         TINYINT      NOT NULL DEFAULT 0      COMMENT 'Winning: 0=No, 1=Yes',
  `prize_kind`      TINYINT      DEFAULT NULL            COMMENT 'Prize kind',
  `prize_title`     VARCHAR(200) DEFAULT NULL            COMMENT 'Prize title',
  `prize_pic`       VARCHAR(500) DEFAULT NULL            COMMENT 'Prize picture URL',
  `prize_price`     DECIMAL(18,2) NOT NULL DEFAULT 0.00  COMMENT 'Prize price',
  `verified`        TINYINT      NOT NULL DEFAULT 0      COMMENT 'Verified: 0=No, 1=Yes',
  `hidden`          TINYINT      NOT NULL DEFAULT 0      COMMENT 'Hidden: 0=No, 1=Yes',
  `remark`          VARCHAR(500) DEFAULT NULL            COMMENT 'Remark',
  `create_id`       INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`         VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date`     DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`       INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`        VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date`     DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_act_partner_activity_id` (`activity_id`),
  KEY `idx_act_partner_member_username` (`member_username`),
  KEY `idx_act_partner_winning` (`winning`),
  KEY `idx_act_partner_verified` (`verified`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Activity partners';

-- ============================================================================
-- Section 6: Website Tables (web_ prefix)
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: web_customer - Website Customers
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `web_customer`;
CREATE TABLE `web_customer` (
  `id`          BIGINT       NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `first_name`  VARCHAR(50)  DEFAULT NULL            COMMENT 'First name',
  `last_name`   VARCHAR(50)  DEFAULT NULL            COMMENT 'Last name',
  `email`       VARCHAR(100) DEFAULT NULL            COMMENT 'Email address',
  `company`     VARCHAR(200) DEFAULT NULL            COMMENT 'Company name',
  `country`     VARCHAR(100) DEFAULT NULL            COMMENT 'Country',
  `content`     TEXT         DEFAULT NULL            COMMENT 'Message content',
  `create_id`   INT          DEFAULT NULL            COMMENT 'Creator ID',
  `creator`     VARCHAR(50)  DEFAULT NULL            COMMENT 'Creator name',
  `create_date` DATETIME     DEFAULT NULL            COMMENT 'Creation datetime',
  `modify_id`   INT          DEFAULT NULL            COMMENT 'Modifier ID',
  `modifier`    VARCHAR(50)  DEFAULT NULL            COMMENT 'Modifier name',
  `modify_date` DATETIME     DEFAULT NULL            COMMENT 'Modification datetime',
  PRIMARY KEY (`id`),
  KEY `idx_web_customer_email` (`email`),
  KEY `idx_web_customer_country` (`country`),
  KEY `idx_web_customer_create_date` (`create_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Website customers';

-- ============================================================================
-- Section 7: Junction / Relationship Tables
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: sys_user_role - User-Role Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_role`;
CREATE TABLE `sys_user_role` (
  `id`      BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `user_id` BIGINT NOT NULL                COMMENT 'User ID',
  `role_id` BIGINT NOT NULL                COMMENT 'Role ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_user_role` (`user_id`, `role_id`),
  KEY `idx_sys_user_role_role_id` (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='User-Role association';

-- ----------------------------------------------------------------------------
-- Table: sys_user_group - User-Group Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_group`;
CREATE TABLE `sys_user_group` (
  `id`       BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `user_id`  BIGINT NOT NULL                COMMENT 'User ID',
  `group_id` BIGINT NOT NULL                COMMENT 'Group ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_user_group` (`user_id`, `group_id`),
  KEY `idx_sys_user_group_group_id` (`group_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='User-Group association';

-- ----------------------------------------------------------------------------
-- Table: sys_user_position - User-Position Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_position`;
CREATE TABLE `sys_user_position` (
  `id`          BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `user_id`     BIGINT NOT NULL                COMMENT 'User ID',
  `position_id` BIGINT NOT NULL                COMMENT 'Position ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_user_position` (`user_id`, `position_id`),
  KEY `idx_sys_user_position_position_id` (`position_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='User-Position association';

-- ----------------------------------------------------------------------------
-- Table: sys_user_strategy - User-Strategy Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_user_strategy`;
CREATE TABLE `sys_user_strategy` (
  `id`          BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `user_id`     BIGINT NOT NULL                COMMENT 'User ID',
  `strategy_id` BIGINT NOT NULL                COMMENT 'Strategy ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_user_strategy` (`user_id`, `strategy_id`),
  KEY `idx_sys_user_strategy_strategy_id` (`strategy_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='User-Strategy association';

-- ----------------------------------------------------------------------------
-- Table: sys_role_resource - Role-Resource Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_role_resource`;
CREATE TABLE `sys_role_resource` (
  `id`           BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `role_id`      BIGINT NOT NULL                COMMENT 'Role ID',
  `resource_id`  BIGINT NOT NULL                COMMENT 'Resource ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_role_resource` (`role_id`, `resource_id`),
  KEY `idx_sys_role_resource_resource_id` (`resource_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Role-Resource association';

-- ----------------------------------------------------------------------------
-- Table: sys_group_resource - Group-Resource Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_group_resource`;
CREATE TABLE `sys_group_resource` (
  `id`           BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `group_id`     BIGINT NOT NULL                COMMENT 'Group ID',
  `resource_id`  BIGINT NOT NULL                COMMENT 'Resource ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_group_resource` (`group_id`, `resource_id`),
  KEY `idx_sys_group_resource_resource_id` (`resource_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Group-Resource association';

-- ----------------------------------------------------------------------------
-- Table: sys_strategy_resource - Strategy-Resource Association
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS `sys_strategy_resource`;
CREATE TABLE `sys_strategy_resource` (
  `id`           BIGINT NOT NULL AUTO_INCREMENT COMMENT 'Primary key',
  `strategy_id`  BIGINT NOT NULL                COMMENT 'Strategy ID',
  `resource_id`  BIGINT NOT NULL                COMMENT 'Resource ID',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_sys_strategy_resource` (`strategy_id`, `resource_id`),
  KEY `idx_sys_strategy_resource_resource_id` (`resource_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Strategy-Resource association';

-- ============================================================================
-- Section 8: Seed Data
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Default Organization
-- ----------------------------------------------------------------------------
INSERT INTO `sys_org` (`id`, `name`, `parent_id`, `seq`, `remark`, `creator`, `create_date`) VALUES
(1, 'Headquarters', 0, 1, 'Root organization', 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Admin User
-- Password: admin123 (raw - application will hash on first use)
-- ----------------------------------------------------------------------------
INSERT INTO `sys_user` (`id`, `username`, `password`, `name`, `gender`, `org_id`, `enabled`, `builtin`, `locked_status`, `online_status`, `creator`, `create_date`) VALUES
(1, 'admin', 'admin123', 'Administrator', 1, 1, 1, 1, 0, 0, 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Roles
-- ----------------------------------------------------------------------------
INSERT INTO `sys_role` (`id`, `name`, `code`, `kind`, `builtin`, `remark`, `creator`, `create_date`) VALUES
(1, 'Super Admin', 'SUPER_ADMIN', 1, 1, 'Super administrator with all permissions', 'system', NOW()),
(2, 'Admin', 'ADMIN', 1, 1, 'Administrator with most permissions', 'system', NOW()),
(3, 'Operator', 'OPERATOR', 2, 0, 'Operator with limited permissions', 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default User-Role Assignment
-- ----------------------------------------------------------------------------
INSERT INTO `sys_user_role` (`user_id`, `role_id`) VALUES
(1, 1);

-- ----------------------------------------------------------------------------
-- Default Application
-- ----------------------------------------------------------------------------
INSERT INTO `app_app` (`id`, `name`, `code`, `remark`, `creator`, `create_date`) VALUES
(1, 'DataCenter', 'DATACENTER', 'DataCenter main application', 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Member Level
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_level` (`id`, `name`, `seq`, `price`, `balance_min`, `order_limit`, `complete_limit`, `withdrawal_limit`, `withdrawal_amount_min`, `withdrawal_amount_max`, `withdrawal_fee_rate`, `min_commission_percentage`, `max_commission_percentage`, `min_even_commission_percentage`, `max_even_commission_percentage`, `sign_in_bonus`, `creator`, `create_date`) VALUES
(1, 'Bronze', 1, 0.00, 0.00, 10, 10, 3, 10.00, 50000.00, 0.0100, 0.30, 0.50, 0.10, 0.20, 1.00, 'system', NOW()),
(2, 'Silver', 2, 100.00, 100.00, 20, 20, 5, 10.00, 100000.00, 0.0080, 0.50, 0.80, 0.20, 0.40, 2.00, 'system', NOW()),
(3, 'Gold', 3, 500.00, 500.00, 30, 30, 8, 10.00, 200000.00, 0.0050, 0.80, 1.20, 0.40, 0.60, 5.00, 'system', NOW()),
(4, 'Platinum', 4, 2000.00, 2000.00, 50, 50, 10, 10.00, 500000.00, 0.0030, 1.20, 2.00, 0.60, 1.00, 10.00, 'system', NOW()),
(5, 'Diamond', 5, 10000.00, 10000.00, 100, 100, 15, 10.00, 1000000.00, 0.0000, 2.00, 3.00, 1.00, 1.50, 20.00, 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Withdrawal Kind
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_withdrawal_kind` (`id`, `name`, `kind`, `seq`, `remark`, `creator`, `create_date`) VALUES
(1, 'USDT-TRC20', 1, 1, 'USDT TRC20 withdrawal', 'system', NOW()),
(2, 'USDT-ERC20', 2, 2, 'USDT ERC20 withdrawal', 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Settings
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_setting` (`id`, `code`, `kind`, `value`, `level_seq`, `amount`, `bonus`, `seq`, `url`, `message`, `interval`, `limit`, `daily_interest_rate`, `order_number`, `remark`, `creator`, `create_date`) VALUES
(1,  'SIGN_IN_BONUS',             1, NULL, 0, 0.00, 1.00,  1, NULL, NULL, 0, 0, 0.000000, 0, 'Sign-in daily bonus',             'system', NOW()),
(2,  'INVITE_BONUS',              1, NULL, 0, 0.00, 5.00,  2, NULL, NULL, 0, 0, 0.000000, 0, 'Invite new member bonus',          'system', NOW()),
(3,  'ORDER_DURATION',            2, NULL, 0, 0.00, 0.00,  3, NULL, NULL, 30, 0, 0.000000, 0, 'Order completion duration (min)',   'system', NOW()),
(4,  'WITHDRAWAL_REVIEW',         3, NULL, 0, 0.00, 0.00,  4, NULL, NULL, 0, 0, 0.000000, 0, 'Withdrawal review setting',         'system', NOW()),
(5,  'WITHDRAWAL_MIN_AMOUNT',     4, NULL, 0, 10.00, 0.00, 5, NULL, NULL, 0, 0, 0.000000, 0, 'Minimum withdrawal amount',         'system', NOW()),
(6,  'WITHDRAWAL_MAX_AMOUNT',     4, NULL, 0, 500000.00, 0.00, 6, NULL, NULL, 0, 0, 0.000000, 0, 'Maximum withdrawal amount',      'system', NOW()),
(7,  'WITHDRAWAL_FEE_RATE',       4, NULL, 0, 0.00, 0.00,  7, NULL, NULL, 0, 0, 0.010000, 0, 'Withdrawal fee rate',              'system', NOW()),
(8,  'DAILY_ORDER_LIMIT',         5, NULL, 0, 0.00, 0.00,  8, NULL, NULL, 0, 30, 0.000000, 0, 'Daily order limit per member',     'system', NOW()),
(9,  'RECHARGE_MIN_AMOUNT',       6, NULL, 0, 10.00, 0.00, 9, NULL, NULL, 0, 0, 0.000000, 0, 'Minimum recharge amount',          'system', NOW()),
(10, 'YUEBAO_DAILY_INTEREST_RATE', 7, NULL, 0, 0.00, 0.00, 10, NULL, NULL, 0, 0, 0.000100, 0, 'Yuebao daily interest rate',      'system', NOW()),
(11, 'CUSTOMER_SERVICE_URL',      8, NULL, 0, 0.00, 0.00, 11, 'https://t.me/support', NULL, 0, 0, 0.000000, 0, 'Customer service URL',            'system', NOW()),
(12, 'REGISTER_ENABLED',          9, 'true', 0, 0.00, 0.00, 12, NULL, NULL, 0, 0, 0.000000, 0, 'Registration enabled',            'system', NOW()),
(13, 'INVITE_CODE_REQUIRED',      9, 'true', 0, 0.00, 0.00, 13, NULL, NULL, 0, 0, 0.000000, 0, 'Invite code required for register', 'system', NOW()),
(14, 'WITHDRAWAL_TIMES_DAILY',    4, NULL, 0, 0.00, 0.00, 14, NULL, NULL, 0, 3, 0.000000, 0, 'Daily withdrawal times limit',     'system', NOW()),
(15, 'TASK_GROUPS_BONUS',         1, NULL, 0, 0.00, 10.00, 15, NULL, NULL, 0, 0, 0.000000, 0, 'Task groups completion bonus',     'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Banner
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_banner` (`id`, `name`, `kind`, `seq`, `enabled`, `creator`, `create_date`) VALUES
(1, 'Welcome Banner', 1, 1, 1, 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Bulletin
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_bulletin` (`id`, `title`, `content`, `seq`, `enabled`, `creator`, `create_date`) VALUES
(1, 'Welcome to DataCenter', 'Welcome to DataCenter platform. We are glad to have you here!', 1, 1, 'system', NOW());

-- ----------------------------------------------------------------------------
-- Default Customer Service
-- ----------------------------------------------------------------------------
INSERT INTO `mkt_customer_service` (`id`, `name`, `seq`, `enabled`, `creator`, `create_date`) VALUES
(1, 'Online Support', 1, 1, 'system', NOW());

-- ============================================================================
-- Foreign Key Constraints (added after all tables and data)
-- ============================================================================

ALTER TABLE `sys_user`                    ADD CONSTRAINT `fk_sys_user_org`                     FOREIGN KEY (`org_id`)        REFERENCES `sys_org` (`id`)                    ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE `sys_position`               ADD CONSTRAINT `fk_sys_position_org`                 FOREIGN KEY (`org_id`)        REFERENCES `sys_org` (`id`)                    ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE `sys_user_role`              ADD CONSTRAINT `fk_sys_user_role_user`               FOREIGN KEY (`user_id`)       REFERENCES `sys_user` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_role`              ADD CONSTRAINT `fk_sys_user_role_role`               FOREIGN KEY (`role_id`)       REFERENCES `sys_role` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_group`             ADD CONSTRAINT `fk_sys_user_group_user`              FOREIGN KEY (`user_id`)       REFERENCES `sys_user` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_group`             ADD CONSTRAINT `fk_sys_user_group_group`             FOREIGN KEY (`group_id`)      REFERENCES `sys_group` (`id`)                  ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_position`          ADD CONSTRAINT `fk_sys_user_position_user`           FOREIGN KEY (`user_id`)       REFERENCES `sys_user` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_position`          ADD CONSTRAINT `fk_sys_user_position_position`       FOREIGN KEY (`position_id`)   REFERENCES `sys_position` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_strategy`          ADD CONSTRAINT `fk_sys_user_strategy_user`           FOREIGN KEY (`user_id`)       REFERENCES `sys_user` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_user_strategy`          ADD CONSTRAINT `fk_sys_user_strategy_strategy`       FOREIGN KEY (`strategy_id`)   REFERENCES `sys_strategy` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_role_resource`          ADD CONSTRAINT `fk_sys_role_resource_role`           FOREIGN KEY (`role_id`)       REFERENCES `sys_role` (`id`)                   ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_role_resource`          ADD CONSTRAINT `fk_sys_role_resource_resource`       FOREIGN KEY (`resource_id`)   REFERENCES `app_resource` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_group_resource`         ADD CONSTRAINT `fk_sys_group_resource_group`         FOREIGN KEY (`group_id`)      REFERENCES `sys_group` (`id`)                  ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_group_resource`         ADD CONSTRAINT `fk_sys_group_resource_resource`      FOREIGN KEY (`resource_id`)   REFERENCES `app_resource` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_strategy_resource`      ADD CONSTRAINT `fk_sys_strategy_resource_strategy`   FOREIGN KEY (`strategy_id`)   REFERENCES `sys_strategy` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `sys_strategy_resource`      ADD CONSTRAINT `fk_sys_strategy_resource_resource`   FOREIGN KEY (`resource_id`)   REFERENCES `app_resource` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `app_resource`               ADD CONSTRAINT `fk_app_resource_app`                 FOREIGN KEY (`app_id`)        REFERENCES `app_app` (`id`)                    ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `mkt_member`                 ADD CONSTRAINT `fk_mkt_member_level`                 FOREIGN KEY (`level_id`)      REFERENCES `mkt_level` (`id`)                  ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE `mkt_spu`                    ADD CONSTRAINT `fk_mkt_spu_category`                 FOREIGN KEY (`category_id`)   REFERENCES `mkt_category` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `mkt_order_detail`           ADD CONSTRAINT `fk_mkt_order_detail_spu`             FOREIGN KEY (`spu_id`)        REFERENCES `mkt_spu` (`id`)                    ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE `mkt_order_detail_comment`   ADD CONSTRAINT `fk_mkt_order_detail_comment_detail`  FOREIGN KEY (`order_detail_id`) REFERENCES `mkt_order_detail` (`id`)          ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `act_prize`                  ADD CONSTRAINT `fk_act_prize_activity`               FOREIGN KEY (`activity_id`)   REFERENCES `act_activity` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `act_account`                ADD CONSTRAINT `fk_act_account_activity`             FOREIGN KEY (`activity_id`)   REFERENCES `act_activity` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `act_partner`                ADD CONSTRAINT `fk_act_partner_activity`             FOREIGN KEY (`activity_id`)   REFERENCES `act_activity` (`id`)               ON DELETE CASCADE ON UPDATE CASCADE;

SET FOREIGN_KEY_CHECKS = 1;
