<template>
  <div>

    <div class="el-page-header__content">Отделы</div>
    <div style="margin-top: 10px">
       <el-button @click="createDepartment()" type="primary">Создать новый отдел</el-button>
    </div>
    <el-table :data="departments" stripe style="width: 100%" v-loading="loadingTable">
      <el-table-column prop="id" label="ID" ></el-table-column>
      <el-table-column prop="name" label="Имя">
        <template slot-scope="scope">
          <el-button @click="openDepartment(scope.row)" type="text" title="Посмотреть сотрудников">{{ scope.row.name }}</el-button>
        </template>
      </el-table-column>
      <el-table-column prop="salary" label="Средняя зарплата"></el-table-column>
       <el-table-column prop="employeesCount" label="Количество сотрудников" ></el-table-column>
      <el-table-column >
        <template slot-scope="scope">
          <el-button @click="editDepartment(scope.row)">Редактировать</el-button>
        </template>
      </el-table-column>
      <el-table-column >
        <template slot-scope="scope">
          <el-popconfirm @confirm="deleteDepartment(scope.row.id)" title="Вы уверены? Сотрудники отдела будут так же удалены">
            <el-button slot="reference" type="danger">Удалить</el-button>
          </el-popconfirm>
        </template>
      </el-table-column>
    </el-table>

    <DepartmentModal :visible="visible" :handleClose="handleClose" :form="form" />

  </div>
</template>
<script>
  import axios from 'axios';
  import DepartmentModal from '@/components/DepartmentModal.vue';

  export default {
    components: {
      DepartmentModal
    },
    data() {
      return {
        form: { id: null, name:null},
        visible: false,
        departments: [],
        loadingTable: false
      }
    },
    methods: {
      editDepartment(department) {
        this.form = {
          id: department.id,
          name: department.name
        };
        this.visible = true;
      },
      createDepartment() {
        this.form = { id: null, name:null}
        this.visible = true;
      },
      openDepartment(Department) {
        this.$router.push('/Department/' + Department.id);
      },
      deleteDepartment(id) {
        this.form = {id: id};//для удаления достаточно только id
        axios.delete('/api/Department', {
                    data: this.form
                }).then(() => {
                    this.handleClose(); 
                });
      },
      loadDepartments() {
        this.loadingTable = true;
        axios.get('/api/department').then(response => {
          this.departments = response.data;
          for(let i = 0; i < this.departments.length; i++){
            this.departments[i].salary = Math.round(this.departments[i].salary) + " руб."
          }
        }).finally(()=>{
          this.loadingTable = false;
          });
      },
      handleClose() {
        this.visible = false;
        this.loadDepartments();
      }
    },
    mounted() {
      this.loadDepartments();
    }
  }
</script>
<style scoped>
 
</style>
