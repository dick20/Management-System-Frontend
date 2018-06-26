<template lang="jade">
  .monitor-page-dashboard
    .page-header
      h1
        | Machine
    table.table
      thead
        tr
          th 机器ID
          th 机器名
          th 内网IP地址
          th CPU概况
          th 内存概况
          th 磁盘概况
          th 创建时间
          th 上次重启时间
          th 数据更新时间
          th 详情
      tbody
        tr(v-for="machine in machines")
          td {{ machine.mac_id }}
          td {{ machine.name }}
          td {{ machine.private_ip }}
          td {{ machine.performance.cpu.used_cache_size }} / {{ machine.performance.cpu.total_cache_size }}
          td {{ machine.performance.memory.used_size }} / {{ machine.performance.memory.total_size }}
          td {{ machine.performance.disk.used_size }} / {{ machine.performance.disk.total_size }}
          td {{ machine.created_at }}
          td {{ machine.restart_at }}
          td {{ machine.updated_at }}
          td
            a(href="javascript:void(0)", v-on:click="detail(machine.mac_id)") 点击查看
</template>

<script>
import machineService from '../service/machine.js'

export default {
  name: 'MachineList',
  ready: function () {
    machineService.getMachineList(this).then((response) => {
      if (response.data.status) {
        let machines = response.data.data || []
        this.$set('machines', machines)
      }
    })
  },
  data: function () {
    return {
      machines: []
    }
  },
  methods: {
    detail: function (machineId) {
      this.$route.router.go({
        name: 'MachineDetail',
        params: {
          machineId: machineId
        }
      })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
