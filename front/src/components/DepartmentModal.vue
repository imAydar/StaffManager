<template>
    <div>
        <el-dialog title="Отдел" :visible="visible" width="30%" :before-close="handleClose" @close="onClose">
            <p v-if="this.errors.length > 0" class="errors">
                <b>Пожалуйста исправьте указанные ошибки:</b>
                <ul>
                    <li v-for="error in this.errors" :key="error">{{ error }}</li>
                </ul>
            </p>
            <el-form  label-width="100px" :model="form">
                <el-form-item label="Название">
                    <el-input v-model="form.name"></el-input>
                </el-form-item>
            </el-form>
            <span slot="footer" class="dialog-footer">
            <el-button @click="handleClose()">Отмена</el-button>
            <el-button type="primary" @click="sendForm()">Ок</el-button>
            </span>
        </el-dialog>
    </div>
</template>
<script>
import axios from 'axios';

export default {
    data(){
        return{
            errors:[]
        }
    },
    props: {
        visible: Boolean,
        handleClose: Function,
        form: Object
    },
    methods: {
        checkInputs() {
            for (var prop in this.form) {
                if (this.form[prop] == "")
                    this.form[prop] = null;
            }
            return true;
        },
        sendForm() {
            if (!this.checkInputs())
                return;
            if (this.form.id) { // если есть id значит мы редактируем
                axios.put('/api/department',
                    JSON.stringify(this.form), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                ).then(() => { //если все хорошо закрываем модалку
                    this.handleClose();
                }).catch((error) => {
                    let msg = error.response.data;
                    this.errors.push(msg);
                });
            } else { // если нет id значит мы создаем
                this.form.id = 0;
                axios.post("http://localhost:5002/department",
                    JSON.stringify(this.form), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                ).then(() => {
                    this.handleClose();
                }).catch((error) => {
                    let msg = error.response.data;
                    this.errors.push(msg);
                });
            }
        },
        onClose(){
            this.errors = [];
        }
    }
}
</script>

<style scoped>
.errors{
    color: red;
    margin: -20px 0 20px 20px;
}
</style>