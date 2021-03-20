import Vue from 'vue'
import VueRouter from 'vue-router'
import DepartmentList from '../views/DepartmentList.vue'
import Department from '../views/Department.vue'
import NotFound from '../components/NotFound.vue'

Vue.use(VueRouter)

const routes = [{
        path: '/',
        redirect: '/departments'
    },
    {
        path: '/departments',
        name: 'Departments',
        component: DepartmentList
    },
    {
        path: '/department/:id',
        name: 'Department',
        component: Department
    },
    {
        path: '/404',
        name: '404',
        component: NotFound,
    },
    {
        path: '*',
        redirect: '/404'
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router