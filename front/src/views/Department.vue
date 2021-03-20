<template>
  <div>

    <el-page-header @back="goBack" :content="'Сотрудники отдела №' + $route.params.id"></el-page-header>
     <div style="margin-top: 10px">
       <el-button @click="createEmployee($route.params.id)" type="primary">Создать нового сотрудника</el-button>
    </div>
    <el-table :data="employees" stripe style="width: 100%" v-loading="loadingTable">
      <el-table-column prop="id" label="ID" width="55%"></el-table-column>
      <el-table-column prop="name" label="Имя">
         <template slot-scope="scope">
           <el-button @click="editEmployee(scope.row)" type="text">{{scope.row.name}}</el-button>
         </template>
      </el-table-column>
      <el-table-column prop="salaryView" label="Зарплата">
      </el-table-column>
      <el-table-column width="150px">
        <template slot-scope="scope">
          <el-button @click="editEmployee(scope.row)">Редактировать</el-button>
        </template>
      </el-table-column>
      <el-table-column width="140px">
        <template slot-scope="scope">
          <el-popconfirm @confirm="deleteEmployee(scope.row.id)" title="Вы уверены?">
            <el-button slot="reference" type="danger">Удалить</el-button>
          </el-popconfirm>
        </template>
      </el-table-column>
    </el-table>

    <EmployeeModal :visible="visible" :handleClose="handleClose" :form="form" />

  </div>
</template>

<script>
import { http } from '@/helpers/http-common';
import EmployeeModal from '@/components/EmployeeModal.vue';

export default {
   components: {
      EmployeeModal
    },
  data() {
    return {
      employees: [],
      loadingTable: false,
      visible: false,
      form:{ id:null, name:null, salary:null, departmentId:null}
    }
  },
  methods: {
    goBack() {
      window.history.length > 1 ? this.$router.go(-1) : this.$router.push('/')
    },
    loadEmployees() {
      this.loadingTable = true;
      http.get('employee/' + this.$route.params.id)
      .then(employees => {
        this.employees = employees.data;
          for(let i = 0; i < this.employees.length; i++){
            this.employees[i].salaryView = Math.round(this.employees[i].salary) + " руб."
          }
      }).finally(()=>{
          this.loadingTable = false;
      });
    },
    createEmployee(departmentId) {
        this.form = { id:null, name:null, salary:null, departmentId:departmentId}
        this.visible = true;
      },
    editEmployee(employee) {
      this.visible = true;
      this.form = {id: employee.id, name: employee.name, salary: employee.salary, departmentId : employee.departmentId};
    },
    deleteEmployee(employeeId) {
      this.form = {id: employeeId};//для удаления достаточно только id
      http.delete('employee', {
                    data: this.form
                }).then(() => {
                    this.handleClose(); 
                });
    },
    handleClose() {
        this.visible = false;
        this.loadEmployees();
      }
  },
  mounted() {
    this.loadEmployees();
  }
}
</script>
