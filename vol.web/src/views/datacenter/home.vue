<template>
  <div class="dc-home">
    <div class="stat-cards">
      <div class="stat-card blue">
        <div class="stat-info">
          <div class="stat-label">今日充值金额</div>
          <div class="stat-value">{{ statistics.todayRecharge || 0 }}</div>
          <div class="stat-total">累计: {{ statistics.totalRecharge || 0 }}</div>
        </div>
        <div class="stat-icon">
          <el-icon :size="40"><Coin /></el-icon>
        </div>
      </div>
      <div class="stat-card green">
        <div class="stat-info">
          <div class="stat-label">今日提现金额</div>
          <div class="stat-value">{{ statistics.todayWithdrawal || 0 }}</div>
          <div class="stat-total">累计: {{ statistics.totalWithdrawal || 0 }}</div>
        </div>
        <div class="stat-icon">
          <el-icon :size="40"><Wallet /></el-icon>
        </div>
      </div>
      <div class="stat-card purple">
        <div class="stat-info">
          <div class="stat-label">今日会员数</div>
          <div class="stat-value">{{ statistics.todayMember || 0 }}</div>
          <div class="stat-total">累计: {{ statistics.totalMember || 0 }}</div>
        </div>
        <div class="stat-icon">
          <el-icon :size="40"><User /></el-icon>
        </div>
      </div>
      <div class="stat-card orange">
        <div class="stat-info">
          <div class="stat-label">今日投注数</div>
          <div class="stat-value">{{ statistics.todayBet || 0 }}</div>
          <div class="stat-total">累计: {{ statistics.totalBet || 0 }}</div>
        </div>
        <div class="stat-icon">
          <el-icon :size="40"><TrendCharts /></el-icon>
        </div>
      </div>
    </div>

    <div class="chart-row">
      <div class="chart-card">
        <div class="chart-title">会员数量统计(近7天)</div>
        <div id="memberChart" class="chart-container"></div>
      </div>
      <div class="chart-card">
        <div class="chart-title">金额统计</div>
        <div id="amountChart" class="chart-container"></div>
      </div>
    </div>

    <div class="chart-row">
      <div class="chart-card full">
        <div class="chart-title">数量统计</div>
        <div id="numberChart" class="chart-container"></div>
      </div>
    </div>
  </div>
</template>
<script setup>
import { ref, reactive, getCurrentInstance, onMounted, onUnmounted } from 'vue'
import { Coin, Wallet, User, TrendCharts } from '@element-plus/icons-vue'
import * as echarts from 'echarts'

const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_MktStatistic/'

const statistics = reactive({
  todayRecharge: 0,
  totalRecharge: 0,
  todayWithdrawal: 0,
  totalWithdrawal: 0,
  todayMember: 0,
  totalMember: 0,
  todayBet: 0,
  totalBet: 0
})

let memberChart = null
let amountChart = null
let numberChart = null

const loadStatistics = () => {
  proxy.http.post(url + 'getSummary', {}).then(result => {
    if (!result || !result.data) return
    Object.assign(statistics, result.data)
  })
}

const loadMemberChart = () => {
  proxy.http.post(url + 'getMemberChart', {}).then(result => {
    if (!result || !result.data) return
    initMemberChart(result.data)
  })
}

const loadAmountChart = () => {
  proxy.http.post(url + 'getAmountChart', {}).then(result => {
    if (!result || !result.data) return
    initAmountChart(result.data)
  })
}

const loadNumberChart = () => {
  proxy.http.post(url + 'getNumberChart', {}).then(result => {
    if (!result || !result.data) return
    initNumberChart(result.data)
  })
}

const initMemberChart = (data) => {
  memberChart = echarts.init(document.getElementById('memberChart'))
  memberChart.setOption({
    tooltip: { trigger: 'axis' },
    grid: { left: 50, right: 20, top: 30, bottom: 30 },
    xAxis: {
      type: 'category',
      data: data.dates || [],
      axisTick: { show: false },
      axisLine: { show: false }
    },
    yAxis: { type: 'value', splitNumber: 3, splitLine: { show: false } },
    series: [{
      name: '会员数',
      type: 'bar',
      barWidth: 30,
      itemStyle: {
        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
          { offset: 0, color: '#8b5cf6' },
          { offset: 1, color: '#c4b5fd' }
        ]),
        borderRadius: [4, 4, 0, 0]
      },
      data: data.values || []
    }]
  })
}

