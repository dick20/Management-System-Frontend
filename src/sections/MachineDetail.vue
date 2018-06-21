<template lang="jade">
  .monitor-page-dashboard
    .page-header
      h1
        | Machine '{{machineDetail.name}}' Detail
    .row
      .col-md-2
        doughnut-chart(:data='cpuCurrentData', v-if="machineDetail")
      .col-md-4.machine-info-table
        h3 CPU 使用情况
        table.table(v-if="machineDetail")
          thead
            tr
              td idel
              td iowait
              td nice
              td steal
              td system
              td user
          tbody
            tr
              td {{ machineDetail.cpu.idle_per }}
              td {{ machineDetail.cpu.iowait_per }}
              td {{ machineDetail.cpu.nice_per }}
              td {{ machineDetail.cpu.steal_per }}
              td {{ machineDetail.cpu.system_per }}
              td {{ machineDetail.cpu.user_per }}
    hr
    .row
      .col-md-2
        doughnut-chart(:data='memCurrentData', v-if="machineDetail")
      .col-md-4.machine-info-table
        h3 内存 使用情况
        table.table(v-if="machineDetail")
          thead
            tr
              td buffers
              td cached
              td memfree
              td memused
          tbody
            tr
              td {{ (machineDetail.memory.buffers / 1024 / 1024).toFixed(2) }} GB
              td {{ (machineDetail.memory.cached / 1024 / 1024).toFixed(2) }} GB
              td {{ (machineDetail.memory.memfree / 1024 / 1024).toFixed(2) }} GB
              td {{ (machineDetail.memory.memused / 1024 / 1024).toFixed(2) }} GB
    hr
    .row
      .col-md-2
        doughnut-chart(:data='diskCurrentData', v-if="machineDetail")
      .col-md-4.machine-info-table
        h3 IO使用情况
        table.table(v-if="machineDetail")
          thead
            tr
              td 设备名称
              td avgqu-sz
              td avgrq-sz
              td await
              td rd_sec/s
              td wr_sec/s
              td tps
              td utils_per
          tbody
            tr
              td {{ machineDetail.disk['dev_name'] }}
              td {{ machineDetail.disk['avgqu-sz'] }}
              td {{ machineDetail.disk['avgrq-sz'] }}
              td {{ machineDetail.disk['await'] }}
              td {{ machineDetail.disk['rd_sec/s'] }}
              td {{ machineDetail.disk['wr_sec/s'] }}
              td {{ machineDetail.disk['tps'] }}
              td {{ machineDetail.disk['util_per'] }}

</template>

<script>
import machineService from '../service/machine.js'
import doughnutChart from '../components/charts/doughnut.js'

export default {
  name: 'MachineDetail',
  ready: function () {
    let machineId = parseInt(this.$route.params.machineId)
    machineService.getOneMachineDetail(this, machineId).then((response) => {
      if (response.data.status) {
        let machineDetail = response.data.data || {}
        this.$set('cpuCurrentData.datasets[0].data', [
          machineDetail.cpu.idle_per,
          machineDetail.cpu.iowait_per,
          machineDetail.cpu.nice_per,
          machineDetail.cpu.steal_per,
          machineDetail.cpu.system_per,
          machineDetail.cpu.user_per
        ])
        this.$set('memCurrentData.datasets[0].data', [
          (machineDetail.memory.buffers / 1024 / 1024).toFixed(2),
          (machineDetail.memory.cached / 1024 / 1024).toFixed(2),
          (machineDetail.memory.memfree / 1024 / 1024).toFixed(2),
          (machineDetail.memory.memused / 1024 / 1024).toFixed(2)
        ])
        this.$set('diskCurrentData.datasets[0].data', [
          (machineDetail.disk.util_per),
          (machineDetail.disk.util_per <= 100 ? 100 - machineDetail.disk.util_per : 0)
        ])
        this.$set('machineDetail', machineDetail)
      }
    })
  },
  data: function () {
    let chartDataTemplate = {
      labels: ['idle', 'iowait', 'nice', 'steal', 'system', 'user'],
      datasets: [
        {
          data: [],
          backgroundColor: ['#00C26B', '#36A2EB', '#FFCE5B', '#F7464A', '#FF6384', '#00a65a'],
          hoverBackgroundColor: ['#00C26B', '#36A2EB', '#FFCE5B', '#F7464A', '#FF6384', '#00a65a']
        }
      ]
    }

    let cpuCurrentData = JSON.parse(JSON.stringify(chartDataTemplate))
    let memCurrentData = JSON.parse(JSON.stringify(chartDataTemplate))
    let diskCurrentData = JSON.parse(JSON.stringify(chartDataTemplate))

    memCurrentData.labels = ['buffers', 'cached', 'memfree', 'memused']
    memCurrentData.datasets[0].backgroundColor = memCurrentData.datasets[0].hoverBackgroundColor = ['#FFCE5B', '#F7464A', '#FF6384', '#00a65a']

    diskCurrentData.labels = ['util_per', 'nutil_per']
    diskCurrentData.datasets[0].backgroundColor = diskCurrentData.datasets[0].hoverBackgroundColor = ['#FFCE5B', '#F7464A']

    return {
      machineDetail: null,
      cpuCurrentData: cpuCurrentData,
      memCurrentData: memCurrentData,
      diskCurrentData: diskCurrentData
    }
  },
  components: {
    doughnutChart
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.machine-info-table {
  margin-top: 4%;
}
</style>
