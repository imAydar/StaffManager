import axios from 'axios';

export const http = axios.create({
    baseURL: 'https://staff-manager-lx.azurewebsites.net',
    headers: {
        'Content-Type': 'application/json'
    }
})