const initAmountChart = (data) => {
  amountChart = echarts.init(document.getElementById('amountChart'))
  const series = [
    { name: '充值', key: 'recharge', color: '#409EFF' },
    { name: '提现', key: 'withdrawal', color: '#67C23A' },
    { name: '佣金', key: 'commission', color: '#E6A23C' },
    { name: '上级佣金', key: 'parentCommission', color: '#F56C6C' },
    { name: '赠送', key: 'give', color: '#909399' },
    { name: '签到', key: 'sign', color: '#8b5cf6' }
  ]
  amountChart.setOption({
    tooltip: { trigger: 'axis' },
    legend: { bottom: 0, itemHeight: 9, itemWidth: 12, icon: 'roundRect' },
    grid: { left: 50, right: 20, top: 30, bottom: 40 },
    xAxis: {
      type: 'category',
      data: data.dates || [],
      axisTick: { show: false },
      axisLine: { show: false }
    },
    yAxis: { type: 'value', splitNumber: 3, splitLine: { show: false } },
    series: series.map(s => ({
      name: s.name,
      type: 'line',
      smooth: true,
      showSymbol: false,
      itemStyle: { color: s.color },
      data: data[s.key] || []
    }))
  })
}

const initNumberChart = (data) => {
  numberChart = echarts.init(document.getElementById('numberChart'))
  const series = [
    { name: '充值', key: 'recharge', color: '#409EFF' },
    { name: '提现', key: 'withdrawal', color: '#67C23A' },
    { name: '佣金', key: 'commission', color: '#E6A23C' },
    { name: '上级佣金', key: 'parentCommission', color: '#F56C6C' },
    { name: '赠送', key: 'give', color: '#909399' },
    { name: '签到', key: 'sign', color: '#8b5cf6' },
    { name: '订单', key: 'order', color: '#ec4899' },
    { name: '投注', key: 'bet', color: '#14b8a6' },
    { name: '任务完成', key: 'taskComplete', color: '#f97316' },
    { name: '重置', key: 'reset', color: '#6366f1' }
  ]
  numberChart.setOption({
    tooltip: { trigger: 'axis' },
    legend: { bottom: 0, itemHeight: 9, itemWidth: 12, icon: 'roundRect' },
    grid: { left: 50, right: 20, top: 30, bottom: 40 },
    xAxis: {
      type: 'category',
      data: data.dates || [],
      axisTick: { show: false },
      axisLine: { show: false }
    },
    yAxis: { type: 'value', splitNumber: 3, splitLine: { show: false } },
    series: series.map(s => ({
      name: s.name,
      type: 'line',
      smooth: true,
      showSymbol: false,
      itemStyle: { color: s.color },
      data: data[s.key] || []
    }))
  })
}

const handleResize = () => {
  memberChart && memberChart.resize()
  amountChart && amountChart.resize()
  numberChart && numberChart.resize()
}

onMounted(() => {
  loadStatistics()
  loadMemberChart()
  loadAmountChart()
  loadNumberChart()
  window.addEventListener('resize', handleResize)
})

onUnmounted(() => {
  window.removeEventListener('resize', handleResize)
  memberChart && memberChart.dispose()
  amountChart && amountChart.dispose()
  numberChart && numberChart.dispose()
})
</script>
<style lang="less" scoped>
.dc-home {
  padding: 15px;
  background: #f3f7fb;
  min-height: calc(100vh - 100px);
}

.stat-cards {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 15px;
  margin-bottom: 15px;
}

.stat-card {
  background: #fff;
  border-radius: 8px;
  padding: 20px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  position: relative;
  overflow: hidden;

  &::before {
    content: '';
    position: absolute;
    left: 0;
    top: 0;
    bottom: 0;
    width: 4px;
  }

  &.blue::before { background: #409EFF; }
  &.green::before { background: #67C23A; }
  &.purple::before { background: #8b5cf6; }
  &.orange::before { background: #f97316; }

  .stat-info {
    .stat-label {
      font-size: 14px;
      color: #909399;
      margin-bottom: 8px;
    }
    .stat-value {
      font-size: 24px;
      font-weight: bold;
      color: #303133;
      margin-bottom: 4px;
    }
    .stat-total {
      font-size: 12px;
      color: #c0c4cc;
    }
  }

  .stat-icon {
    opacity: 0.2;
  }

  &.blue .stat-icon { color: #409EFF; }
  &.green .stat-icon { color: #67C23A; }
  &.purple .stat-icon { color: #8b5cf6; }
  &.orange .stat-icon { color: #f97316; }
}

.chart-row {
  display: flex;
  gap: 15px;
  margin-bottom: 15px;
}

.chart-card {
  background: #fff;
  border-radius: 8px;
  padding: 15px;
  flex: 1;

  &.full {
    flex: 1;
  }

  .chart-title {
    font-size: 14px;
    font-weight: bold;
    color: #303133;
    margin-bottom: 10px;
  }

  .chart-container {
    height: 300px;
    width: 100%;
  }
}
</style>
